using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;



//  BNode.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 节点类型
    /// </summary>
    public enum NODE_TYPE
    { 
        NODE_ACTION = 1,    //执行节点
        NODE_COMPOSITE = 2, //混合节点
        NODE_CONDITION = 3, //条件节点
        NODE_DECORATOR = 4, //装饰节点
    }

    /// <summary>
    /// 行为树节点基类
    /// </summary>
    public abstract class BNode
    {
		//value
		protected int m_iID;	//ID
        protected int m_iTypeID;    //类型ID
		protected int m_iParentID;	//parent id
		protected List<int> m_lstChildrenID = new List<int>();	//children id

		//parent
		protected BNode m_cParent;  //父节点
		protected List<BNode> m_lstChildren = new List<BNode>();   //子节点

		public virtual void Read( BinaryReader br )
		{
			this.m_iID = br.ReadInt32();
			this.m_iTypeID = br.ReadInt32();
			this.m_iParentID = br.ReadInt32();
			int count = br.ReadInt32();
			this.m_lstChildrenID.Clear();
			for( int i = 0 ; i<count ; i++)
			{
				int id = br.ReadInt32();
				this.m_lstChildrenID.Add(id);
			}
		}

		public virtual void ReadJson( JsonData json )
		{
			this.m_iID = int.Parse(json["id"].ToJson());
			this.m_iTypeID = int.Parse(json["typeid"].ToJson());
		}

		public virtual void WriteJson( JsonData node )
		{
			JsonData json = new JsonData();
			json["id"] = this.m_iID;
			json["typeid"] = this.m_iTypeID;
			node["node"] = json;
		}

		public virtual void Write( BinaryWriter bw )
		{
			bw.Write(this.m_iID);
			bw.Write(this.m_iTypeID);
			bw.Write(this.m_iParentID);
			bw.Write(this.m_lstChildrenID.Count);
			for( int i = 0 ; i<this.m_lstChildrenID.Count ; i++ )
			{
				bw.Write(this.m_lstChildrenID[i]);
			}
		}


		public virtual string GetName()
		{
			return "";
		}

		public virtual void DrawGUI(int x , int y)
		{
			//
		}

		public int GetID()
		{
			return this.m_iID;
		}

		public void SetID( int id )
		{
			this.m_iID = id;
		}

		public int GetTypeID()
		{
			return this.m_iTypeID;
		}

		public void SetTypeID( int value )
		{
			this.m_iTypeID = value;
		}

        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="node"></param>
        public void SetParent(BNode node)
        {
            this.m_cParent = node;
        }

		public void SetParentID( int id )
		{
			this.m_iParentID = id;
		}

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <returns></returns>
        public BNode GetParent()
        {
            return this.m_cParent;
        }

		/// <summary>
		/// Gets the parent I.
		/// </summary>
		/// <returns>The parent I.</returns>
		public int GetParentID()
		{
			return this.m_iParentID;
		}

        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <returns></returns>
        public List<BNode> GetNodeList()
        {
            return this.m_lstChildren;
        }

		public List<int> GetChildrenIDList()
		{
			return this.m_lstChildrenID;
		}

        /// <summary>
        /// 获取子节点个数
        /// </summary>
        /// <returns></returns>
        public int GetChildCount()
        {
            return this.m_lstChildren.Count;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public virtual bool Excute( BInput input )
        {
            return true;
        }

        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="node"></param>
        public virtual void AddChild(BNode node)
        {
            this.m_lstChildren.Add(node);
        }

		/// <summary>
		/// Adds the child.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddChild( int id )
		{
			this.m_lstChildrenID.Add(id);
		}

        /// <summary>
        /// 交换子节点
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public virtual void SwapChild(int index1, int index2)
        {
            if (this.m_lstChildren.Count <= index1 || this.m_lstChildren.Count <= index2 || index1 < 0 || index2 < 0)
            {
                return;
            }

            BNode node = this.m_lstChildren[index1];
            this.m_lstChildren[index1] = this.m_lstChildren[index2];
            this.m_lstChildren[index2] = this.m_lstChildren[index1];

			this.m_lstChildrenID[index1] = this.m_lstChildrenID[index2];
			this.m_lstChildrenID[index2] = this.m_lstChildrenID[index1];
		}
		
        /// <summary>
        /// Removes the child.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public virtual void RemoveChild(int id)
        {
			for(int i = 0 ; i<this.m_lstChildrenID.Count ; i++)
			{
				if( this.m_lstChildrenID[i] == id )
				{
					this.m_lstChildrenID.RemoveAt(i);
					return;
				}
			}
        }
    }
}

using System.Collections;
using System.Collections.Generic;



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
//        protected NODE_TYPE m_eNodeType;    //节点类型
//        protected int m_iTypeID;    //类型ID
        protected BNode m_cParent;  //父节点
        protected List<BNode> m_lstChildren = new List<BNode>();   //子节点

		public virtual void DrawGUI(int x , int y)
		{
			//
		}

        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="node"></param>
        public void SetParent(BNode node)
        {
            this.m_cParent = node;
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
        /// 获取子节点列表
        /// </summary>
        /// <returns></returns>
        public List<BNode> GetNodeList()
        {
            return this.m_lstChildren;
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
        }
        
        /// <summary>
        /// 删除子节点
        /// </summary>
        /// <param name="index"></param>
        public virtual void RemoveChild(int index)
        {
            if (this.m_lstChildren.Count <= index || index < 0 )
            {
                return;
            }
            this.m_lstChildren.RemoveAt(index);
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public virtual void Read( List<string> lst ,ref int index)
        {
//            this.m_eNodeType = (NODE_TYPE)(int.Parse(lst[index++]));
//            this.m_iTypeID = int.Parse(lst[index++]);
//            int count = int.Parse(lst[index++]);
//            for (int i = 0; i < count; i++)
//            {
//                //
//            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="lst"></param>
        public virtual void Write(List<string> lst) { }
    }
}

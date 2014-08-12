using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

//  BTree.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 行为树
    /// </summary>
    public class BTree
    {
        public int m_iID;  //ID
        public string m_strDesc;   //描述
        public BNode m_cRootNode;  //根节点
		public List<BNode> m_lstNode = new List<BNode>();

        public BTree()
        {
            this.m_strDesc = "";
            this.m_cRootNode = null;
        }

		public BNode GetNode( int id )
		{
			foreach( BNode item in this.m_lstNode )
			{
				if(item.GetID() == id )
					return item;
			}
			return null;
		}

        /// <summary>
		/// 读取数据
        /// </summary>
		public void Read( BinaryReader br )
        { 
			this.m_iID = br.ReadInt32();
			this.m_strDesc = br.ReadString();
			int count = br.ReadInt32();
			for(int i = 0 ; i<count ; i++)
			{
				int typeid = br.ReadInt32();
				BNode node = BNodeFactory.sInstance.Create(typeid);
				node.Read(br);
				this.m_lstNode.Add(node);
			}
			foreach( BNode item in this.m_lstNode )
			{
				BNode node = GetNode(item.GetParentID());
				item.SetParent(node);
				foreach( int child_id in item.GetChildrenIDList() )
				{
					node = GetNode(child_id);
					if(node == null) Debug.LogError("The node is null.");
					item.AddChild(node);
				}
			}
        }
    }
}

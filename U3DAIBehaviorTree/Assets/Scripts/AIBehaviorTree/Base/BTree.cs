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

        public BTree()
        {
            this.m_strDesc = "";
            this.m_cRootNode = null;
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        public void Write()
        { 
            //
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public void Read()
        { 
            //
        }
    }
}

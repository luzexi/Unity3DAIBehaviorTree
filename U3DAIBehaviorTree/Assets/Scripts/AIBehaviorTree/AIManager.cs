using System.Collections;
using System.Collections.Generic;

//  AIManager.cs
//  Author: Lu Zexi
//  2014-06-07



namespace Game.AIBehaviorTree
{
    /// <summary>
    /// AI管理类
    /// </summary>
    public class AIManager
    {
        private static Dictionary<int, BTree> m_mapBTree = new Dictionary<int, BTree>();   //行为树集合

        /// <summary>
        /// 新增行为树
        /// </summary>
        public void IncBTree()
        {
            for (int i = 1; ; i++)
            {
                if (!m_mapBTree.ContainsKey(i))
                {
                    BTree bTree = new BTree();
                    bTree.m_iID = i;
                    m_mapBTree.Add(i, bTree);
                    return;
                }
            }
        }

        /// <summary>
        /// 删除行为树
        /// </summary>
        /// <param name="id"></param>
        public void RemoveBTree( int id )
        {
            if (m_mapBTree.ContainsKey(id))
                m_mapBTree.Remove(id);
        }

        /// <summary>
        /// 获取行为树
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BTree GetBTree( int id )
        {
            if (m_mapBTree.ContainsKey(id))
                return m_mapBTree[id];
            return null;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void Save()
        { 
            //
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void Load()
        { 
            //
        }
    }
}

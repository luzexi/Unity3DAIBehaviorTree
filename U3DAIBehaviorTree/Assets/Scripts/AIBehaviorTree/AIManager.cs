//using UnityEngine;
//using System;
//using System.IO;
//using System.Collections;
//using System.Collections.Generic;
//
////  AIManager.cs
////  Author: Lu Zexi
////  2014-06-07
//
//
//
//namespace Game.AIBehaviorTree
//{
//    /// <summary>
//    /// AI管理类
//    /// </summary>
//    public class AIManager
//    {
//		private static AIManager s_cInstance;
//		public static AIManager sInstance
//		{
//			get
//			{
//				if(s_cInstance == null)
//				{
//					s_cInstance = new AIManager();
//				}
//				return s_cInstance;
//			}
//		}
//
//        private Dictionary<int, BTree> m_mapBTree = new Dictionary<int, BTree>();   //行为树集合
//
//        /// <summary>
//        /// 删除行为树
//        /// </summary>
//        /// <param name="id"></param>
//        public void RemoveBTree( int id )
//        {
//            if (m_mapBTree.ContainsKey(id))
//                m_mapBTree.Remove(id);
//        }
//
//        /// <summary>
//        /// 获取行为树
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public BTree GetBTree( int id )
//        {
//            if (m_mapBTree.ContainsKey(id))
//                return m_mapBTree[id];
//            return null;
//        }
//
//        /// <summary>
//        /// 加载数据
//        /// </summary>
//        public void Load( byte[] data )
//        { 
//			BinaryReader br = new BinaryReader( new MemoryStream(data));
//			int count = br.ReadInt32();
//			this.m_mapBTree.Clear();
//			for(int i = 0 ; i<count ; i++)
//			{
//				BTree tree = new BTree();
//				tree.Read(br);
//				this.m_mapBTree.Add(tree.m_iID , tree);
//			}
//        }
//    }
//}

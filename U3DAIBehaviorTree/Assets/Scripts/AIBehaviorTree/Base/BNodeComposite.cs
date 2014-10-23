using System.Collections;
using System.Collections.Generic;


//  BNodeComposite.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 混合节点
    /// </summary>
    public class BNodeComposite : BNode
    {
		public BNodeComposite()
			:base()
		{
			this.m_strName = "Composite";
		}
    }
}

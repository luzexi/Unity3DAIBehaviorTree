using System.Collections;
using System.Collections.Generic;


//  BNodeCondition.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 条件节点
    /// </summary>
    public class BNodeCondition : BNode
    {
		public BNodeCondition()
			:base()
		{
			this.m_strName = "Condition";
		}
    }
}

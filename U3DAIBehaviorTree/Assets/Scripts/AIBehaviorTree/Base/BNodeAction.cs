using System.Collections;
using System.Collections.Generic;


//  BNodeAction.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 执行节点
    /// </summary>
    public class BNodeAction : BNode
    {
		public BNodeAction()
			:base()
		{
			this.m_strName = "Action";
		}

//		public CustomAction m_cAction;	//action

    }
}

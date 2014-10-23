using System.Collections;
using System.Collections.Generic;


//  BNodeDecorator.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 修饰节点
    /// </summary>
    public class BNodeDecorator : BNode
    {
		public BNodeDecorator()
			:base()
		{
			this.m_strName = "Decorator";
		}
    }
}

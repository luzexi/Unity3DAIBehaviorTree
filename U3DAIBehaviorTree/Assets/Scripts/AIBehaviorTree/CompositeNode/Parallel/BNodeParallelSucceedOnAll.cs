using System.Collections;
using System.Collections.Generic;


//  BNodeParallelSucceeOnAll.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 平行全Succee节点
    /// </summary>
    public class BNodeParallelSucceeOnAll : BNodeParallel
    {
		/// <summary>
		/// 执行
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public override bool Excute(BInput input)
		{
			bool result = true;
			for (int i = 0 ; i < this.m_lstChildren.Count ; i++)
			{
				if( !this.m_lstChildren[i].Excute(input) )
				{
					result = false;
				}
			}
			return result;
		}
    }
}

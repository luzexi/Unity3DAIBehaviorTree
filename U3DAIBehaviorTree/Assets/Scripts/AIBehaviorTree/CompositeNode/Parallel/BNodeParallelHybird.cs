using System.Collections;
using System.Collections.Generic;


//  BNodeParallelHybird.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 平行指定比较数量节点
    /// </summary>
    public class BNodeParallelHybird : BNodeParallel
    {
        private bool m_bValue;    //比较值
        private int m_iNum; //数量

		/// <summary>
		/// 执行
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public override bool Excute(BInput input)
		{
			int trueNum = 0;
			for (int i = 0 ; i < this.m_lstChildren.Count ; i++)
			{
				if( this.m_lstChildren[i].Excute(input) )
				{
					trueNum++;
				}
			}
			if(m_bValue)
			{
				if( trueNum >= this.m_iNum )
					return true;
			}
			else
			{
				if( (this.m_lstChildren.Count - trueNum) >= this.m_iNum )
					return true;
			}
			return false;
		}
    }
}

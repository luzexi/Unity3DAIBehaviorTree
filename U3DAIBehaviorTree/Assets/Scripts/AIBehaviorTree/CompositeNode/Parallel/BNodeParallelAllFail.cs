using System.Collections;
using System.Collections.Generic;


//  BNodeParallelFallOnAll.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 平行全FALL节点
    /// </summary>
    public class BNodeParallelAllFail : BNodeParallel
    {
		private int m_iRunningIndex;	//running index
		private ActionResult m_eResult;		//result

		public BNodeParallelAllFail()
			:base()
		{
			this.m_strName = "ParallelAllFail";
		}

		//onenter
		public override void OnEnter (BInput input)
		{
			this.m_iRunningIndex = 0;
			this.m_eResult = ActionResult.SUCCESS;
		}

		/// <summary>
		/// 执行
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public override ActionResult Excute(BInput input)
		{
			if(this.m_iRunningIndex >= this.m_lstChildren.Count)
			{
				return this.m_eResult;
			}

			ActionResult result = this.m_lstChildren[this.m_iRunningIndex].RunNode(input);
			if(result == ActionResult.SUCCESS)
			{
				this.m_eResult = ActionResult.FAILURE;
			}
			if(result != ActionResult.RUNNING)
				this.m_iRunningIndex++;

			return ActionResult.RUNNING;
		}
    }
}

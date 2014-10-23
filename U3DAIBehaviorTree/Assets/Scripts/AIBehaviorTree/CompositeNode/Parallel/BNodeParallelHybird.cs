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
        public bool SuccessOrFailure;    //比较值
		public int Num; //数量

		private int m_iRunningIndex;	//running
		private int m_iSuccessNum;	//success num

		public BNodeParallelHybird()
			:base()
		{
			this.m_strName = "ParallelHybird";
		}

		//onenter
		public override void OnEnter (BInput input)
		{
			this.m_iRunningIndex = 0;
			this.m_iSuccessNum = 0;
		}

		/// <summary>
		/// 执行
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public override ActionResult Excute(BInput input)
		{
			if( this.m_iRunningIndex >= this.m_lstChildren.Count)
			{
				if(this.SuccessOrFailure)
				{
					if( this.Num <= this.m_iSuccessNum)
						return ActionResult.SUCCESS;
				}
				else
				{
					if( this.Num <= (this.m_lstChildren.Count - this.m_iSuccessNum))
						return ActionResult.SUCCESS;
				}
				return ActionResult.FAILURE;
			}

			ActionResult res = this.m_lstChildren[this.m_iRunningIndex].RunNode(input);
			if(res == ActionResult.SUCCESS)
				this.m_iSuccessNum++;

			if(res != ActionResult.RUNNING)
				this.m_iRunningIndex++;

			return ActionResult.RUNNING;
		}
    }
}

using UnityEngine;
using System.Collections;

//	BNodeIterator.cs
//	Author: Lu Zexi
//	2014-10-23



namespace Game.AIBehaviorTree
{
	//iterator
	public class BNodeIterator : BNodeComposite
	{
		public int Num;

		private int m_iRunningIndex;
		private int m_iRunningNum;

		public BNodeIterator()
			:base()
		{
			this.m_strName = "Iterator";
		}

		//onenter
		public override void OnEnter (BInput input)
		{
			this.m_iRunningIndex = 0;
			this.m_iRunningNum = 0;
		}

		//exceute
		public override ActionResult Excute (BInput input)
		{
			if(this.m_iRunningIndex >= this.m_lstChildren.Count)
			{
				return ActionResult.FAILURE;
			}

			ActionResult res = this.m_lstChildren[this.m_iRunningIndex].RunNode(input);

			if(res == ActionResult.FAILURE)
				return ActionResult.FAILURE;

			if(res == ActionResult.SUCCESS)
			{
				this.m_iRunningIndex++;
				this.m_iRunningNum++;
			}

			if(this.m_iRunningNum >= this.Num)
				return ActionResult.SUCCESS;

			return ActionResult.RUNNING;
		}
	}

}


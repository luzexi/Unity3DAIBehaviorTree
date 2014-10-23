using UnityEngine;
using System.Collections;

//	BNodeRandom.cs
//	Author: Lu Zexi
//	2014-10-23


namespace Game.AIBehaviorTree
{
	//random
	public class BNodeRandom : BNodeComposite
	{
		private int m_iRunningIndex;

		public BNodeRandom()
			:base()
		{
			this.m_strName = "Random";
		}

		public override void OnEnter (BInput input)
		{
			this.m_iRunningIndex = Random.Range(0,this.m_lstChildren.Count);
			base.OnEnter (input);
		}

		//excute
		public override ActionResult Excute (BInput input)
		{
			return this.m_lstChildren[this.m_iRunningIndex].RunNode(input);
		}
	}

}
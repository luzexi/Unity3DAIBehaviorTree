using UnityEngine;
using System.Collections;


namespace Game.AIBehaviorTree
{

	public class ConditionMp : BNodeCondition
	{
		public int MP;

		public ConditionMp()
			:base()
		{
			this.m_strName = "ConditionMp";
		}

		public override void OnEnter (BInput input)
		{
			Debug.Log((input as TestInput).mp + " -- mp");
		}

		public override ActionResult Excute (BInput input)
		{
			TestInput tinput = input as TestInput;
			if(tinput.mp >= this.MP)
			{
				return ActionResult.SUCCESS;
			}
			return ActionResult.FAILURE;
		}
	}

}
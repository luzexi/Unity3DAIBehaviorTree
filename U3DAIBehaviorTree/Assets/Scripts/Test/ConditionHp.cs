using UnityEngine;
using System.Collections;


namespace Game.AIBehaviorTree
{
	public class ConditionHp : BNodeCondition
	{
		public int HP;

		public ConditionHp()
			:base()
		{
			this.m_strName = "ConditionHp";
		}

		public override void OnEnter (BInput input)
		{
			Debug.Log((input as TestInput).hp + " -- hp");
		}

		public override ActionResult Excute (BInput input)
		{
			TestInput tinput = input as TestInput;
			if(tinput.hp >= this.HP)
			{
				return ActionResult.SUCCESS;
			}

			return ActionResult.FAILURE;
		}
	}
}
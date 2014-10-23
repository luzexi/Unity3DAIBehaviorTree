using UnityEngine;
using System.Collections;


//	ConditionHp.cs
//	Author: Lu Zexi
//	2014-10-23


namespace Game.AIBehaviorTree
{
	//condition hp debug
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
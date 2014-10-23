using UnityEngine;
using System.Collections;

//	ActionAttack.cs
//	Author: Lu Zexi
//	2014-10-23


namespace Game.AIBehaviorTree
{
	//attack action
	public class ActionAttack : BNodeAction
	{
		private bool over;
		private float m_ftime;

		public ActionAttack()
			:base()
		{
			this.m_strName = "Attack";
		}

		public override void OnEnter (BInput input)
		{
			TestInput tinput = input as TestInput;
			tinput.hp -= 20;
			this.m_ftime = Time.time;
			this.over = false;
			Debug.Log("attack");
		}

		//excute
		public override ActionResult Excute (BInput input)
		{
			if(Time.time - this.m_ftime > 2f)
				this.over = true;
			if(this.over)
				return ActionResult.SUCCESS;
			return ActionResult.RUNNING;
		}
	}

}
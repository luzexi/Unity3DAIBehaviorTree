using UnityEngine;
using System.Collections;

namespace Game.AIBehaviorTree
{

	public class ActionSkill : BNodeAction
	{
		private bool over = false;
		private float m_ftime;

		public ActionSkill()
			:base()
		{
			this.m_strName = "Skill";
		}

		public override void OnEnter (BInput input)
		{
			Debug.Log("use skill");
			this.over = false;
			this.m_ftime = Time.time;
			TestInput tinput = input as TestInput;
			tinput.mp -= 50;
		}

		public override ActionResult Excute (BInput input)
		{
			if( Time.time - this.m_ftime > 2f)
				this.over = true;

			if(this.over)
				return ActionResult.SUCCESS;
			return ActionResult.RUNNING;
		}
	}
}
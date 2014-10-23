using UnityEngine;
using System.Collections;




namespace Game.AIBehaviorTree
{
	//go home
	public class ActionGoHome : BNodeAction
	{
		private bool over = false;
		private float m_ftime;

		public ActionGoHome()
			:base()
		{
			this.m_strName = "GoHome";
		}

		public override void OnEnter (BInput input)
		{
			this.over = false;
			this.m_ftime = Time.time;

			Debug.Log("on home");
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
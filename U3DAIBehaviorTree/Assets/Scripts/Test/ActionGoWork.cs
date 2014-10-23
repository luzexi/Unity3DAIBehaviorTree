using UnityEngine;
using System.Collections;

//	ActionGoWork.cs
//	Author: Lu Zexi
//	2014-10-23


namespace Game.AIBehaviorTree
{
	//go work debug
	public class ActionGoWork : BNodeAction
	{
		private bool over = false;
		private float m_ftime;

		public ActionGoWork()
			:base()
		{
			this.m_strName = "GoWork";
		}

		public override void OnEnter (BInput input)
		{
			this.over = false;
			this.m_ftime = Time.time;
			Debug.Log("go work");
		}

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
using UnityEngine;
using System.Collections;

//	ActionMoveRound.cs
//	Author: Lu Zexi
//	2014-10-23

namespace Game.AIBehaviorTree
{
	//move round debug
	public class ActionMoveRound : BNodeAction
	{
		private bool over = false;
		private float m_ftime;

		public ActionMoveRound()
			:base()
		{
			this.m_strName = "MoveRound";
		}

		public override void OnEnter (BInput input)
		{
			this.over = false;
			this.m_ftime = Time.time;
			Debug.Log("move round");
		}

		public override ActionResult Excute (BInput input)
		{
			if(Time.time-this.m_ftime > 2f)
				this.over = true;

			if(this.over)
				return ActionResult.SUCCESS;
			return ActionResult.RUNNING;
		}
	}

}
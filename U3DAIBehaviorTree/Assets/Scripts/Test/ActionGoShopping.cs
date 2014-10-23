using UnityEngine;
using System.Collections;

//	ActionGoShopping.cs
//	Author: Lu Zexi
//	2014-10-23

namespace Game.AIBehaviorTree
{
	//go shopping debug
	public class ActionGoShopping : BNodeAction
	{
		private bool over = false;
		private float m_ftime;

		public ActionGoShopping()
			:base()
		{
			this.m_strName = "GoShopping";
		}

		public override void OnEnter (BInput input)
		{
			this.over = false;
			this.m_ftime = Time.time;
			Debug.Log("go shopping");
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
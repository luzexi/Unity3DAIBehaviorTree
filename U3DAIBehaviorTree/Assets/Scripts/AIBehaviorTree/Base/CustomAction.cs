using System;
using UnityEngine;
using System.Collections;

//	CustomAction.cs
//	Author: Lu Zexi
//	2014-10-22



namespace Game.AIBehaviorTree
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class CustomActionAttribute : Attribute
	{
		public readonly string nodeName;

		public CustomActionAttribute(){this.nodeName = "";}
		public CustomActionAttribute(string name){this.nodeName = name;}
	}

	//CustomAction
	public abstract class CustomAction
	{
		//enter
		public virtual void OnEnter(BInput input)
		{
			//
		}

		//excute
		public virtual ActionResult Excute(BInput input)
		{
			return ActionResult.SUCCESS;
		}

		//exit
		public virtual void OnExit(BInput input)
		{
			//
		}
	}
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//  BNodeConditionNothing.cs
//  Author: Lu Zexi
//  2014-06-07




namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 条件节点空闲
    /// </summary>
    public class BNodeConditionNothing : BNodeCondition
    {
		public int m_iTest;
		public float m_fTest;
		public bool m_bTest;
		public string m_strTest="";

		public BNodeConditionNothing()
			:base()
		{
			this.m_strName = "condition";
		}

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public override ActionResult Excute(BInput input)
        {
			return ActionResult.SUCCESS;
        }

//		/// <summary>
//		/// Draw the GUI.
//		/// </summary>
//		/// <param name="x">The x coordinate.</param>
//		/// <param name="y">The y coordinate.</param>
//		public override void DrawGUI(int x , int y)
//		{
//			try
//			{
//				GUI.Label(new Rect(x,y,100,30) ,"test condition");
//				y+=30;
//				string tmpint = "" + this.m_iTest;
//				tmpint = GUI.TextField(new Rect(x,y,100,30) , tmpint);
//				this.m_iTest = int.Parse(tmpint);
//			}
//			catch( Exception ex )
//			{
//				Debug.Log(ex.StackTrace);
//			}
//
//		}
    }
}

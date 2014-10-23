using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//  BNodeActionNothing.cs
//  Author: Lu Zexi
//  2014-06-07



namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 执行节点空闲
    /// </summary>
    public class BNodeActionNothing : BNodeAction
    {
		public int m_iTest;

		public BNodeActionNothing()
		{
			this.m_strName = "BNodeActionNothing";
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
//		}
    }
}

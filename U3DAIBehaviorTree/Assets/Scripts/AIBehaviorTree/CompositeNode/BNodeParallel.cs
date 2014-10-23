using System.Collections;
using System.Collections.Generic;


//  BNodeParallel.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 平行节点
    /// </summary>
    public class BNodeParallel : BNodeComposite
    {
		public BNodeParallel()
			:base()
		{
			this.m_strName = "par";
		}

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public override ActionResult Excute(BInput input)
        {
            for (int i = 0 ; i < this.m_lstChildren.Count ; i++)
            {
                this.m_lstChildren[i].Excute(input);
            }
			return ActionResult.SUCCESS;
        }
    }
}

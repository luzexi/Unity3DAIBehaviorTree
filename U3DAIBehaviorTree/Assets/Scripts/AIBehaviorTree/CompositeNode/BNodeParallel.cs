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
		private int m_iRuningIndex;	//runting index

		public BNodeParallel()
			:base()
		{
			this.m_strName = "Parallel";
		}

		//onenter
		public override void OnEnter (BInput input)
		{
			this.m_iRuningIndex = 0;
		}

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public override ActionResult Excute(BInput input)
        {
			if(this.m_iRuningIndex >= this.m_lstChildren.Count)
			{
				return ActionResult.SUCCESS;
			}
			
			BNode node = this.m_lstChildren[this.m_iRuningIndex];
			
			ActionResult res = node.RunNode(input);
			
			if(res != ActionResult.RUNNING)
			{
				this.m_iRuningIndex++;
			}
			
			return ActionResult.RUNNING;
        }
    }
}

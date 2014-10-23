using System.Collections;
using System.Collections.Generic;


//  BNodeSelector.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 选择器节点
    /// </summary>
    public class BNodeSelector : BNodeComposite
    {
		private int m_iRuningIndex;	//runing index

		public BNodeSelector()
			:base()
		{
			this.m_strName = "Selector";
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
				return ActionResult.FAILURE;
			}

			BNode node = this.m_lstChildren[this.m_iRuningIndex];

			ActionResult res = node.RunNode(input);

			if(res == ActionResult.SUCCESS)
				return ActionResult.SUCCESS;

			if(res == ActionResult.FAILURE)
			{
				this.m_iRuningIndex++;
			}
			return ActionResult.RUNNING;
        }
    }
}

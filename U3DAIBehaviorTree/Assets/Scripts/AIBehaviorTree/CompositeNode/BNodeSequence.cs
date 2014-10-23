using System.Collections;
using System.Collections.Generic;


//  BNodeSequence.cs
//  Author: Lu Zexi
//  2014-06-07


namespace Game.AIBehaviorTree
{
    /// <summary>
    /// 顺序节点
    /// </summary>
    public class BNodeSequence : BNodeComposite
    {
		private int m_iRuningIndex;

		public BNodeSequence()
			:base()
		{
			this.m_strName = "Sequence";
		}

		//on enter
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

			if(res == ActionResult.FAILURE)
				return ActionResult.FAILURE;

			if(res == ActionResult.SUCCESS)
			{
				this.m_iRuningIndex++;
			}

			return ActionResult.RUNNING;
        }
    }
}

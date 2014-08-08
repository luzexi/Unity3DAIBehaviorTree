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
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override bool Excute(BInput input)
        {
            return true;
        }
    }
}

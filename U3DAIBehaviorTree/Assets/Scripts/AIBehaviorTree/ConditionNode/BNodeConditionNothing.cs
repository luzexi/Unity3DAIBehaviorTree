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

Unity3DAIBehaviorTree
=====================

专为Unity3D打造的AI行为树,包括ai编辑器<br>
更多内容请关注: http://www.luzexi.com<br>

<br>
![github](https://github.com/luzexi/Unity3DAIBehaviorTree/blob/master/img.png "编辑器")
<br>

 行为树(Behavior Tree)具有如下的特性：<br>
<br>
它只有4大类型的Node：<br>
* Composite Node<br>
* Decorator Node<br>
* Condition Node<br>
* Action Node<br>
<br>
任何Node被执行后，必须向其Parent Node报告执行结果：成功 / 失败。<br>
这简单的成功 / 失败汇报原则被很巧妙地用于控制整棵树的决策方向。<br>
<br>
———————————————————————<br>
<br>
先看Composite Node，其实它按复合性质还可以细分为3种：<br>
* Selector Node<br>
当执行本类型Node时，它将从begin到end迭代执行自己的Child Node：<br>
如遇到一个Child Node执行后返回True，那停止迭代，<br>
本Node向自己的Parent Node也返回True；否则所有Child Node都返回False，<br>
那本Node向自己的Parent Node返回False。<br>
<br>
* Sequence Node<br>
当执行本类型Node时，它将从begin到end迭代执行自己的Child Node：<br>
如遇到一个Child Node执行后返回False，那停止迭代，<br>
本Node向自己的Parent Node也返回False；否则所有Child Node都返回True，<br>
那本Node向自己的Parent Node返回True。<br>
<br>
* Parallel Node<br>
并发执行它的所有Child Node。<br>
而向Parent Node返回的值和Parallel Node所采取的具体策略相关：<br>
Parallel Selector Node: 一False则返回False，全True才返回True。<br>
Parallel Sequence Node: 一True则返回True，全False才返回False。<br>
Parallel Hybird Node: 指定数量的Child Node返回True或False后才决定结果。<br>
<br>
Parallel Node提供了并发，提高性能。<br>
不需要像Selector/Sequence那样预判哪个Child Node应摆前，哪个应摆后，<br>
常见情况是：<br>
(1)用于并行多棵Action子树。<br>
(2)在Parallel Node下挂一棵子树，并挂上多个Condition Node，<br>
以提供实时性和性能。<br>
Parallel Node增加性能和方便性的同时，也增加实现和维护复杂度。<br>
<br>
PS：上面的Selector/Sequence准确来说是Liner Selector/Liner Sequence。<br>
AI术语中称为strictly-order：按既定先后顺序迭代。<br>
<br>
Selector和Sequence可以进一步提供非线性迭代的加权随机变种。<br>
Weight Random Selector提供每次执行不同的First True Child Node的可能。<br>
Weight Random Sequence则提供每次不同的迭代顺序。<br>
AI术语中称为partial-order，能使AI避免总出现可预期的结果。<br>
<br>
———————————————————————<br>
<br>
再看Decorator Node，它的功能正如它的字面意思：它将它的Child Node执行<br>
后返回的结果值做额外处理后，再返回给它的Parent Node。很有些AOP的味道。<br>
<br>
比如Decorator Not/Decorator FailUtil/Decorator Counter/Decorator Time…<br>
更geek的有Decorator Log/Decorator Ani/Decorator Nothing…<br>
<br>
———————————————————————<br>
<br>
然后是很直白的Condition Node，它仅当满足Condition时返回True。<br>
<br>
———————————————————————<br>
<br>
最后看Action Node，它完成具体的一次(或一个step)的行为，视需求返回值。<br>
而当行为需要分step/Node间进行时，可引入Blackboard进行简单数据交互。<br>
<br>
———————————————————————<br>
<br>
整棵行为树中，只有Condition Node和Action Node才能成为Leaf Node，而也<br>
只有Leaf Node才是需要特别定制的Node；Composite Node和Decorator Node均<br>
用于控制行为树中的决策走向。(所以有些资料中也统称Condition Node和Action<br>
Node为Behavior Node，而Composite Node和Decorator Node为Decider Node。)<br>
<br>
更强大的是可以加入Stimulus和Impulse，通过Precondition来判断masks开关。<br>
<br>
通过上述的各种Nodes几乎可以实现所有的决策控制：if, while, and, or,<br>
not, counter, time, random, weight random, util…<br>
<br>
——————————————————————— <br>

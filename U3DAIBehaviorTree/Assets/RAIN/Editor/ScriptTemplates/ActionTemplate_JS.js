import RAIN.Core;
import RAIN.Action;

@RAINAction
class ActionTemplate_JS extends RAIN.Action.RAINAction
{
	function Start(ai:AI):void
	{
        super.Start(ai);
	}

	function Execute(ai:AI):ActionResult
	{
        return ActionResult.SUCCESS;
	}

   	function Stop(ai:AI):void
	{
        super.Stop(ai);
	}
}
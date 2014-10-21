import RAIN.Action
import RAIN.Core

[RAINAction]
class ActionTemplate_BOO(RAINAction): 
	def Start(ai as AI):
		super.Start(ai)
		return
	
	def Execute(ai as AI):
		return ActionResult.SUCCESS

	def Stop(ai as AI):
		super.Stop(ai)
		return
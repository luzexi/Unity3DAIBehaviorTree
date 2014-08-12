using UnityEngine;
using System.IO;
using System.Collections;
using Game.AIBehaviorTree;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0,100,40),"button"))
		{
			TextAsset ta = Resources.Load("tree2") as TextAsset;
			if(ta == null)
				Debug.Log("null.");
			Debug.Log(ta.bytes.Length);
			AIManager.sInstance.Load(ta.bytes);
//			byte[] data = File.ReadAllBytes(Application.dataPath + "/Resources/tree2.bytes");
//			Debug.Log(data.Length);
//			AIManager.sInstance.Load(data);
		}
	}
}

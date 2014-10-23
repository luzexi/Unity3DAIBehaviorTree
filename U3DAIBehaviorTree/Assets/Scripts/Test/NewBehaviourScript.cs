using UnityEngine;
using System.IO;
using System.Collections;
using Game.AIBehaviorTree;


//	NewBehaviourScript.cs
//	Author: Lu Zexi
//	2014-10-23


//test script
public class NewBehaviourScript : MonoBehaviour {

	public TextAsset text;

	private BTree tree;

	private TestInput input;

	// Use this for initialization
	void Start ()
	{
		this.input = new TestInput();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(tree != null)
			tree.Run(this.input);
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0,100,40),"load"))
		{
			BTreeMgr.sInstance.Load(text.text);
			this.tree = BTreeMgr.sInstance.GetTree("test_tree");
		}
	}
}

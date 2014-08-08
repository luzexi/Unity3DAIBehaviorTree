using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EWin : EditorWindow
{
	public static EditorBTree cur_tree;	//current tree
	public static EditorBNode cur_node;	//current node
	private static int cur_tree_index = -1;
	private static int last_tree_index = -1;

	public static EditorBNode SelectStart;

	//
	private Rect rect = new Rect(100,100,100,100);
	private Vector2 m_cScrollPos;
	private string m_strInputName = "";

	[@MenuItem("ai/ewin")]
	static void init()
	{
		EWin ewin = (EWin)EditorWindow.GetWindow(typeof(EWin));
	}

	void OnGUI()
	{
		//////////////////// draw the tree /////////////////////
		this.m_cScrollPos = GUI.BeginScrollView(new Rect(0,0,position.width , position.height) , this.m_cScrollPos , new Rect(0,0,this.maxSize.x,this.maxSize.y));
		
		BeginWindows();
		if(cur_tree != null )
		{
			foreach( EditorBNode item in cur_tree.m_lstNode )
			{
				item.Draw();
			}
		}
		EndWindows();
		
		if(SelectStart != null )
		{
			Vector3 sPos = new Vector3(SelectStart.m_cRect.x + SelectStart.m_cRect.width , SelectStart.m_cRect.y + SelectStart.m_cRect.height/2f , 0);
			Vector3 ePos = new Vector3(Event.current.mousePosition.x , Event.current.mousePosition.y,0);
			Handles.color = Color.blue;
			Handles.DrawAAPolyLine(4,new Vector3[]{sPos , ePos});
		}
		
		GUI.EndScrollView();
		//////////////////// draw the tree /////////////////////

		//////////////////// draw editor gui /////////////////////
		GUI.BeginGroup(new Rect(0,0,200,500));
		int x = 0;
		int y = 0;
		List<EditorBTree> lst = EditorBTreeMgr.sInstance.GetTrees();
		if(GUI.Button(new Rect(x,y,200,40),"Finish"))
		{
			//
		}
		y+=40;
		if(GUI.Button(new Rect(x,y,200,40),"Editor"))
		{
			//
		}
		y+=45;

		this.m_strInputName = GUI.TextField(new Rect(x,y+10,100,20), this.m_strInputName);
		if( GUI.Button(new Rect(x+100,y,100,40) , "create tree"))
		{
			if(this.m_strInputName != "")
			{
				cur_node = null;
				EditorBTree tree = new EditorBTree();
				tree.m_strDesc = this.m_strInputName + "_" + tree.m_iID;
				EditorBTreeMgr.sInstance.Add(tree);
				lst = EditorBTreeMgr.sInstance.GetTrees();
				cur_tree = tree;
				for(int i = 0 ; i<lst.Count ; i++ )
				{
					if(lst[i].m_iID == tree.m_iID)
					{
						cur_tree_index = i;
						break;
					}
				}
				last_tree_index = cur_tree_index;
				Repaint();
			}
		}
		y+=40;
		if(GUI.Button(new Rect(x,y,200,40), "remove tree"))
		{
			cur_node = null;
			EditorBTreeMgr.sInstance.Remove(cur_tree);
			lst = EditorBTreeMgr.sInstance.GetTrees();
			cur_tree = null;
			cur_tree_index = -1;
			last_tree_index = -1;
			Repaint();
		}
		y+=45;

		string[] treeNames = new string[lst.Count];
		for(int i = 0 ; i<lst.Count ; i++ )
		{
			treeNames[i] = lst[i].m_strDesc;
		}
		cur_tree_index = EditorGUI.Popup(new Rect(x,y,200,45),cur_tree_index,treeNames);
		if(cur_tree_index != last_tree_index)
		{
			last_tree_index = cur_tree_index;
			cur_tree = lst[cur_tree_index];
			cur_node = null;
		}
		y+=45;
		if(GUI.Button(new Rect(x,y,200,40),"create node"))
		{
			EditorBNode node = new EditorBNode("node");
			if(cur_tree != null )
				cur_tree.Add(node);
		}
		y+=40;
		if(GUI.Button(new Rect(x,y,200,40),"clear"))
		{
			if(cur_tree != null )
				cur_tree.Clear();
			SelectStart = null;
		}
		y+=40;

		if(cur_node != null )
		{
			cur_node.m_cNode.DrawGUI(x,y);
		}
		//
		GUI.EndGroup();
		//////////////////// draw editor gui /////////////////////
	}

	//void OnInspectorUpdate()
	void Update()
	{
		//
		Repaint();
	}
}

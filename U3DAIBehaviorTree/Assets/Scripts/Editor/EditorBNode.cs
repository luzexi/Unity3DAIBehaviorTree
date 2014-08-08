using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Game.AIBehaviorTree;


//	EditorBNode.cs
//	Author: Lu Zexi
//	2014-08-07



/// <summary>
/// Editor B node.
/// </summary>
public class EditorBNode
{
	static int MAX_ID;	//MAX ID
	public int m_iID;	//ID

	public string m_strName;	//name
	public NODE_TYPE m_eNodeType;    //节点类型
	public int m_iTypeID;    //类型ID
	public EditorBNode m_cParent;  //父节点
	public List<EditorBNode> m_lstChildren = new List<EditorBNode>();   //子节点

	//
	public Rect m_cRect = new Rect(500,100,100,150);	//pos
	public bool m_bLink = false;	//link

	public EditorBNode(string name)
	{
		this.m_strName = name;
		m_iID = MAX_ID++;
	}

	public void RemoveChild( EditorBNode node )
	{
		this.m_lstChildren.Remove(node);
	}
	public void AddChild( EditorBNode node )
	{
		this.m_lstChildren.Add(node);
	}
	public bool ContainChild(EditorBNode node)
	{
		return this.m_lstChildren.Contains(node);
	}

	public virtual void Draw()
	{
		//draw self
		this.m_cRect = GUI.Window(this.m_iID,this.m_cRect , onWindows ,this.m_strName);
		if(this.m_cParent != null )
		{
			Vector3 posStart = new Vector3(this.m_cRect.x + this.m_cRect.width/2f  , this.m_cRect.y ,0);
			Vector3 posEnd = new Vector3(this.m_cParent.m_cRect.x + this.m_cParent.m_cRect.width/2f , this.m_cParent.m_cRect.y + this.m_cRect.height , 0);

			Handles.color = Color.red;
			//Handles.ConeCap(0 , (posStart + posEnd)/2f , Quaternion.LookRotation((posStart-posEnd)) , 15);
			Vector3 pos1 = (posStart + posEnd)/2f + (posStart-posEnd).normalized * 8.7f;
			Vector3 pos2 = (posStart + posEnd)/2f + Vector3.Cross((posStart-posEnd),Vector3.forward).normalized * 5;
			Vector3 pos3 = (posStart + posEnd)/2f + Vector3.Cross((posStart-posEnd),Vector3.forward).normalized * -5;
			Handles.DrawAAPolyLine(4,new Vector3[]{pos1,pos2,pos3,pos1});
			Handles.color = Color.red;
			Handles.DrawAAPolyLine(4 , new Vector3[]{posStart , posEnd});
			//Handles.ArrowCap(0,posStart , Quaternion.identity , (posStart- posEnd).magnitude);
		}

		//draw children
		foreach(EditorBNode item in this.m_lstChildren)
			item.Draw();
	}

	private void onWindows(int id)
	{
		if( GUILayout.Button("link") )
		{
			if(EWin.SelectStart == null )
			{
				EWin.SelectStart = this;
			}
			else if( EWin.SelectStart == this)
			{
				EWin.SelectStart = null;
			}
			else if( !ContainChild(EWin.SelectStart) )
			{
				if(this.m_cParent != null )
				{
					this.m_cParent.RemoveChild(this);
				}
				this.m_cParent = EWin.SelectStart;
				EWin.SelectStart.RemoveChild(this);
				EWin.SelectStart.AddChild(this);
				EWin.SelectStart = null;
			}
		}
		if(GUILayout.Button("root"))
		{
			EWin.cur_tree.m_cRoot = this;
		}
		if(GUILayout.Button("edit"))
		{
			EWin.cur_node = this;
		}
		if(GUILayout.Button("delete"))
		{
			EWin.cur_tree.Remove(this);
			if( this.m_cParent != null )
			{
				this.m_cParent.RemoveChild(this);
			}
			foreach( EditorBNode item in this.m_lstChildren )
			{
				item.m_cParent = null;
			}
			this.m_lstChildren.Clear();
		}
		GUI.DragWindow();
	}
}


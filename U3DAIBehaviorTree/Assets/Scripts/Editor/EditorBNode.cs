using UnityEngine;
using UnityEditor;
using System;
using System.IO;
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

	public BNode m_cNode;	//node 
	public string m_strName;	//name
	public int m_iParentID;	//parent id
	public EditorBNode m_cParent;  //父节点
	public List<EditorBNode> m_lstChildren = new List<EditorBNode>();   //子节点
	public List<int> m_lstChildrenID = new List<int>();	//children id

	//
	public Rect m_cRect = new Rect(500,100,100,150);	//pos
	public bool m_bLink = false;	//link

	public EditorBNode()
	{
		m_iID = MAX_ID++;
	}

	public void Write( BinaryWriter bw )
	{
		bw.Write(this.m_iID);
		bw.Write(this.m_strName);
		bw.Write(this.m_cRect.x);
		bw.Write(this.m_cRect.y);
		bw.Write(this.m_cRect.width);
		bw.Write(this.m_cRect.height);
		bw.Write(this.m_iParentID);
		bw.Write(this.m_lstChildren.Count);
		foreach( int item in this.m_lstChildrenID )
		{
			bw.Write(item);
		}
		if(this.m_cNode != null )
		{
			bw.Write(this.m_cNode.GetTypeID());
			this.m_cNode.Write(bw);
		}
	}

	public void Read( BinaryReader br )
	{
		this.m_iID = br.ReadInt32();
		this.m_strName = br.ReadString();
		this.m_cRect = new Rect();
		this.m_cRect.x = br.ReadSingle();
		this.m_cRect.y = br.ReadSingle();
		this.m_cRect.width = br.ReadSingle();
		this.m_cRect.height = br.ReadSingle();
		this.m_iParentID = br.ReadInt32();
		int count = br.ReadInt32();
		for( int i = 0 ; i<count ; i++ )
		{
			int child_id = br.ReadInt32();
			this.m_lstChildrenID.Add(child_id);
		}
		int typeid = br.ReadInt32();
		this.m_cNode = BNodeFactory.sInstance.Create(typeid);
	}

	public void RemoveChild( EditorBNode node )
	{
		this.m_lstChildren.Remove(node);
		this.m_lstChildrenID.Remove(node.m_iID);
	}
	public void AddChild( EditorBNode node )
	{
		this.m_lstChildren.Add(node);
		this.m_lstChildrenID.Add(node.m_iID);
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
			Vector3 posStart = new Vector3(this.m_cParent.m_cRect.x + this.m_cParent.m_cRect.width , this.m_cParent.m_cRect.y + this.m_cRect.height/2f , 0);
			Vector3 posEnd = new Vector3(this.m_cRect.x , this.m_cRect.y + this.m_cRect.height/2f ,0);

			Handles.color = Color.red;
			//Handles.ConeCap(0 , (posStart + posEnd)/2f , Quaternion.LookRotation((posStart-posEnd)) , 15);
			Vector3 pos1 = (posStart + posEnd)/2f + (posEnd-posStart).normalized * 8.7f;
			Vector3 pos2 = (posStart + posEnd)/2f + Vector3.Cross((posEnd-posStart),Vector3.forward).normalized * 5;
			Vector3 pos3 = (posStart + posEnd)/2f + Vector3.Cross((posEnd-posStart),Vector3.forward).normalized * -5;
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
				this.m_iParentID = EWin.SelectStart.m_iID;
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
				item.m_iParentID = -1;
			}
			this.m_lstChildren.Clear();
		}
		GUI.DragWindow();
	}
}


using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Game.AIBehaviorTree;
using System.Xml;
using LitJson;


//	EditorBNode.cs
//	Author: Lu Zexi
//	2014-08-07



/// <summary>
/// Editor B node.
/// </summary>
public class EditorBNode
{
	public static int MAX_ID = 1;	//MAX ID
	public int m_iID;	//ID

	public BNode m_cNode;	//node 
	public string m_strName = "node";	//name
	public EditorBNode m_cParent;  //父节点
	public List<EditorBNode> m_lstChildren = new List<EditorBNode>();   //子节点


	public EditorBNode()
	{
		m_iID = MAX_ID++;
	}

	public void ReadJson( JsonData json )
	{
		this.m_iID = int.Parse(json["id"].ToString());
		this.m_strName = json["name"].ToString();
		int typeid = int.Parse( json["node"]["typeid"].ToString() );
		this.m_cNode = BNodeFactory.sInstance.Create(typeid);
		this.m_cNode.ReadJson(json["node"]);
		for( int i = 0 ; i<json["child"].Count ; i++ )
		{
			EditorBNode enode = new EditorBNode();
			enode.ReadJson(json["child"][i]);
			enode.m_cParent = this;
			this.AddChild(enode);
		}
		if(this.m_iID >= MAX_ID)
			MAX_ID = this.m_iID +1;
	}

	public JsonData WriteJson()
	{
		JsonData json = new JsonData();
		json["id"] = this.m_iID;
		json["name"] = this.m_strName;
		json["node"] = new JsonData();
		if(this.m_cNode != null)
		{
			this.m_cNode.WriteJson(json);
		}
		json["child"] = new JsonData();
		json["child"].SetJsonType(JsonType.Array);
		for(int i = 0 ; i<this.m_lstChildren.Count ; i++)
		{
			JsonData child = this.m_lstChildren[i].WriteJson();
			json["child"].Add(child);
		}
		return json;
	}

	public void RemoveChild( EditorBNode node )
	{
		this.m_lstChildren.Remove(node);
		this.m_cNode.RemoveChild(node.m_iID);
	}
	public void AddChild( EditorBNode node )
	{
		this.m_lstChildren.Add(node);
		this.m_cNode.AddChild(node.m_iID);
	}
	public void InsertChild( EditorBNode prenode , EditorBNode node )
	{
		int index = this.m_lstChildren.FindIndex((a)=>{return a == prenode;});
		this.m_lstChildren.Insert(index,node);
	}
	public bool ContainChild(EditorBNode node)
	{
		return this.m_lstChildren.Contains(node);
	}

	//menu add decision node
	private void menu_add_callback( object arg)
	{
		EditorBNode node = EditorBTreeMgr.sInstance.GeneratorNode((int)arg);
		this.AddChild(node);
		node.m_cParent = this;
		BTreeWin.sInstance.Repaint();
	}

	//menu delete node
	private void menu_delete_node(object arg)
	{
		if(this.m_cParent != null )
		{
			this.m_cParent.RemoveChild(this);
		}
		this.m_cParent = null;
		BTreeWin.select = null;
		BTreeWin.cur_node = null;
		BTreeWin.sInstance.Repaint();
	}

	//render
	public virtual void Render( int x ,ref int y)
	{
		Event evt = Event.current;
		if(BTreeWin.cur_node == this)
		{
			Texture2D texRed = new Texture2D(1,1);
			texRed.SetPixel(0,0,Color.blue);
			texRed.Apply();
			GUI.DrawTexture(new Rect(0,y,BTreeWin.sInstance.position.width,BTreeWin.NODE_HEIGHT), texRed);
		}

		Rect moveRect = new Rect(x,y,BTreeWin.sInstance.position.width-BTreeWin.GUI_WIDTH,5);
		bool is_move_node = false;
		if( BTreeWin.select != null && moveRect.Contains(evt.mousePosition))
		{
			is_move_node = true;
			Texture2D tex = new Texture2D(1,1);
			tex.SetPixel(0,0,Color.green);
			tex.Apply();
			GUI.DrawTexture(new Rect(x,y,BTreeWin.sInstance.position.width,2),tex);
			if(evt.button == 0 && evt.type == EventType.MouseUp)
			{
				if(this != BTreeWin.select && this.m_cParent != null)
				{
					BTreeWin.select.m_cParent.RemoveChild(BTreeWin.select);
					BTreeWin.select.m_cParent = this.m_cParent;
					this.m_cParent.InsertChild(this,BTreeWin.select);
				}
				BTreeWin.select = null;
				BTreeWin.sInstance.Repaint();
			}
		}

		Rect rect = new Rect(x,y,BTreeWin.sInstance.position.width-BTreeWin.GUI_WIDTH,BTreeWin.NODE_HEIGHT);
		if( !is_move_node && rect.Contains(evt.mousePosition) )
		{
			if(BTreeWin.select != null )
			{
				Texture2D texRed = new Texture2D(1,1);
				texRed.SetPixel(0,0,Color.red);
				texRed.Apply();
				GUI.DrawTexture(new Rect(0,y,BTreeWin.sInstance.position.width,BTreeWin.NODE_HEIGHT), texRed);
			}
			if(evt.type == EventType.ContextClick)
			{
				GenericMenu menu = new GenericMenu();
				menu.AddItem(new GUIContent("create/decisions/sequence"), false , menu_add_callback , 0);
				menu.AddItem(new GUIContent("create/decisions/selector"), false , menu_add_callback , 1);
				menu.AddItem(new GUIContent("create/decisions/parallel"), false , menu_add_callback , 2);
				menu.AddItem(new GUIContent("delete"), false , menu_delete_node ,"");
				menu.ShowAsContext();
			}
			if(evt.button == 0 && evt.type == EventType.MouseDown && this != BTreeWin.cur_tree.m_cRoot)
			{
				BTreeWin.select = this;
				BTreeWin.cur_node = this;
			}
			if(evt.button == 0 && evt.type == EventType.MouseUp && BTreeWin.select != null)
			{
				if(this != BTreeWin.select)
				{
					BTreeWin.select.m_cParent.RemoveChild(BTreeWin.select);
					BTreeWin.select.m_cParent = this;
					this.AddChild(BTreeWin.select);
				}
				BTreeWin.select = null;
				BTreeWin.sInstance.Repaint();
			}
		}
		GUI.Label(new Rect(x,y,BTreeWin.sInstance.position.width,BTreeWin.NODE_HEIGHT),this.m_strName);

		/////////////////// line //////////////////////
		Vector3 pos1 = new Vector3(x+BTreeWin.NODE_WIDTH/2,y+BTreeWin.NODE_HEIGHT,0);
		Handles.color = Color.red;
		for( int i = 0 ; i<this.m_lstChildren.Count ; i++ )
		{
			y = y+BTreeWin.NODE_HEIGHT;

			Vector3 pos2 = new Vector3(x+BTreeWin.NODE_WIDTH/2,y+BTreeWin.NODE_HEIGHT/2,0);
			Vector3 pos3 = new Vector3(x+BTreeWin.NODE_WIDTH,y+BTreeWin.NODE_HEIGHT/2,0);
			this.m_lstChildren[i].Render(x+BTreeWin.NODE_WIDTH,ref y);
			Handles.DrawPolyLine(new Vector3[]{pos1,pos2,pos3});
		}
	}
}


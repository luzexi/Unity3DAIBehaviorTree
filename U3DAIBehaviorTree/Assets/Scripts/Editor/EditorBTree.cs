using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//	EditorBTree.cs
//	Author: Lu Zexi
//	2014-08-07



/// <summary>
/// Editor Behavior tree.
/// </summary>
public class EditorBTree
{
	public static int TREE_ID = 1;

	public int m_iID;  //ID
	public string m_strDesc;   //描述
	public EditorBNode m_cRoot;	//root
	public List<EditorBNode> m_lstNode = new List<EditorBNode>();

	public EditorBTree()
	{
		this.m_iID = TREE_ID++;
	}

	public void WriteEx( BinaryWriter bw )
	{
		bw.Write(this.m_iID);
		bw.Write(this.m_strDesc);
		bw.Write(this.m_lstNode.Count);
		foreach( EditorBNode item in this.m_lstNode )
		{
			bw.Write(item.m_cNode.GetTypeID());
			item.m_cNode.Write(bw);
		}
	}

	public void Write( BinaryWriter bw )
	{
		bw.Write(this.m_iID);
		bw.Write(this.m_strDesc);
		bw.Write(this.m_lstNode.Count);
		foreach( EditorBNode item in this.m_lstNode )
		{
			item.Write(bw);
		}
	}

	public void Read( BinaryReader br )
	{
		this.m_iID = br.ReadInt32();
		this.m_strDesc = br.ReadString();
		this.m_cRoot = null;
		this.m_lstNode.Clear();
		int count = br.ReadInt32();
		for( int i = 0 ; i<count ; i++ )
		{
			EditorBNode node = new EditorBNode();
			node.Read(br);
			this.m_lstNode.Add(node);
		}
		foreach( EditorBNode item in this.m_lstNode )
		{
			EditorBNode node = GetNode(item.m_cNode.GetParentID());
			item.m_cParent = node;
			foreach( int child_id in item.m_cNode.GetChildrenIDList() )
			{
				node = GetNode(child_id);
				item.m_lstChildren.Add(node);
			}
		}
		foreach( EditorBNode item in this.m_lstNode )
		{
			EditorBNode.CalChildrenIndex(item);
		}
		if(this.m_iID >= TREE_ID )
			TREE_ID = this.m_iID+1;
	}

	public EditorBNode GetNode( int id )
	{
		foreach( EditorBNode item in this.m_lstNode )
			if(item.m_iID == id)
				return item;
		return null;
	}

	public void SetRoot( EditorBNode node )
	{
		this.m_cRoot = node;
	}

	public void Add( EditorBNode node )
	{
		if(this.m_lstNode.Contains(node))
			return;
		this.m_lstNode.Add(node);
	}

	public void Remove( EditorBNode node )
	{
		if(node == m_cRoot)
			m_cRoot = null;
		this.m_lstNode.Remove(node);
	}

	public void Clear()
	{
		this.m_cRoot = null;
		this.m_lstNode.Clear();
	}
}


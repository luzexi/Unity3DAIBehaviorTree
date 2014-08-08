using UnityEngine;
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


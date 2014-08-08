using UnityEngine;
using Game.AIBehaviorTree;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;

//	EditorBTreeMgr.cs
//	Author: Lu Zexi
//	2014-08-07




/// <summary>
/// Editor Behavior node manager
/// </summary>
public class EditorBTreeMgr
{
	public Dictionary<int,EditorBTree> m_mapTree = new Dictionary<int, EditorBTree>();
	private Dictionary<int,Type> m_mapGen = new Dictionary<int, Type>();

	private static EditorBTreeMgr s_cInstance;
	public static EditorBTreeMgr sInstance
	{
		get
		{
			if(s_cInstance == null)
			{
				s_cInstance = new EditorBTreeMgr();
			}
			return s_cInstance;
		}
	}

	public EditorBTreeMgr()
	{
		//
		m_mapGen.Add(0,typeof(BNodeActionNothing));
		m_mapGen.Add(1,typeof(BNodeConditionNothing));
		m_mapGen.Add(2,typeof(BNodeDecoratorNothing));
	}

	public string[] GetNodeLst()
	{
		string[] str = new string[this.m_mapGen.Count];
		foreach( KeyValuePair<int,Type> item in this.m_mapGen )
		{
			str[item.Key] = item.Value.Name;
		}
		return str;
	}

	public EditorBNode GeneratorNode(int typeid)
	{
		EditorBNode node = null;
		Type t = this.m_mapGen[typeid];
		node = new EditorBNode();
		node.m_cNode = Activator.CreateInstance(t) as BNode;
		node.m_strName = t.Name;
//		switch(typeid)
//		{
//		case 0:
//			node = new EditorBNode("ActionNothing");
//			node.m_cNode = new Game.AIBehaviorTree.BNodeActionNothing();
//			break;
//		}
		return node;
	}

	public EditorBTree GetTree( int id )
	{
		if( this.m_mapTree.ContainsKey(id))
			return this.m_mapTree[id];
		return null;
	}

	public List<EditorBTree> GetTrees()
	{
		List<EditorBTree> lst = new List<EditorBTree>();
		foreach( EditorBTree item in this.m_mapTree.Values )
			lst.Add(item);
		return lst;
	}

	public void Add( EditorBTree tree )
	{
		if( this.m_mapTree.ContainsKey(tree.m_iID))
		{
			Debug.LogError("The tree id is exist.");
			return;
		}
		this.m_mapTree.Add(tree.m_iID , tree);
	}

	public void Remove(EditorBTree tree)
	{
		if(tree == null ) return;
		if( this.m_mapTree.ContainsKey(tree.m_iID))
			this.m_mapTree.Remove(tree.m_iID);
		else
			Debug.LogError("The tree id is not exist.");
		return;
	}
}


using UnityEngine;
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
	public List<EditorBNode> m_lstNode = new List<EditorBNode>();

	private static EditorBTreeMgr s_cInstance;
	public static EditorBTreeMgr sInstance
	{
		get
		{
			if(s_cInstance == null)
				s_cInstance = new EditorBTreeMgr();
			return s_cInstance;
		}
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


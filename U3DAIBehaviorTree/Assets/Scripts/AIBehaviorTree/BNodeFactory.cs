using UnityEngine;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using Game.AIBehaviorTree;

//	BNodeFactory.cs
//	Author: Lu Zexi
//	2014-08-11



/// <summary>
/// Behavior node factory.
/// </summary>
public class BNodeFactory
{
	private List<Type> m_lstGen = new List<Type>();

	private static BNodeFactory s_cInstance;
	public static BNodeFactory sInstance
	{
		get
		{
			if(s_cInstance == null)
			{
				s_cInstance = new BNodeFactory();
			}
			return s_cInstance;
		}
	}

	public BNodeFactory()
	{
		m_lstGen.Add(typeof(BNodeSequence));
		m_lstGen.Add(typeof(BNodeSelector));
		m_lstGen.Add(typeof(BNodeParallel));
	}

	public BNode Create( int index )
	{
		if( this.m_lstGen.Count > index )
		{
			Type t = this.m_lstGen[index];
			BNode node = Activator.CreateInstance(t) as BNode;
			return node;
		}
		Debug.LogError("The type index is none : " + index);
		return null;
	}

	public string[] GetNodeLst()
	{
		string[] str = new string[this.m_lstGen.Count];
		for( int i = 0 ; i<this.m_lstGen.Count ;i++ )
		{
			Type item = this.m_lstGen[i];
			str[i] = item.Name;
		}
		return str;
	}
}


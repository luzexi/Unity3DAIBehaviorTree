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
	private Dictionary<int,Type> m_mapGen = new Dictionary<int, Type>();

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
		m_mapGen.Add(0,typeof(BNodeActionNothing));
		m_mapGen.Add(1,typeof(BNodeConditionNothing));
		m_mapGen.Add(2,typeof(BNodeDecoratorNothing));
	}

	public BNode Create( int typeid )
	{
		if( m_mapGen.ContainsKey(typeid) )
		{
			Debug.Log("typeid "+typeid);
			Type t = this.m_mapGen[typeid];
			BNode node = Activator.CreateInstance(t) as BNode;
			node.SetTypeID(typeid);
			return node;
		}
		Debug.LogError("The typeid is none : " + typeid);
		return null;
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
}


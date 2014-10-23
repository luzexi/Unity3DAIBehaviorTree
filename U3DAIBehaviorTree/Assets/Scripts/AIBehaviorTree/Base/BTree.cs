using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;

//	BTree.cs
//	Author: Lu Zexi
//	2014-08-07



namespace Game.AIBehaviorTree
{
	/// <summary>
	/// Behavior tree.
	/// </summary>
	public class BTree
	{
		public string m_strName;   //描述
		public BNode m_cRoot;	//root

		public BTree()
		{
		}

		//write json
		public void WriteJson( JsonData parent )
		{
			JsonData json = new JsonData();
			json["name"] = this.m_strName;
			if(this.m_cRoot != null )
			{
				json["node"] = new JsonData();
				json["node"].SetJsonType(JsonType.Object);
				json["node"] = this.m_cRoot.WriteJson();
			}
			parent.Add(json);
		}

		//read json
		public void ReadJson(JsonData json)
		{
			this.m_strName = json["name"].ToString();
			this.m_cRoot = null;
			if( json.Keys.Contains("node") )
			{
				string typename = json["node"]["type"].ToString();
				Type t = Type.GetType(typename);
				this.m_cRoot = Activator.CreateInstance(t) as BNode;
				this.m_cRoot.ReadJson(json["node"]);
			}
		}

		//set root node
		public void SetRoot( BNode node )
		{
			this.m_cRoot = node;
		}

		//clear root node
		public void Clear()
		{
			this.m_cRoot = null;
		}

		public void Run( BInput input )
		{
			this.m_cRoot.RunNode(input);
		}
	}

}


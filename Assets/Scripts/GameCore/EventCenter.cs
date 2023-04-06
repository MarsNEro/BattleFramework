using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;


public static class MessageDefine
{
	public const string ROLE_MOVE_RIGHT = "ROLE_MOVE_RIGHT";

	public const string ROLE_MOVE_LEFT = "ROLE_MOVE_LEFT";

	public const string ROLE_MOVE_UP = "ROLE_MOVE_UP";

	public const string ROLE_MOVE_DOWN = "ROLE_MOVE_DOWN";
}

public class EventCenter : SingletonTemplate<EventCenter>
{
	private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

	public EventCenter()
	{
		FieldInfo[] fiels = typeof(MessageDefine).GetFields();
		for (int i = 0; i < fiels.Length; i++)
		{
			eventDic.Add(fiels[i].GetRawConstantValue().ToString(), null);
		}
	}

	/// <summary>
	/// 添加消息监听
	/// </summary>
	/// <param name="messageName"></param>
	/// <param name="action"></param>
	public void AddEventListener(string messageName, UnityAction<object> action)
	{
		if (!eventDic.ContainsKey(messageName))
		{
			Debug.LogError("消息未定义");
			return;
		}
		eventDic[messageName] += action;
	}

	/// <summary>
	/// 移除消息监听
	/// </summary>
	/// <param name="messageName"></param>
	/// <param name="action"></param>
	public void RemoveEventListener(string messageName, UnityAction<object> action)
	{
		if (!eventDic.ContainsKey(messageName))
		{
			Debug.LogError("消息未定义");
			return;
		}
		eventDic[messageName] -= action;
	}

	/// <summary>
	/// 发消息
	/// </summary>
	/// <param name="messageName"></param>
	public void SendMessage(string messageName, object info = null)
	{
		if (eventDic[messageName] != null)
		{
			eventDic[messageName].Invoke(info);
		}
	}

	/// <summary>
	/// 清空所有事件
	/// </summary>
	public void Clear()
	{
		foreach (var item in eventDic)
		{
			eventDic[item.Key] = null;
		}
	}
}

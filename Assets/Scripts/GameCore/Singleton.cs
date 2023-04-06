using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//C# 对象单例模式
public class SingletonTemplate<T> where T : class, new()
{
	private static volatile T instance;
	private static object syncRoot = new Object();
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				lock (syncRoot)
				{
					if (instance == null)
					{
						instance = new T();
						SingletonTemplate<T> singletonInit = instance as SingletonTemplate<T>;
						singletonInit?.Init();
					}
				}
			}
			return instance;
		}
	}

	public static void CreateInstance()
	{
		Instance.ToString();
	}

	public static void DestroyInstance()
	{
		SingletonTemplate<T> singletonInit = instance as SingletonTemplate<T>;
		singletonInit?.UnInit();

		instance = null;
	}
	public virtual void Init()
	{

	}
	public virtual void UnInit()
	{

	}
}

//Mono 单例化
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
	private static volatile T instance;
	private static object syncRoot = new Object();
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				lock (syncRoot)
				{
					if (instance == null)
					{
						T[] instances = (T[])FindObjectsOfType(typeof(T));
						if (instances != null)
						{
							for (var i = 0; i < instances.Length; i++)
							{
								Destroy(instances[i].gameObject);
							}
						}
						GameObject go = new GameObject();
						go.name = typeof(T).Name;
						instance = go.AddComponent<T>();

						if (Application.isPlaying)
							DontDestroyOnLoad(go);
					}

				}
			}
			return instance;
		}
	}

	public virtual void Awake()
	{
		if (instance == null)
		{
			instance = this as T;
			gameObject.name = typeof(T).Name;
			if (Application.isPlaying)
				DontDestroyOnLoad(gameObject);
			Init();
		}

	}

	public virtual void Init()
	{

	}
	public virtual void UnInit()
	{

	}
	public static void CreateInstance()
	{
		Instance.ToString();
	}

	public static void DestroyInstance()
	{
		SingletonMono<T> singletonInit = instance as SingletonMono<T>;
		singletonInit?.UnInit();

		if (instance != null)
			Destroy(instance.gameObject);

		instance = null;
	}

}

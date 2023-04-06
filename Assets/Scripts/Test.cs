using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum EWorkType
{
	Normal, //常规
	Geming, //游戏逻辑
	Battle, //战斗逻辑
	Chat,   //聊天
	UI,
	Timer,  //计时器
	Assets, //AB包加载
	Net,
	Waiter,
}
public class CoroutineManager : SingletonMono<CoroutineManager>
{

	private Dictionary<EWorkType, Coroutine> Coroutines = new Dictionary<EWorkType, Coroutine>();
	public Coroutine StartCoroutine(EWorkType type, IEnumerator enumerator)
	{
		Coroutine coroutine = StartCoroutine(enumerator);
		Coroutines.Add(type, coroutine);
		return coroutine;
	}
}
public class Test : SingletonMono<Test>
{
	public int[] skillID = { 10001, 10002 };
	public Role Role;
	public Emeny Emeny;
	private void Start()
	{

		Role.AddWeapon(E_WeaponType.Missile, Emeny.body);
		// List<int> aa = JsonConvert.DeserializeObject<List<int>>("[0]=1000,[1]=1001");

		// for (int i = 0; i < aa.Count; i++)
		// {
		// 	Debug.LogError(aa[i]);
		// }
		// EventCenter.CreateInstance();
		// Role role = new Role();
		// role.AddSkill(10001);

	}
}
public interface Fly { }
public interface Jump { }

public static class ExtendSkill
{
	public static void StartFly<T>(this T example, string name = "") where T : Fly
	{
		Debug.LogError("我飞，我飞，我飞飞飞");
	}

	public static void Introduce<T>(this T example, string name) where T : Fly
	{
		Debug.LogError("自我介绍" + name);
	}

	public static void StartJump<T>(this T example, string name = "") where T : Jump
	{
		Debug.LogError("跳跃一下");
	}
}

public class Missile : WeaponBase
{
	private string AddressableAssets = "bullet1";
	GameObject origin;
	GameObject target;
	public Missile(GameObject t)
	{
		target = t;
		origin = Addressables.LoadAssetAsync<GameObject>(AddressableAssets).WaitForCompletion();
	}

	// public override IEnumerator Update()
	// {
	// 	while (true)
	// 	{
	// 		GameObject a = Addressables.LoadAssetAsync<GameObject>("bullet1").WaitForCompletion();
	// 		GameObject.Destroy(GameObject.Instantiate(a, Test.Instance.Role.transform), 5);
	// 		Addressables.ReleaseInstance(a);
	// 		yield return new WaitForSeconds(duration);
	// 		yield return new WaitForFixedUpdate();
	// 	}
	// }
	public override void Level1Performance()
	{
		base.Level1Performance();
		Debug.LogError(origin);
		if (origin != null)
		{
			GameObject bullet = GameObject.Instantiate(origin, Test.Instance.Role.transform);
			bullet.GetComponent<Rigidbody2D>().AddForce(target.transform.position);
			GameObject.Destroy(bullet, 2);
		}
	}
}

public enum E_WeaponType
{
	Missile = 10001,
}


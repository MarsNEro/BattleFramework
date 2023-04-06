using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponBase
{
	public WeaponBase()
	{
		levelAction.Add(1, Level1Performance);
		levelAction.Add(2, Level2Performance);
		levelAction.Add(3, Level3Performance);
		levelAction.Add(4, Level4Performance);
		levelAction.Add(5, Level5Performance);
		levelAction.Add(6, SuperWeapon);

		CoroutineManager.Instance.StartCoroutine(EWorkType.Battle, Update());
	}
	public int weaponLevel = 1;
	public float duration = 1;
	public float durationcd = 1;
	public float speed = 0.1f;
	public Dictionary<int, Action> levelAction = new Dictionary<int, Action>();
	public virtual void AddWeaponLevel()
	{
		weaponLevel++;
	}

	public virtual void AddWeaponSpeed(float value)
	{
		speed += value;
	}

	public virtual void Level1Performance() { }
	public virtual void Level2Performance() { }
	public virtual void Level3Performance() { }
	public virtual void Level4Performance() { }
	public virtual void Level5Performance() { }
	public virtual void SuperWeapon() { }

	public virtual IEnumerator Update()
	{
		while (true)
		{
			durationcd -= Time.deltaTime;
			if (durationcd <= 0)
			{
				levelAction[weaponLevel].Invoke();
				durationcd = duration;
			}

			yield return new WaitForFixedUpdate();
		}
	}

}

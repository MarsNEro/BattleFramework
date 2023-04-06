using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : RoleMove
{
	public Dictionary<E_WeaponType, WeaponBase> skillBases = new Dictionary<E_WeaponType, WeaponBase>();
	public Role()
	{

	}

	public void AddWeapon(E_WeaponType weaponType, GameObject target)
	{
		switch (weaponType)
		{
			case E_WeaponType.Missile:
				{
					if (skillBases.ContainsKey(weaponType))
						skillBases[weaponType].AddWeaponLevel();
					else
					{
						skillBases.Add(weaponType, new Missile(target));
					}
				}
				break;
		}

	}
}
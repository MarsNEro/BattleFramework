using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface KnockBack
{
	public void OnHit()
	{

	}
}

public class SkillData
{
	/// <summary>
	/// 技能范围
	/// </summary>
	public int area;
	/// <summary>
	/// 飞行速度
	/// </summary>
	public int speed;
	/// <summary>
	/// 技能冷却
	/// </summary>
	public int cooldown;
	/// <summary>
	/// 持续时长
	/// </summary>
	public int duration;


}

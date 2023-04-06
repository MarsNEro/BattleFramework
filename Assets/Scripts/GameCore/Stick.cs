using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Stick : ScrollRect, IPointerUpHandler, IPointerDownHandler
{
	protected float mRadius = 0f;//摇杆范围半径

	protected override void Start()
	{
		base.Start();//原start方法

		//计算摇杆范围半径
		mRadius = (transform as RectTransform).sizeDelta.x * 0.45f;
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);//原onDrag方法

		//摇杆位置
		var contentPosition = content.anchoredPosition;

		Debug.LogError(contentPosition.x + "+" + contentPosition.y);
		// if (contentPosition.x > 0)
		// {
		// 	//在此写控制角色右移逻辑
		// 	Debug.LogError("右移");
		// 	EventCenter.Instance.SendMessage(MessageDefine.ROLE_MOVE_RIGHT);
		// }
		// else if (contentPosition.x < 0)
		// {
		// 	EventCenter.Instance.SendMessage(MessageDefine.ROLE_MOVE_LEFT);
		// 	Debug.LogError("左移");
		// 	//在此写控制角色左移逻辑
		// }

		// if (contentPosition.y > 0)
		// {
		// 	EventCenter.Instance.SendMessage(MessageDefine.ROLE_MOVE_UP);
		// 	Debug.LogError("上移");
		// }
		// else if (contentPosition.y < 0)
		// {
		// 	EventCenter.Instance.SendMessage(MessageDefine.ROLE_MOVE_DOWN);
		// 	Debug.LogError("下移");
		// }


		//如果摇杆位置超出范围，则限制在范围内
		if (contentPosition.magnitude > mRadius)
		{
			contentPosition = contentPosition.normalized * mRadius;
			SetContentAnchoredPosition(contentPosition);
		}
	}

	private float CalculaAngle(float _joyPositionX, float _joyPositionY)
	{
		float currentAngleX = _joyPositionX * 90f + 90f;//X轴 当前角度
		float currentAngleY = _joyPositionY * 90f + 90f;//Y轴 当前角度

		//下半圆
		if (currentAngleY < 90f)
		{
			if (currentAngleX < 90f)
			{
				return 270f + currentAngleY;
			}
			else if (currentAngleX > 90f) { return 180f + (90f - currentAngleY); }
		}
		return currentAngleX;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//这个接口需要实现用来检测指针是否点击，什么都不写也行，有就ok
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		//在此写控制角色停止移动逻辑
	}
}
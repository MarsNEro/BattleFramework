using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMove : MonoBehaviour
{
	public float speed = 0.01f;
	private Vector3 body;
	// Start is called before the first frame update
	void Start()
	{
		body = this.transform.position;
		AddEventListener();
	}

	void AddEventListener()
	{
		EventCenter.Instance.AddEventListener(MessageDefine.ROLE_MOVE_LEFT, MoveLeft);
		EventCenter.Instance.AddEventListener(MessageDefine.ROLE_MOVE_RIGHT, MoveRight);
		EventCenter.Instance.AddEventListener(MessageDefine.ROLE_MOVE_UP, MoveUp);
		EventCenter.Instance.AddEventListener(MessageDefine.ROLE_MOVE_DOWN, MoveDown);
	}

	void MoveLeft(object obj)
	{
		// body.Set(body.x - 1, body.y, 0);
		body = new Vector3(body.x - speed, body.y, 0);
		this.transform.position = body;
	}

	void MoveRight(object obj)
	{
		// body.Set(body.x - 1, body.y, 0);
		body = new Vector3(body.x + speed, body.y, 0);
		this.transform.position = body;
	}

	void MoveUp(object obj)
	{
		// body.Set(body.x - 1, body.y, 0);
		body = new Vector3(body.x, body.y + speed, 0);
		this.transform.position = body;
	}

	void MoveDown(object obj)
	{
		// body.Set(body.x - 1, body.y, 0);
		body = new Vector3(body.x, body.y - speed, 0);
		this.transform.position = body;
	}
	// Update is called once per frame
	void Update()
	{

	}
}

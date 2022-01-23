using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//”Œœ∑≥°æ∞
public class GameView : MonoBehaviour
{
	public int level = 0;
	public Button button1;
	public Button button2;
	ObjBase obj1;
	ObjBase obj2;
	Transform chat;
	private int days = 1;
	void Start()
	{
		chat = UIRoot.Instance.Get("ChatView");
		obj1 = button1.GetComponent<ObjBase>();
		obj1.count = days - 1;
		button1.onClick.AddListener(OnClickObj1);

		chat = UIRoot.Instance.Get("ChatView");
		obj2 = button2.GetComponent<ObjBase>();
		obj2.count = days - 1;
		button2.onClick.AddListener(OnClickObj2);
	}

	private void OnClickObj1()
	{
		UIRoot.Instance.Open("ChatView");
		EventMgr.Instance.EventTrigger("ClickObj1");
		chat.GetComponent<ChatView>().speak.text = obj1.talks[obj1.count];
	}

	private void OnClickObj2()
	{
		UIRoot.Instance.Open("ChatView");
		EventMgr.Instance.EventTrigger("ClickObj2");
		chat.GetComponent<ChatView>().speak.text = obj2.talks[obj2.count];
	}


	void Update()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//”Œœ∑≥°æ∞
public class GameView : MonoBehaviour
{
	public int level = 0;
	public Button[] buttons;
	ObjBase obj;
	Transform chat;
	private int days = 1;
	void Start()
	{
		chat = UIRoot.Instance.Get("ChatView");
		foreach (var btn in buttons)
		{
			obj = btn.GetComponent<ObjBase>();
			obj.count = days - 1;
			btn.onClick.AddListener(OnClickObj);
		}
	}

	private void OnClickObj()
	{
		UIRoot.Instance.Open("ChatView");
		EventMgr.Instance.EventTrigger("ClickObj");
		chat.GetComponent<ChatView>().speak.text = obj.talks[obj.count];
	}


	void Update()
	{

	}
}

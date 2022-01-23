using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjBase : MonoBehaviour
{
	public int eventDay;	//触发一个事件的日子
	private string[] talks;

	void Start()
	{	
		GetComponent<Button>().onClick.AddListener(() =>
		{
			if(GameData.Instance.currDay == eventDay)
			{
				UIRoot.Instance.Open("TipsView");
				UIRoot.Instance.Get("TipsView").GetComponent<TipsView>().tips.text = talks[GameData.Instance.currDay - 1];
			}
			else
			{
				UIRoot.Instance.Open("ChatView");
				UIRoot.Instance.Get("ChatView").GetComponent<ChatView>().speak.text = talks[GameData.Instance.currDay - 1];
			}
		});
	}

	public void SetTalk(int eventDay, params string[] talks)
	{
		this.eventDay = eventDay;
		this.talks = new string[talks.Length];
		this.talks = talks;
	}

	void Update()
	{

	}
}

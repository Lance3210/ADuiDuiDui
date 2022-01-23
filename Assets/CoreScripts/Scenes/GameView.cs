using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
	public ChatView chat;
	public Transform objRoot;
	public Dictionary<string, ObjBase> objDic = new Dictionary<string, ObjBase>();
	public Button btn_bed;
	void Start()
	{
		btn_bed.onClick.AddListener(() =>
		{
			print("bed");
			UIRoot.Instance.Open("TipsView");
			UIRoot.Instance.Get("TipsView").GetComponent<TipsView>().tips.text = "睡觉吧";
			UIRoot.Instance.Get("TipsView").GetComponent<TipsView>().DoBed();
		});
		var objs = objRoot.GetComponentsInChildren<ObjBase>();
		foreach (var obj in objs)
		{
			objDic.Add(obj.gameObject.name, obj);

			switch (obj.gameObject.name)
			{
				case "baozhi":
					obj.SetTalk(
						1,
						"是否看报纸",
						"不想看报纸",
						"新闻上写着实验完成了。。。"
					);
					break;
				case "cha":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "huo":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "yaoji":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "wall":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "guizi":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "door":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "deng":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "hua":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "chair1":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				case "chair2":
					obj.SetTalk(
						2,
						"1",
						"2",
						"3"
					);
					break;
				default:
					break;
			}
		}
	}

	void Update()
	{

	}
}

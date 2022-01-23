using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TipsView : MonoBehaviour
{
	public Text tips;
	public Button btn_no;
	public Button btn_yes;
	public bool is_bed = false;
	public event UnityAction onBed;
	void Start()
	{
		onBed += OnClickBed;
		btn_no.onClick.AddListener(OnClickNo);
		btn_yes.onClick.AddListener(OnClickYes);
	}

	void OnClickBed()
	{
		is_bed = true;
	}

	// 外部事件
	public void DoBed()
	{
		if (onBed != null)
		{
			onBed();
		}
	}

	void OnClickYes()
	{
		gameObject.SetActive(false);
		if (is_bed)
		{
			GameData.Instance.currDay += 1;
			print(GameData.Instance.currDay);
			is_bed = false;
			return;
		}
		GameData.Instance.sanity += 5;
	}

	void OnClickNo()
	{
		gameObject.SetActive(false);
		if (is_bed)
		{
			is_bed = false;
			return;
		}
		GameData.Instance.sanity -= 5;
	}
}

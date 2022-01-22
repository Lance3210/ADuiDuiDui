using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ã· æ√Ê∞Â
public class TipsView : BasePanel
{
	void Start()
	{
		GetControl<Button>("btn_cancel").onClick.AddListener(HideMe);
		GetControl<Button>("btn_quit").onClick.AddListener(OnClickQuit);
	}

	void OnClickQuit()
	{
		HideMe();
		UIMgr.Instance.ShowPanel("GameStartView");
		UIMgr.Instance.HidePanel("PlayerView");
	}

	void Update()
	{

	}
}

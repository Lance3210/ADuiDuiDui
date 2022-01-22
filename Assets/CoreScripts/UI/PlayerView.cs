using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//玩家主界面
public class PlayerView : BasePanel
{
	public float fadeTime = 2f;
	private Image mask;
	void Start()
	{
		mask = GetControl<Image>("img_mask");
		mask.color = Color.black;
		GetControl<Button>("btn_setting").onClick.AddListener(OnClickSetting);
		mask.DOFade(0, fadeTime);
	}

	void OnClickSetting()
	{
		UIMgr.Instance.ShowPanel("TipsView");
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}

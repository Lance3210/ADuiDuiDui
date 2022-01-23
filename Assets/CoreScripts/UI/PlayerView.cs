using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//玩家主界面
public class PlayerView : MonoBehaviour
{
	public float fadeTime = 2f;
	public Image mask;
	public Button btn_drink;
	public Button btn_setting;
	public Slider slider;
	public Text percent;
	private void OnEnable()
	{
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	private void Start()
	{
		slider.value = GameData.Instance.sanity;
		btn_setting.onClick.AddListener(OnClickSetting);
		btn_drink.onClick.AddListener(OnClickDrinking);
	}

    private void Update()
    {
		percent.text = slider.value.ToString() + "%";
	}
    void OnClickSetting()
	{
		UIRoot.Instance.Open("SettingView");
	}

	void OnClickDrinking()
	{
 		print("drink");
		GameData.Instance.sanity += 5;
		slider.value = GameData.Instance.sanity;
		percent.text = GameData.Instance.sanity.ToString() + "%";
		if (GameData.Instance.sanity >= 90)
		{
			UIRoot.Instance.Open("TipsView");
			UIRoot.Instance.Get("TipsView").GetComponent<TipsView>().tips.text = "哈哈哈。。。";		
		}
	}

}

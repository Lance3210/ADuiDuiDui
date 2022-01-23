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
	public int sanity = 50;
	private void OnEnable()
	{
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	private void Start()
	{
		
		btn_setting.onClick.AddListener(OnClickSetting);
		btn_drink.onClick.AddListener(OnClickDrinking);
	}

	void OnClickSetting()
	{
		UIRoot.Instance.Open("TipsView");
	}

	void OnClickDrinking()
	{
		sanity += 5;
 		print("drink");
		slider.value += 5;
		percent.text = sanity.ToString() + "%";
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//游戏入口
public class GameStartView : MonoBehaviour
{
	public float fadeTime = 1f;
	public Image mask;
	public Button btn_start;
	public Button btn_quit;
	public CanvasGroup group;
	void OnEnable()
	{
		group.interactable = true;
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	void Start()
    {
		btn_start.onClick.AddListener(StartGame);
		btn_quit.onClick.AddListener(ExitGame);
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	void StartGame()
	{
		Invoke("LaterStart", fadeTime);
		group.interactable = false;
		mask.color = Color.clear;
		mask.DOFade(1, fadeTime);
	}

	void LaterStart()
	{
		gameObject.SetActive(false);
		UIRoot.Instance.Open("PlayerView");
		UIRoot.Instance.Open("GameView");
	}

	void ExitGame()
	{
		Application.Quit();
	}

	void Update()
    {
        
    }
}

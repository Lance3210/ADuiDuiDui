using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

//游戏入口
public class GameStartView : BasePanel
{
	public float fadeTime = 2f;
	private Image mask;
	void OnEnable()
	{
		GetComponent<CanvasGroup>().interactable = true;
		mask = GetControl<Image>("img_mask");
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	void Start()
    {
		GetControl<Button>("btn_start").onClick.AddListener(StartGame);
		GetControl<Button>("btn_exit").onClick.AddListener(ExitGame);
		mask = GetControl<Image>("img_mask");
		mask.color = Color.black;
		mask.DOFade(0, fadeTime);
	}

	void StartGame()
	{
		Invoke("LaterStart", fadeTime);
		GetComponent<CanvasGroup>().interactable = false;
		mask.color = Color.clear;
		mask.DOFade(1, fadeTime);
	}

	void LaterStart()
	{
		HideMe();
		UIMgr.Instance.ShowPanel("PlayerView", (panel) => {
			SceneMgr.Instance.LoadSceneAsync("Game", ()=> {
				ResMgr.Instance.Load<GameObject>("Game/Lab");
			});
			print("Start");
		});
	}

	void ExitGame()
	{
		Application.Quit();
	}

	void Update()
    {
        
    }
}

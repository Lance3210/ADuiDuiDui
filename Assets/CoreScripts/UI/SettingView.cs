using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
	public Button btn_cancel;
	public Button btn_quit;

	void Start()
	{
		btn_cancel.onClick.AddListener(OnClickCancel);
		btn_quit.onClick.AddListener(OnClickQuit);
	}

	void OnClickQuit()
	{
		gameObject.SetActive(false);
		UIRoot.Instance.Open("GameStartView");
		UIRoot.Instance.Close("PlayerView");
		UIRoot.Instance.Close("GameView");
	}

	void OnClickCancel()
	{
		gameObject.SetActive(false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//对话面板
public class ChatView : MonoBehaviour
{
	public Button btn_hide;
	public Text speak;

    void Start()
    {
		btn_hide.onClick.AddListener(OnClickQuit);
	}

	void OnClickQuit()
	{
		gameObject.SetActive(false);
	}
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏root
public class GameRoot : MonoBehaviour
{
	public float fadeTime = 2f;
    void Start()
    {
		DontDestroyOnLoad(Camera.main);
		DontDestroyOnLoad(gameObject);
		UIMgr.Instance.ShowPanel("GameStartView", (p) => {
			print("Game Run");
		});
    }
}

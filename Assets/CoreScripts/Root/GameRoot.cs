using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//游戏root
public class GameRoot : MonoBehaviour
{
	public Transform root;
    void Start()
    {
		root.GetComponent<UIRoot>().Open("GameStartView");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//NPC
public class NPCBase : MonoBehaviour
{
	public Animation anime;
	public Button button;
    void Start()
    {
		if (button == null)
		{
			button = gameObject.AddComponent<Button>();
			button.name = "btn_click";
		}
    }

    void Update()
    {
        
    }
}

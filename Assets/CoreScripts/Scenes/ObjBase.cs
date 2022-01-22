using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ÎïÌå
public class ObjBase : MonoBehaviour
{
	public int count;
	public string[] talks;
    void Start()
    {
		EventMgr.Instance.AddEventListener("ClickObj", (o) => {
			UIRoot.Instance.Get("ChatView").GetComponent<ChatView>().speak.text = talks[count];
		});
    }

    void Update()
    {
        
    }
}

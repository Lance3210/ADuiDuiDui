using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : SingletonMgrMonoBase<UIRoot>
{
	public Dictionary<string, Transform> panelDic = new Dictionary<string, Transform>();
	private void Start()
	{
		Transform obj;
		for (int i = 0; i < transform.childCount; i++)
		{
			obj = transform.GetChild(i);
			panelDic.Add(obj.name, obj);
		}
	}

	public void Open(string panel)
	{
		if (panelDic.ContainsKey(panel))
		{
			panelDic[panel].gameObject.SetActive(true);
		}
	}

	public void Close(string panel)
	{
		if (panelDic.ContainsKey(panel))
		{
			panelDic[panel].gameObject.SetActive(false);
		}
	}

	public Transform Get(string panel)
	{
		return panelDic[panel];
	}
}

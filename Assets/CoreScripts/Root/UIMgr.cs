using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//UI管理器
public class UIMgr : SingletonMgrMonoBase<UIMgr>
{
	public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
	public Transform canvas;
	public float fadeTime = 1f;
	void Start()
    {
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(canvas);
		var eventSystem = GameObject.Find("EventSystem");
		DontDestroyOnLoad(eventSystem);		
		var uICamera = GameObject.Find("UICamera");
		DontDestroyOnLoad(uICamera);
	}

	/// <summary>
	/// 显示面板
	/// </summary>
	/// <param name="panelName">面板名称</param>
	/// <param name="callBack">回调函数</param>
	public void ShowPanel(string panelName, UnityAction<BasePanel> callBack = null)
	{
		if (panelDic.ContainsKey(panelName))
		{
			panelDic[panelName].ShowMe();
			if (callBack != null)
				callBack(panelDic[panelName]);
			return;
		}
		var obj = ResMgr.Instance.Load<GameObject>("UI/" + panelName);
		obj.name = panelName;
		obj.transform.SetParent(canvas);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		(obj.transform as RectTransform).offsetMax = Vector2.zero;
		(obj.transform as RectTransform).offsetMin = Vector2.zero;

		//得到预设体身上的面板脚本
		BasePanel panel = obj.GetComponent<BasePanel>();
		if (callBack != null)
			callBack(panel);
		panel.ShowMe();

		//把面板存起来
		panelDic.Add(panelName, panel);
	}

	/// <summary>
	/// 隐藏面板
	/// </summary>
	/// <param name="panelName"></param>
	public void HidePanel(string panelName)
	{
		if (panelDic.ContainsKey(panelName))
		{
			panelDic[panelName].HideMe();
			GameObject.Destroy(panelDic[panelName].gameObject);
			panelDic.Remove(panelName);
		}
	}

	/// <summary>
	/// 得到某一个已经显示的面板
	/// </summary>
	public T GetPanel<T>(string name) where T : BasePanel
	{
		if (panelDic.ContainsKey(name))
			return panelDic[name] as T;
		return null;
	}
}

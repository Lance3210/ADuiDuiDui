using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理器，提供处理场景切换逻辑方法
/// </summary>
public class SceneMgr : SingletonMgrBase<SceneMgr>
{
    /// <summary>
    /// 场景同步加载及完成后逻辑
    /// </summary>
    /// <param name="scene">场景名称</param>
    /// <param name="action">加载完成后的逻辑</param>
    public void LoadScene(string scene, UnityAction action = null)
    {
        SceneManager.LoadScene(scene);
        action();
    }

    /// <summary>
    /// 场景异步加载及完成后逻辑
    /// </summary>
    /// <param name="scene">场景名称</param>
    /// <param name="callBack">加载完成后的逻辑</param>
    public void LoadSceneAsync(string scene, UnityAction callBack)
    {
        //利用MonoMgr直接开启执行异步加载的协程函数
        MonoMgr.Instance.StartCoroutine(AsyncLoadSceneAction(scene, callBack));
    }

    /// <summary>
    /// 执行场景异步加载的协程函数
    /// </summary>
    /// <param name="scene">场景名称</param>
    /// <param name="callBack">加载完成后的逻辑</param>
    /// <returns></returns>
    private IEnumerator AsyncLoadSceneAction(string scene, UnityAction callBack)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        while (!ao.isDone)
        {
            //对外部已添加的事件发送进度条更新
            EventMgr.Instance.EventTrigger("SceneLoading", ao.progress);
            yield return ao.progress;
        }
        //加载完成后的方法
        callBack();
    }
}

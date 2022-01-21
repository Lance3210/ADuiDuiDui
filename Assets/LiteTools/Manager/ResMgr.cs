using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 资源管理器，提供资源加载方法
/// </summary>
public class ResMgr : SingletonMgrBase<ResMgr>
{
    /// <summary>
    /// 单个资源同步加载（如果是GameObject类型则默认直接创建）
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="isCreate">GameObject类型是否直接创建</param>
    /// <typeparam name="T">返回资源</typeparam>
    /// <returns></returns>
    public T Load<T>(string path, bool isCreate = true) where T : Object
    {
        T res = Resources.Load<T>(path);
        if (res is GameObject && isCreate)
        {
            return GameObject.Instantiate(res);
        }
        return res;
    }

    /// <summary>
    /// 单个资源异步加载（如果是GameObject类型则默认直接创建）
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="callBack">回调函数</param>
    /// <param name="isCreate">GameObject类型是否直接创建</param>
    /// <typeparam name="T">返回资源</typeparam>
    /// <returns></returns>
    public void LoadAsync<T>(string path, UnityAction<T> callBack, bool isCreate = true) where T : Object
    {
        MonoMgr.Instance.StartCoroutine(AsyncLoadResAction(path, callBack, isCreate));
    }

    /// <summary>
    /// 执行资源异步加载的协程函数
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="callBack">回调函数</param>
    /// <param name="isCreate">GameObject类型是否直接创建</param>
    /// <typeparam name="T">返回资源</typeparam>
    /// <returns></returns>
    private IEnumerator AsyncLoadResAction<T>(string path, UnityAction<T> callBack, bool isCreate = true) where T : Object
    {
        ResourceRequest rr = Resources.LoadAsync(path);
        yield return rr;
        if (rr.asset is GameObject && isCreate)
        {
            callBack(GameObject.Instantiate(rr.asset) as T);
        }
        else
        {
            callBack(rr.asset as T);
        }
    }
}
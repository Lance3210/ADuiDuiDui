using System.Collections;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Internal;

/// <summary>
/// Mono管理器, 该类可以给外部提供Update祯更新的方法, 以及添加协程的方法
/// </summary>
public class MonoMgr : SingletonMgrBase<MonoMgr>
{

    /// <summary>
    /// Mono控制器, 被封装的控制逻辑
    /// </summary>
    public class MonoEvent : MonoBehaviour
    {
        private event UnityAction updateEvent;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            updateEvent?.Invoke();
        }

        /// <summary>
        /// 添加外部事件监听 使传入方法可用于 Update 祯更新方法
        /// </summary>
        /// <param name="function">需要执行的方法</param>
        public void AddUpdateListener(UnityAction function)
        {
            updateEvent += function;
        }

        /// <summary>
        /// 移除外部事件监听 
        /// </summary>
        /// <param name="function">需要取消执行的方法</param>
        public void RemoveUpdateListener(UnityAction function)
        {
            updateEvent -= function;
        }
    }

    public MonoEvent monoController;

    public MonoMgr()
    {
        GameObject obj = new GameObject("MonoController");
        monoController = obj.AddComponent<MonoEvent>();
    }

    /// <summary>
    /// 添加外部事件监听 使传入方法可用于 Update 祯更新方法
    /// </summary>
    /// <param name="function">需要执行的方法</param>
    public void AddUpdateListener(UnityAction function)
    {
        monoController.AddUpdateListener(function);
    }

    /// <summary>
    /// 移除外部事件监听 
    /// </summary>
    /// <param name="function">需要取消执行的方法</param>
    public void RemoveUpdateListener(UnityAction function)
    {
        monoController.RemoveUpdateListener(function);
    }

    /// <summary>
    /// 开启协程, 被封装
    /// </summary>
    /// <param name="routine">枚举接口</param>
    public void StartCoroutine(IEnumerator routine)
    {
        monoController.StartCoroutine(routine);
    }

    /// <summary>
    /// 停止所有协程, 被封装
    /// </summary>
    public void StopAllCoroutines()
    {
        monoController.StopAllCoroutines();
    }

    /// <summary>
    /// 停止协程, 被封装
    /// </summary>
    /// <param name="routine">枚举接口</param>
    public void StopCoroutine(IEnumerator routine)
    {
        monoController.StopCoroutine(routine);
    }

    /// <summary>
    /// 停止协程, 被封装
    /// </summary>
    /// <param name="routine">协程</param>
    public void StopCoroutine(Coroutine routine)
    {
        monoController.StopCoroutine(routine);
    }

    /// <summary>
    /// 开启协程, 被封装
    /// </summary>
    /// <param name="methodName">函数名称</param>
    /// <returns></returns>
    //[ExcludeFromDocs]
    //public Coroutine StartCoroutine(string methodName)
    //{
    //    return monoController.StartCoroutine(methodName);
    //}

    /// <summary>
    /// 开启协程, 被封装
    /// </summary>
    /// <param name="methodName">函数名称</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    //public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    //{
    //    return monoController.StartCoroutine(methodName, value);
    //}

    /// <summary>
    /// 停止协程, 被封装
    /// </summary>
    /// <param name="methodName">函数名称</param>
    //public void StopCoroutine(string methodName)
    //{
    //    monoController.StopCoroutine(methodName);
    //}
}

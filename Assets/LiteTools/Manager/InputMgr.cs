using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 输入控制管理器
/// </summary>
public class InputMgr : SingletonMgrBase<InputMgr>
{
    public bool IsStart { get; set; }

    public InputMgr()
    {
        MonoMgr.Instance.AddUpdateListener(InputUpdate);//添加进公共Mono的Update
    }
    
    private void InputUpdate()
    {
        if (!IsStart)
        {
            return;
        }
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
    }

    private static void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventMgr.Instance.EventTrigger("Key_Down", key);//触发已添加的事件
        }
        if (Input.GetKeyUp(key))
        {
            EventMgr.Instance.EventTrigger("Key_Up", key);
        }
    }
}
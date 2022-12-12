using System.Collections;
using System.Collections.Generic;
using ScriptableEvents.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera m_MainCamera;

    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DragObjectStarted;
    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DragObjectCanceled;
    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DoubleClickHappend;


    float m_LastClickTime;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_EventToRaiseOnInputAction_DragObjectStarted.Raise();
            m_LastClickTime = Time.time;
            float timeSinceLastClick = Time.time - m_LastClickTime;

            if (timeSinceLastClick < 0.2f)
                m_EventToRaiseOnInputAction_DoubleClickHappend.Raise();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_EventToRaiseOnInputAction_DragObjectCanceled.Raise();
        }
    }
}

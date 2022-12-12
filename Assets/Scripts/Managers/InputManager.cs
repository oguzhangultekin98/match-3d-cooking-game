using System.Collections;
using System.Collections.Generic;
using ScriptableEvents.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DragObjectStarted;
    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DragObjectCanceled;
    [SerializeField] SimpleScriptableEvent m_EventToRaiseOnInputAction_DoubleClickHappend;

    const float m_Double_Click_Acceptable_Gap = 0.2f;
    float m_LastClickTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_EventToRaiseOnInputAction_DragObjectStarted.Raise();

            float timeSinceLastClick = Time.time - m_LastClickTime;
            m_LastClickTime = Time.time;

            if (timeSinceLastClick < m_Double_Click_Acceptable_Gap)
                m_EventToRaiseOnInputAction_DoubleClickHappend.Raise();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_EventToRaiseOnInputAction_DragObjectCanceled.Raise();
        }
    }
}

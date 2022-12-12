using System.Collections;
using ScriptableEvents.Events;
using UnityEngine;

public class DragAndDroppablesManager : MonoBehaviour
{
    [SerializeField] Camera m_MainCamera;

    GameObject m_DragGameObject;
    DragAndDroppableObject m_DragAndDroppableObject;
    GameObject m_TempGameObject;

    void Start()
    {
        StartCoroutine(CR_DragObject());
    }

    IEnumerator CR_DragObject()
    {
        while (true)
        {
            if (m_DragGameObject != null)
            {
                Vector3 targetPos = m_MainCamera.ScreenToWorldPoint(Input.mousePosition);
                targetPos.z = 0f;
                m_DragGameObject.transform.position = targetPos;
            }
            yield return null;
        }
    }

    GameObject GetGameObjectUnderCursor()
    {
        RaycastHit hit;
        Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHit = hit.transform.gameObject;
            return objectHit;
        }
        return null;
    }

    public void OnEvent_InputAction_DragObjectStarted()
    {
        m_TempGameObject = GetGameObjectUnderCursor();

        if (m_TempGameObject != null)
        {
            m_DragAndDroppableObject = m_TempGameObject.GetComponent<DragAndDroppableObject>();
            m_DragAndDroppableObject.SetDragParent(null);
            m_DragGameObject = m_TempGameObject;
        }
    }

    public void OnEvent_InputAction_DragObjectCanceled()
    {
        StopCarrying();
    }

    void StopCarrying()
    {
        m_DragGameObject = null;
        m_DragAndDroppableObject = null;
    }
}

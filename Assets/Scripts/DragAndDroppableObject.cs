using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDroppableObject : MonoBehaviour
{
    Transform m_DragParent;
    public Transform DragParent => m_DragParent;

    public void SetDragParent(Transform parent)
    {
        m_DragParent = parent;
        transform.parent = parent;
    }
}

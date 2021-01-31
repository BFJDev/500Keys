using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        File file = data.pointerDrag.GetComponent<File>();
        if(file != null)
        {
            file.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Overlappable : MonoBehaviour, IDropHandler
{
    public abstract void FileOverlapStarted();

    public abstract void FileOverlapEnded();

    public abstract void HandleOverlappingFileReleased(File file);

    public void OnDrop(PointerEventData data)
    {
        File file = data.pointerDrag.GetComponent<File>();
        if(file != null)
        {
            file.gameObject.SetActive(false);
        }
    }
}

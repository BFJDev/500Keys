using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler
{
    public VirusBar2 virusbar;
    public void OnDrop(PointerEventData data)
    {
        File file = data.pointerDrag.GetComponent<File>();
        if(file != null)
        {
            file.gameObject.SetActive(false);
        }
        if(file.FileType.Equals(FileType.corrupted))
        {
            virusbar.slider.value -= 5;
        }
    }
}

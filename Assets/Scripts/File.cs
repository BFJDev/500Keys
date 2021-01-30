using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class File : Draggable, IPointerUpHandler
{
    [SerializeField]
    private Text _FileNameDisplay;

    [SerializeField]
    private string _FileName;

    [SerializeField]
    private Sprite _Image;

    [SerializeField]
    private string _Text;

    private Vector2 _LastMousePosition;
 
    void Start()
    {
        _FileNameDisplay.text = _FileName;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    /*    foreach( GameObject hovered in eventData.hovered)
        {
            Overlappable overlappedObject = hovered.GetComponent<Overlappable>();
            if(overlappedObject != null)
            {
                overlappedObject.HandleOverlappingFileReleased(this);
                break;
            }
        }
*/
    }



}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class File : Draggable, IPointerUpHandler
{
    private const float _SecondClickTimeWindow = 0.3f;

    [SerializeField]
    private Text _FileNameDisplay;

    [SerializeField]
    private string _FileName;

    [SerializeField]
    private Sprite _Image;

    [SerializeField]
    private string _Text;

    private Vector2 _LastMousePosition;

    private float _LastClickTime;
 
    void Start()
    {
        _FileNameDisplay.text = _FileName;
    }

    protected override void PointerDown(PointerEventData eventData)
    {
        if(eventData.clickCount >= 2)
        {
            //
        }
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

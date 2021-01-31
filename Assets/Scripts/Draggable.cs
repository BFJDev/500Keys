using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class Draggable : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    protected RectTransform _RectTransform;

    private CanvasGroup _CanvasGroup;
    
    void Awake()
    {
        _RectTransform = GetComponent<RectTransform>();
        _CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _RectTransform.SetAsLastSibling();
        PointerDown(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
       _RectTransform.anchoredPosition += eventData.delta / ScreenCanvas.Canvas.scaleFactor;
       Drag(eventData);
    }

    protected virtual void Drag(PointerEventData eventData) { }

    protected virtual void PointerDown(PointerEventData eventData) { }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _CanvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _CanvasGroup.blocksRaycasts = true;
    }
}

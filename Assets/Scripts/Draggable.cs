﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Draggable : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    protected RectTransform _RectTransform;
    
    void Awake()
    {
        _RectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _RectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       _RectTransform.anchoredPosition += eventData.delta / ScreenCanvas.Canvas.scaleFactor;

       HandleDragEvent(eventData);
    }

    protected virtual void HandleDragEvent(PointerEventData eventData) { }
}

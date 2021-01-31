using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AntivirusDesktopIcon : MonoBehaviour, IPointerDownHandler
{
    private AntivirusWindow _AntivirusWindow;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.clickCount >= 2)
        {
            FileContentDisplayWindow displayWindow = FileContentDisplayWindow.DisplayWindow;
            displayWindow.gameObject.SetActive(true);
        }
    }
}

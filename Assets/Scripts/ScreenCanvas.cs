using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class ScreenCanvas : MonoBehaviour
{
    public static Canvas Canvas { get; private set;}

    void Awake()
    {
        if(Canvas == null)
        {
            Canvas = GetComponent<Canvas>();
        }
    }
}

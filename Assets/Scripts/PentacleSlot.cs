using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PentacleSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private List<Image> _Images;

    public int PiecesFound {get; private set;} = 0;

    private int index = 0;

    void Awake()
    {
        foreach (Image image in _Images)
        {
            image.gameObject.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData data)
    {
        File file = data.pointerDrag.GetComponent<File>();
        PentaclePiece piece = data.pointerDrag.GetComponent<PentaclePiece>();
        if(piece != null && file != null)
        {

            PiecesFound++;
            _Images[index].sprite = file.Image;
            _Images[index].gameObject.SetActive(true);
            Destroy(file.gameObject);
            index++;
        }
    }
}

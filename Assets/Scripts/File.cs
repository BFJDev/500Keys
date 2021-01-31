using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class File : Draggable
{
    [SerializeField]
    private Text _FileNameDisplay;

    [SerializeField]
    private string _FileName;

    [SerializeField]
    private FileType _FileType;

    [SerializeField]
    private Sprite _Image;

    [SerializeField]
    private string _Text;

    private Vector2 _LastMousePosition;

    private float _LastClickTime;

    public string FileName => _FileName;

    public FileType FileType => _FileType;

    public Sprite Image => _Image;

    public string Text => _Text;
 
    void Start()
    {
        _FileNameDisplay.text = _FileName;
    }

    protected override void PointerDown(PointerEventData eventData)
    {
        if(eventData.clickCount >= 2)
        {
            FileContentDisplayWindow displayWindow = FileContentDisplayWindow.DisplayWindow;
            displayWindow.DisplayFile(this);
        }
    }
}

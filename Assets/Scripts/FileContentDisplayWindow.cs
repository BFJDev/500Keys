using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileContentDisplayWindow : MonoBehaviour
{
    public static FileContentDisplayWindow DisplayWindow { get; private set;}

    [SerializeField]
    private Text _FileName;

    [SerializeField]
    private Image _Image;

    [SerializeField]
    private Text _Text;

    [SerializeField]
    private Button _CloseButton;

    void Awake()
    {
        if(DisplayWindow == null)
        {
            DisplayWindow = this;
        }

        _CloseButton.onClick.AddListener( () => gameObject.SetActive(false));
        gameObject.SetActive(false);
    }

    private File _DisplayedFile;

    public void DisplayFile(File file)
    {
        gameObject.SetActive(true);

        _DisplayedFile = file;
        _FileName.text = _DisplayedFile.FileName;
        if(file.FileType == FileType.img)
        {
            _Text.gameObject.SetActive(false);
            _Image.gameObject.SetActive(true);
            _Image.sprite = file.Image;
        }
        else if(file.FileType == FileType.txt)
        {
            _Text.gameObject.SetActive(true);
            _Image.gameObject.SetActive(false);
            _Text.text = file.Text;
        }
    }
}

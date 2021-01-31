using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D mouse;

    public GameObject Antivirus;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 cursorOffset = new Vector2(mouse.width / 2, mouse.height / 2);
        //Cursor.SetCursor(mouse, cursorOffset, CursorMode.Auto);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndGame(bool won)
    {
        if(won)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            SceneManager.LoadScene("Failure");
        }
    }
}

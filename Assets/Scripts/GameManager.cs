using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D mouse;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(mouse.width / 2, mouse.height / 2);
        Cursor.SetCursor(mouse, cursorOffset, CursorMode.Auto);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

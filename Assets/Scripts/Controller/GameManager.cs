using UnityEngine;
using UnityEngine.SceneManagement;

// Monolithic Game Object holding everything
public class GameManager : StateMachine
{ 

    // Timer virusTimer = ....
    // Clippy clippyFSM = ...
    // UI stuff = ...


 
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

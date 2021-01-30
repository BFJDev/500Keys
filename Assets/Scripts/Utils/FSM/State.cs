using UnityEngine;
public abstract class State : MonoBehaviour
{
    public virtual void Enter()
    {
        AddListeners();
    }

    public virtual void Exit()
    {
        RemoveListeners();
    }

    protected virtual void OnDestroy()
    {
        RemoveListeners();
    }

    // Not required
    // This helps to protect us from scenarios like accidentally moving a tile position 
    // on the board at the sime time as changing a menu selection.
    protected virtual void AddListeners()
    {

    }

    protected virtual void RemoveListeners()
    {

    }
    

}

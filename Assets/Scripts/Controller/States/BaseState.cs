using UnityEngine;

public class BaseState : State //, InputController.ICursorActions
{
    //public PlayerManager context;

    // Wrappers to make Manager access easier
    //public Character player { get { return context.player; } set { context.player = value; } }
    protected virtual void Awake()
    {
        //context = GetComponent<PlayerManager>();
    }

    public override void Enter()
    {
        AddListeners();
    }

    public override void Exit()
    {
        RemoveListeners();
    }
}
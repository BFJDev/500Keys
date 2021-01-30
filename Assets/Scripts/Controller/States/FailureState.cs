using UnityEngine;
public class FailureState : BaseState
{
    public override void Enter()
    {
        Debug.Log(">>>>>>> LOSER DETECTED <<<<<<<<<");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

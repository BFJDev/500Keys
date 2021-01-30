using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Get the current state or use logic to set without duplicating
    public virtual State currentState
    {
        get { return _currState; }
        set { Transition(value); }
    }

    protected State _currState;
    protected bool _inTransition;

    protected virtual void Transition(State value)
    {
        // If the same state or currently transitioning, don't transition again
        if (_currState == value || _inTransition)
            return;

        // Otherwise start transition
        _inTransition = true;

        // Exit the current state
        if (_currState != null)
            _currState.Exit();

        // Set the current state
        _currState = value;

        // Enter the new state
        if (_currState != null)
            _currState.Enter();

        // End transitioning
        _inTransition = false;
    }

    // Change state - adds it as a component to prevent having to maintain static references manually
    // Aka State[] allStates = [new BattleState(), new MoveState(), ...] and having to check type-of
    public virtual void ChangeState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        currentState = target;
    }

}
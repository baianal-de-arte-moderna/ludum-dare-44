using UnityEngine;

public abstract class InputType : MonoBehaviour
{
    public delegate void InputEvent();
    public event InputEvent OnJumpInputEvent;
    public event InputEvent OnMoveLeftInputEvent;
    public event InputEvent OnMoveRightInputEvent;
    public event InputEvent OnMoveStopInputEvent;

    void FixedUpdate()
    {
        ReadJump();
        ReadMove();
    }

    private void ReadJump()
    {
        if (Jump())
        {
            OnJumpInputEvent?.Invoke();
        }
    }

    private void ReadMove()
    {
        if (MoveLeft())
        {
            OnMoveLeftInputEvent?.Invoke();
        }
        else if (MoveRight())
        {
            OnMoveRightInputEvent?.Invoke();
        }
        else
        {
            OnMoveStopInputEvent?.Invoke();
        }
    }

    abstract protected bool MoveLeft();
    abstract protected bool MoveRight();
    abstract protected bool Jump();
}

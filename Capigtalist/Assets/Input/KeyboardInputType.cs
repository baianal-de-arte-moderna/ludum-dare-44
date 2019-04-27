using UnityEngine;

public class KeyboardInputType : InputType
{
    protected override bool Jump()
    {
        return Input.GetAxisRaw("Jump") > 0;
    }

    protected override bool MoveLeft()
    {
        return Input.GetAxisRaw("Horizontal") < 0;
    }

    protected override bool MoveRight()
    {
        return Input.GetAxisRaw("Horizontal") > 0;
    }
}

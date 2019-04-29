using UnityEngine;

public class KeyboardInputType : InputType
{
    // Jump Control
    bool wasJumping;
    protected override bool Jump()
    {
        bool isJumping = Input.GetAxisRaw("Jump") > 0;
        if (wasJumping == false)
        {
            wasJumping = isJumping;
            return isJumping;
        }
        wasJumping = isJumping;
        return false;
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

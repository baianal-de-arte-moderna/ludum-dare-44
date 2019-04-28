using UnityEngine;
using System.Collections;

public class RegularJumpBehaviour : JumpBehaviour
{
    public override float GetPrice()
    {
        return 0;
    }

    protected override float JumpModifier()
    {
        return 1;
    }
}

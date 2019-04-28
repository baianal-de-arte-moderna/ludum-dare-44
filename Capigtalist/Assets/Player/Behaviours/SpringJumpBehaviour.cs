using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJumpBehaviour : JumpBehaviour
{
    public override float GetPrice()
    {
        return 2;
    }

    protected override float JumpModifier()
    {
        return 1.2f;
    }
}

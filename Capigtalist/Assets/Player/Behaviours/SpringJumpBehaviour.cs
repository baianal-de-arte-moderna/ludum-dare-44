using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJumpBehaviour : JumpBehaviour
{
    protected override float JumpModifier()
    {
        return 1.5f;
    }
}

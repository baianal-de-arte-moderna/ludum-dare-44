using UnityEngine;
using System.Collections;

public class RegularJumpBehaviour : JumpBehaviour
{
    protected override float JumpModifier()
    {
        return 1;
    }
}

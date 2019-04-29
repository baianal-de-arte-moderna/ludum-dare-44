using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJumpBehaviour : JumpBehaviour
{
    public override float GetPrice()
    {
        return 0.2f;
    }

    public override string GetPriceText()
    {
        return "¢20";
    }

    protected override float JumpModifier()
    {
        return 1.25f;
    }
}

using UnityEngine;

public static class GameData
{
    public static float hp = 5;
    public static float maxHp = 10;
    public static JumpBehaviour jumpBehaviour = new RegularJumpBehaviour();
    public static bool springUpdate = false;
}

using UnityEngine;
using System.Collections.Generic;

public static class GameData
{
    public static float startHp = 60;
    public static float hp = 60;
    public static float maxHp = 1000;
    public static JumpBehaviour jumpBehaviour = new RegularJumpBehaviour();
    public static bool springUpdate = false;
    public static Dictionary<string, float> damageList = initDamages();
    
    private static Dictionary<string, float> initDamages()
    {
        Dictionary<string, float> damages = new Dictionary<string, float>();

        damages["moneditaDe1Cientavito"] = -1f;
        damages["moneditaDe3Cientavitos"] = -3f;
        damages["moneditaDe5Cientavitos"] = -5f;
        damages["moneditaDe50Cientavitos"] = -50f;
        damages["notitaDeDinerito"] = -100f;
        damages["notitasDeDineritos"] = -300f;
        damages["pedritaDeDiamantito"] = -600f;
        damages["Bee"] = 12f;
        damages["cachorro"] = 11f;
        damages["lixeira"] = 9f;
        damages["Lixo(Clone)"] = 4f;
        damages["Boss"] = 4f;
        damages["Sickle(Clone)"] = 6f;
        damages["Hammer(Clone)"] = 26f;
        return damages;
    }
}

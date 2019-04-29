using UnityEngine;
using System.Collections.Generic;

public static class GameData
{
    public static float startHp = 60;
    public static float hp = 60;
    public static float maxHp = 600;
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
        damages["pedritaDeDiamantito"] = -500f;
        damages["Bee"] = 10f;
        damages["cachorro"] = 15f;
        damages["lixeira"] = 10f;
        damages["Lixo(Clone)"] = 5f;
        damages["Boss"] = 25f;
        damages["Sickle(Clone)"] = 10f;
        damages["Hammer(Clone)"] = 30f;
        return damages;
    }
}

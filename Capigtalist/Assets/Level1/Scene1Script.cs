﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene1Script : MonoBehaviour
{
    [Header("Player Fields")]
    public Transform playerSpawn;

    [Space(10)]
    [Header("Enemy Fields")]
    public Transform[] lixeiraSpawn;
    public Transform[] cachorroSpawn;
    public Transform[] abelhaSpawn;

    [Space(10)]
    [Header("Collect Fields")]
    public Transform[] moedaSpawn;
    public Transform[] diamondSpawn;
    public int[] listOfCollectibles;

    [Space(10)]
    [Header("Boss Fields")]
    public BossRoomScript bossSpawn;

    int lixeiraIndex;
    int cachorroIndex;
    int abelhaIndex;
    int moedaIndex;
    int diamondIndex;

    [Space(10)]
    [Header("Loading Fields")]
    public LoadingScreenScript loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        bossSpawn.onBossTriggered += SpawnBoss;

        StartCoroutine("spawner");
    }

    IEnumerator spawner()
    {
        SceneManager.sceneLoaded += SetPlayerScript;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.05f);

        // BG
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

        //Wait to start Lixeira
        yield return new WaitForSeconds(0.05f);

        if (lixeiraSpawn.Length > 0)
        {
            lixeiraIndex = 0;
            SceneManager.sceneLoaded += SetLixeiraScript;
            foreach (var l in lixeiraSpawn)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.02f);
            }
        }

        //Wait to start Cachorro
        yield return new WaitForSeconds(0.05f);

        if (cachorroSpawn.Length > 0)
        {
            cachorroIndex = 0;
            SceneManager.sceneLoaded += SetCachorroScript;
            foreach (var l in cachorroSpawn)
            {
                SceneManager.LoadScene(4, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.02f);
            }
        }

        //Wait to start Abelha
        yield return new WaitForSeconds(0.05f);

        if (abelhaSpawn.Length > 0)
        {
            abelhaIndex = 0;
            SceneManager.sceneLoaded += SetAbelhaScript;
            foreach (var l in abelhaSpawn)
            {
                SceneManager.LoadScene(17, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.02f);
            }
        }

        //Wait to start Collectible
        yield return new WaitForSeconds(0.05f);

        if (moedaSpawn.Length > 0)
        {
            moedaIndex = 0;
            SceneManager.sceneLoaded += SetMoedaScript;
            foreach (var l in moedaSpawn)
            {
                var chosenOne = listOfCollectibles[Random.Range(0, listOfCollectibles.Length)];
                SceneManager.LoadScene(chosenOne, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.02f);
            }
        }

        if (diamondSpawn.Length > 0)
        {
            diamondIndex = 0;
            SceneManager.sceneLoaded += SetDiamondScript;
            foreach (var l in diamondSpawn)
            {
                SceneManager.LoadScene(16, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.02f);
            }
        }

        loadingScreen.EndLoading();

        // HUD
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void SetPlayerScript(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SetPlayerScript;
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = playerSpawn.position;
    }
    public void SetBossScript(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SetBossScript;
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = bossSpawn.transform.position;
    }
    public void SetLixeiraScript(Scene scene, LoadSceneMode mode)
    {
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = lixeiraSpawn[lixeiraIndex].position;
        lixeiraIndex++;
        if (lixeiraIndex >= lixeiraSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetLixeiraScript;
        }
    }
    public void SetCachorroScript(Scene scene, LoadSceneMode mode)
    {
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = cachorroSpawn[cachorroIndex].position;
        cachorroIndex++;
        if (cachorroIndex >= cachorroSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetCachorroScript;
        }
    }
    public void SetAbelhaScript(Scene scene, LoadSceneMode mode)
    {
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = abelhaSpawn[abelhaIndex].position;
        abelhaIndex++;
        if (abelhaIndex >= abelhaSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetAbelhaScript;
        }
    }
    public void SetMoedaScript(Scene scene, LoadSceneMode mode)
    {
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = moedaSpawn[moedaIndex].position;
        moedaIndex++;
        if (moedaIndex >= moedaSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetMoedaScript;
        }
    }
    public void SetDiamondScript(Scene scene, LoadSceneMode mode)
    {
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = diamondSpawn[diamondIndex].position;
        diamondIndex++;
        if (diamondIndex >= diamondSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetDiamondScript;
        }
    }
    public void SpawnBoss()
    {
        SceneManager.sceneLoaded += SetBossScript;
        SceneManager.LoadScene(10, LoadSceneMode.Additive);
    }
}

using System.Collections;
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

    int lixeiraIndex;
    int cachorroIndex;
    int moedaIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawner");
    }

    IEnumerator spawner()
    {
        SceneManager.sceneLoaded += SetPlayerScript;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

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
                yield return new WaitForSeconds(0.01f);
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
                yield return new WaitForSeconds(0.01f);
            }
        }

        //Wait to start Collectibol
        yield return new WaitForSeconds(0.05f);

        if (moedaSpawn.Length > 0)
        {
            moedaIndex = 0;
            SceneManager.sceneLoaded += SetMoedaScript;
            foreach (var l in moedaSpawn)
            {
                SceneManager.LoadScene(5, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public void SetPlayerScript(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SetPlayerScript;
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = playerSpawn.position;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene1Script : MonoBehaviour
{
    public Transform playerSpawn;
    public Transform[] lixeiraSpawn;
    public Transform[] cachorroSpawn;
    public Transform[] abelhaSpawn;

    int lixeiraIndex;
    int cachorroIndex;

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

        //Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        if (lixeiraSpawn.Length > 0)
        {
            lixeiraIndex = 0;
            SceneManager.sceneLoaded += SetLixeiraScript;
            foreach (var l in lixeiraSpawn)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(0.5f);

        if (cachorroSpawn.Length > 0)
        {
            cachorroIndex = 0;
            SceneManager.sceneLoaded += SetCachorroScript;
            foreach (var l in cachorroSpawn)
            {
                SceneManager.LoadScene(4, LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.1f);
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
}

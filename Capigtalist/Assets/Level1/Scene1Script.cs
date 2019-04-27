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

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SetPlayerScript;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        // BG
        SceneManager.LoadScene(2, LoadSceneMode.Additive);

        if (lixeiraSpawn.Length > 0)
        {
            lixeiraIndex = 0;
            SceneManager.sceneLoaded += SetLixeiraScript;
            foreach (var l in lixeiraSpawn)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
            }
        }
        //if (cachorroSpawn.Length > 0)
        //if (abelhaSpawn.Length > 0)
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
        Debug.Log(rootObject.transform.position);
        Debug.Log(lixeiraSpawn[lixeiraIndex].position);
        Debug.Log(lixeiraIndex);
        rootObject.transform.position = lixeiraSpawn[lixeiraIndex].position;
        lixeiraIndex++;
        if (lixeiraIndex >= lixeiraSpawn.Length)
        {
            SceneManager.sceneLoaded -= SetLixeiraScript;
        }
    }
}

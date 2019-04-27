using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene1Script : MonoBehaviour
{
    public GameObject playerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SetPlayerScript;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void SetPlayerScript(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SetPlayerScript;
        var rootObject = scene.GetRootGameObjects()[0];
        rootObject.transform.position = playerSpawn.transform.position;
    }
}

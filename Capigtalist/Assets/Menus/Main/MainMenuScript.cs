using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("UpgradesScene");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}

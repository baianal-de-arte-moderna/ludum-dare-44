using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesScript : MonoBehaviour
{
    public void OnRegularJumpButtonClicked()
    {
        GameData.jumpBehaviour = new RegularJumpBehaviour();
    }

    public void OnSpringJumpButtonClicked()
    {
        GameData.jumpBehaviour = new SpringJumpBehaviour();
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}

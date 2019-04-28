using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesScript : MonoBehaviour
{
    public void OnRegularJumpButtonClicked()
    {
        PlayerAttributes.jumpBehaviour = new RegularJumpBehaviour();
    }

    public void OnSpringJumpButtonClicked()
    {
        PlayerAttributes.jumpBehaviour = new SpringJumpBehaviour();
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}

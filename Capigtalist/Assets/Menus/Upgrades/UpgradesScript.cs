using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesScript : MonoBehaviour
{
    private PlayerAttributes playerAttributes;

    private void Awake()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        // HUD
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void OnRegularJumpButtonClicked()
    {
        BuyJumpBehaviour(new RegularJumpBehaviour());
    }

    public void OnSpringJumpButtonClicked()
    {
        BuyJumpBehaviour(new SpringJumpBehaviour());
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    private void BuyJumpBehaviour(JumpBehaviour newJumpBehaviour)
    {
        if (GameData.jumpBehaviour.GetType() != newJumpBehaviour.GetType())
        {
            float moneyToRecover = GameData.jumpBehaviour.GetPrice();
            float moneyToSpend = newJumpBehaviour.GetPrice();
            float moneyDelta = moneyToRecover - moneyToSpend;

            GameData.jumpBehaviour = newJumpBehaviour;

            GameData.hp += moneyDelta;
            playerAttributes.HealthChange(moneyDelta);
        }
    }
}

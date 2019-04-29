using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    [SerializeField]
    private Text springJumpButton;

    private PlayerAttributes playerAttributes;
    private PlayerScript player;

    private RegularJumpBehaviour regularJumpBehaviour = new RegularJumpBehaviour();
    private SpringJumpBehaviour springJumpBehaviour = new SpringJumpBehaviour();
    private SpriteRenderer upgrade1Renderer;

    private void Awake()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        // HUD
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    private void Start()
    {
        UpdatePriceTexts();
    }

    //public void OnRegularJumpButtonClicked()
    //{
    //    BuyJumpBehaviour(regularJumpBehaviour);
    //    GameData.springUpdate = false;
    //}

    public void OnSpringJumpButtonClicked()
    {
        if (!GameData.springUpdate)
        {
            BuyJumpBehaviour(springJumpBehaviour);
            GameData.springUpdate = true;
        }
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    private void UpdatePriceTexts()
    {
        // Spring Jump
        bool springJumpSelected = GameData.jumpBehaviour.GetType() == springJumpBehaviour.GetType();
        springJumpButton.text = (springJumpSelected)? "Purchased": springJumpBehaviour.GetPriceText();

        // Coin Shooter
        // TODO

        // Piggy Wing
        // TODO

        // Atomic Pig
        // TODO
    }

    private float CalculateJumpPrice(JumpBehaviour jumpBehaviour)
    {
        float moneyToRecover = GameData.jumpBehaviour.GetPrice();
        float moneyToSpend = jumpBehaviour.GetPrice();
        return moneyToRecover - moneyToSpend;
    }

    private void BuyJumpBehaviour(JumpBehaviour newJumpBehaviour)
    {
        if (GameData.jumpBehaviour.GetType() != newJumpBehaviour.GetType())
        {
            float moneyDelta = CalculateJumpPrice(newJumpBehaviour);

            GameData.hp += moneyDelta;
            playerAttributes.HealthChange(moneyDelta);

            GameData.jumpBehaviour = newJumpBehaviour;
            UpdatePriceTexts();

        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    [SerializeField]
    private UpgradeButton regularJumpButton;
    [SerializeField]
    private UpgradeButton springJumpButton;

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
        UpdateJumpPriceTexts();
        upgrade1Renderer = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<SpriteRenderer>();
    }

    public void OnRegularJumpButtonClicked()
    {
        BuyJumpBehaviour(regularJumpBehaviour);
        GameData.springUpdate = false;
    }

    public void OnSpringJumpButtonClicked()
    {
        BuyJumpBehaviour(springJumpBehaviour);
        GameData.springUpdate = true;
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    private void UpdateJumpPriceTexts()
    {
        float regularJumpPrice = CalculateJumpPrice(regularJumpBehaviour);
        bool regularJumpSelected = GameData.jumpBehaviour.GetType() == regularJumpBehaviour.GetType();
        regularJumpButton.UpdateButton(regularJumpPrice, regularJumpSelected);

        float springJumpPrice = CalculateJumpPrice(springJumpBehaviour);
        bool springJumpSelected = GameData.jumpBehaviour.GetType() == springJumpBehaviour.GetType();
        springJumpButton.UpdateButton(springJumpPrice, springJumpSelected);
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
            UpdateJumpPriceTexts();

        }
    }
}

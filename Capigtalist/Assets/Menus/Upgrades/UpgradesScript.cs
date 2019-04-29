using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    [SerializeField]
    private Text regularJumpPriceText;
    [SerializeField]
    private Text springJumpPriceText;

    private PlayerAttributes playerAttributes;

    private RegularJumpBehaviour regularJumpBehaviour = new RegularJumpBehaviour();
    private SpringJumpBehaviour springJumpBehaviour = new SpringJumpBehaviour();

    private void Awake()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        // HUD
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    private void Start()
    {
        UpdateJumpPriceTexts();
    }

    public void OnRegularJumpButtonClicked()
    {
        BuyJumpBehaviour(regularJumpBehaviour);
    }

    public void OnSpringJumpButtonClicked()
    {
        BuyJumpBehaviour(springJumpBehaviour);
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    private void UpdateJumpPriceTexts()
    {
        regularJumpPriceText.text = $"{CalculateJumpPrice(regularJumpBehaviour)}";
        springJumpPriceText.text = $"{CalculateJumpPrice(springJumpBehaviour)}";
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

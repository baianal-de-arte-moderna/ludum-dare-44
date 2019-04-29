using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text priceText;
    public Button button;
    public GameObject pricePanel;
    public GameObject inUseText;

    public void UpdateButton(float price, bool inUse)
    {
        priceText.text = $"{price}";
        button.interactable = !inUse;
        pricePanel.SetActive(!inUse);
        inUseText.SetActive(inUse);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = "Coins: " + ScenePersist.Instance.playerScore;
    }
}

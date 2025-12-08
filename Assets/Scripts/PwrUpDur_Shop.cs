using UnityEngine;

public class PwrUpDur_Shop : MonoBehaviour
{
    [SerializeField] int cost = 0;
    [SerializeField] int pwrUpDuramount = 1;
    GameSession gameSession;
    PowerUp_JumpBoost shopItem1;
    PowerUp_JumpBoost shopItem1_;


    void test()
    {
        Debug.Log("Bought");
    }
    void BuyItem()
    {
        if (gameSession.spendCoins(cost))
        {
            Debug.Log("Bought: Increased Power Up Duration by +1");
            shopItem1.hasShopItem1 = true;
            shopItem1_.hasShopItem1 = true;
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}

using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public int cost = 50;
    public string increasedPwrUpDuration;

    public void BuyItem()
    {
        if (ScenePersist.Instance.spendCoins(cost))
        {
            Debug.Log("Bought: " + increasedPwrUpDuration);
            // Give item to player here (unlock weapon, powerup, etc.)
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}

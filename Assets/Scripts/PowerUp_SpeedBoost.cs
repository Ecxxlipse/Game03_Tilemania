using UnityEngine;

public class PowerUp_SpeedBoost : MonoBehaviour
{
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PowerUpHandler handler = collision.GetComponent<PowerUpHandler>();

            if (handler != null)
            {
                handler.ApplySpeedBoost(boostDuration);
            }
            
            Destroy(gameObject);
        }
    }
}

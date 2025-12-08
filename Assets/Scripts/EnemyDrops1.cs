using UnityEngine;

public class EnemyDrops1 : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    [SerializeField] float speedBoostDC = 0.2f;
    
    void DropPowerup()
    {
        if (powerups.Length > 0 && Random.value <= speedBoostDC)
        {
            int index = Random.Range(0, powerups.Length);

            Instantiate(powerups[index], transform.position, Quaternion.identity);
        }
        
    }

    void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            DropPowerup();
            
        }
    }
}

using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    [SerializeField] float jumpBoostDC = 0.2f;
    
    void DropPowerup()
    {
        if (powerups.Length > 0 && Random.value <= jumpBoostDC)
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

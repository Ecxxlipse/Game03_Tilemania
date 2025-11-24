using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    [SerializeField] float dropChance = 0.2f;
    public void DropPowerup()
    {
        if (powerups.Length > 0 && Random.value <= dropChance)
        {
            int index = Random.Range(0, powerups.Length);

            Instantiate(powerups[index], transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            DropPowerup();
        }
    }
}

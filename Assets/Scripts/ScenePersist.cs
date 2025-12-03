using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    public static ScenePersist Instance;
    GameSession getScore;
    public int playerScore = 0;

    void Start()
    {
        getScore = GetComponent<GameSession>();
        playerScore = getScore.score;
    }
    void Awake()
    {
        int numberScenePersists = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if (numberScenePersists > 1)
        {
            Instance = this;
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }

    public bool spendCoins(int amount)
    {
        if (playerScore >= amount)
        {
            playerScore -= amount;
            return true;
        }
        return false;
    }
}

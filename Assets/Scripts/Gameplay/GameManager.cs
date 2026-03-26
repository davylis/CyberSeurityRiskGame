using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //player data
    public string playerName;
    public string playerDegree;
    public string age;
    public int score;
    public bool agreedToResearch = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
    }
}

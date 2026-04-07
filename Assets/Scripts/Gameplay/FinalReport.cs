using UnityEngine;
using TMPro;

public class FinalReport : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text totalScoreText;
    public TMP_Text ratingText;

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is NULL!");
            return;
        }

        var gm = GameManager.Instance;

        int score = gm.score;

        Debug.Log("REPORT playerName: " + gm.playerName);
        Debug.Log("REPORT score: " + gm.score);

        if (ratingText != null)
            ratingText.text = GetRating(score);

        if (playerNameText != null)
            playerNameText.text = gm.playerName;

        if (totalScoreText != null)
            totalScoreText.text = "Score: " + gm.score + " / 52";
    }
    string GetRating(int score)
    {
        if (score <= 12)
            return "Beginner";

        else if (score <= 22)
            return "Script Kiddie";

        else if (score <= 32)
            return "Analyst";

        else if (score <= 42)
            return "System Breacher";

        else
            return "Hacker";
    }
}
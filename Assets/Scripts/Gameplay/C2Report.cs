using TMPro;
using UnityEngine;

public class C2Report : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text reportText;

    private void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager.Instance is NULL! Using test values.");
            reportText.text = "Test mode: no GameManager found.";
            scoreText.text = "Case 2 Score: 0 / 7";
            return;
        }
        
        int score = GameManager.Instance.case2Score;

        Debug.Log("Report reading score: " + score);

        if (score > 3)
        {
            reportText.text = "You understood that even public information can reveal private details when combined.";
        }
        else
        {
            reportText.text = "You identified very little of the available information.";
        }

        scoreText.text = "Score: " + score + " / 7";
    }
}
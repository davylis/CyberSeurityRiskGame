using UnityEngine;
using TMPro;

public class FinalReport : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject finalReportPanel;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is NULL!");
            return;
        }

        int totalScore = GameManager.Instance.score;

        // ✅ Show total score
        scoreText.text = totalScore + " / 50";
    }
}
using TMPro;
using UnityEngine;

public class C2Report : MonoBehaviour
{
    public TMP_Text scoreText;

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Case 2 Score: " + GameManager.Instance.score + " / 7";
            Debug.Log("Report opened. Case 2 score: " + GameManager.Instance.score);
        }
    }
}
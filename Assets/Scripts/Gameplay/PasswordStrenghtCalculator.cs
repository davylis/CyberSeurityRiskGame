using UnityEngine;
using TMPro;
using Zxcvbn;

public class PasswordStrenghtCalculator : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public C3Manager reportManager;
public void EvaluatePassword()
    {
        if (reportManager == null)
        {
            Debug.LogError("C3Manager not assigned!");
            return;
        }

        string password = passwordInput.text;

        if (string.IsNullOrEmpty(password))
        {
            reportManager.ShowReport("weak");
            return;
        }

        // Evaluate password using Zxcvbn
        var result = Core.EvaluatePassword(password);

        Debug.Log("Password: " + password);
        Debug.Log("Zxcvbn Score (0-4): " + result.Score);
        Debug.Log("Estimated Crack Time: " + result.CrackTimeDisplay);

        // Map Zxcvbn score (0–4) to 0–6 scale for your 6 panels
        int score = MapZxcvbnScoreToSix(result.Score);

        string strength = MapScoreToStrength(score);
        reportManager.ShowReport(strength);
    }

    private int MapZxcvbnScoreToSix(int zxcvbnScore)
    {
        // Linear mapping from 0–4 → 0–6
        return Mathf.RoundToInt((zxcvbnScore / 4f) * 6f);
    }

    private string MapScoreToStrength(int score)
    {
        switch (score)
        {
            case 0: return "weak";
            case 1: return "weak";
            case 2: return "medium";
            case 3: return "strong";
            case 4: return "verystrong";
            case 5: return "veryverystrong";
            case 6: return "superstrong";
            default: return "weak";
        }
    }
}
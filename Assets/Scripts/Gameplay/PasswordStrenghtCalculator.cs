using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
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
        int score = result.Score;

        string strength = MapScoreToStrength(score, password);
        reportManager.ShowReport(strength);
    }
        private string MapScoreToStrength(int score, string password)
    {
        if (score <= 1)
            return "weak";

        if (score == 2)
            return "medium";

        if (score == 3)
            return "strong";

        if (!LooksReadable(password) && password.Length > 13)
            return "superstrong";

        return "verystrong";
    }
    bool LooksReadable(string password)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(
        password,
        @"^([A-Z]?[a-z]+([-_ ][A-Z]?[a-z]+)+\d{1,4}[!@#$%^&*]?)$|^([A-Z]?[a-z]+(?:[A-Z][a-z]+)+\d{1,4}[!@#$%^&*]?)$"
        );
    }
}
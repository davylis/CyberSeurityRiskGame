using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //player data
    public string playerName;
    public string playerDegree;
    public string age;
    public int score;
    public bool agreedToResearch = false;

    public int case1Score = 0;
    public int case2Score = 0;
    public int case3Score = 0;
    public int case4Score = 0;
    public int case5Score = 0;
    public int case6Score = 0;
    public int case7Score = 0;
    public int case8Score = 0;
    public int case9Score = 0;
    public int case10Score = 0;
    public int case11Score = 0;

    //saved data
    public List<int> case5Choices = new List<int>();
    public List<int> case6Choices = new List<int>();
    public List<int> case7Choices = new List<int>();
    public List<int> case8Choices = new List<int>();
    public List<int> case9Choices = new List<int>();
    public List<int> case10Choices = new List<int>();
    public List<int> case11Choices = new List<int>();

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
        Debug.Log("Added total points: " + points + " | Total score: " + score);
    }
    public void AddCase1Points(int points)
    {
        case1Score += points;
        score += points;

        Debug.Log("Case 1 score: " + case1Score);
        Debug.Log("Total score: " + score);
    }
    public void AddCase2Points(int points)
    {
        case2Score += points;
        score += points;

        Debug.Log("Case 2 score: " + case2Score);
        Debug.Log("Total score: " + score);
    }
    public void AddCase3Points(int points)
    {
        case3Score += points;
        score += points;

        Debug.Log("Case 3 score: " + case3Score);
        Debug.Log("Total score: " + score);
    }
    public void AddCase4Points(int points)
    {
        case4Score += points;
        score += points;

        Debug.Log("Case 4 score: " + case4Score);
        Debug.Log("Total score: " + score);
    }
    public void AddCase5Points(int points)
    {
        case5Score += points;
        score += points;

        Debug.Log("Case 5 score: " + case5Score);
        Debug.Log("Total score: " + score);
    }

    //1 toggle is selected, 0 toggle is not selected
    public void SaveCase5Choices(List<int> choices)
    {
        case5Choices = new List<int>(choices);

        Debug.Log("Saved Case 5 choices:");
        for (int i = 0; i < case5Choices.Count; i++)
        {
            Debug.Log("Toggle " + i + ": " + case5Choices[i]);
        }
    }
    public void AddCase6Points(int points)
    {
        case6Score += points;
        score += points;

        Debug.Log("Case 6 score: " + case6Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase6Choices(List<int> choices)
    {
        case6Choices = new List<int>(choices);

        Debug.Log("Saved Case 6 choices:");
        for (int i = 0; i < case6Choices.Count; i++)
        {
            Debug.Log("Toggle " + i + ": " + case6Choices[i]);
        }
    }
    public void AddCase7Points(int points)
    {
        case7Score += points;
        score += points;

        Debug.Log("Case 7 score: " + case7Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase7Choices(List<int> choices)
{
    case7Choices = new List<int>(choices);

    Debug.Log("Saved Case 7 player choices:");
    for (int i = 0; i < case7Choices.Count; i++)
    {
        Debug.Log("Prompt " + i + ": " + case7Choices[i]);
    }
}
    public void AddCase8Points(int points)
    {
        case8Score += points;
        score += points;

        Debug.Log("Case 8 score: " + case8Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase8Choices(List<int> choices)
    {
        case8Choices = new List<int>(choices);

        Debug.Log("Saved Case 8 choices:");
        for (int i = 0; i < case8Choices.Count; i++)
        {
            Debug.Log("Question " + i + " selected answer: " + case8Choices[i]);
        }
    }
    public void AddCase9Points(int points)
    {
        case9Score += points;
        score += points;

        Debug.Log("Case 9 score: " + case9Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase9Choices(List<int> choices)
    {
        case9Choices = new List<int>(choices);

        Debug.Log("Saved Case 9 choices:");
        for (int i = 0; i < case9Choices.Count; i++)
        {
            Debug.Log("Question " + i + " selected answer: " + case9Choices[i]);
        }
    }
    public void AddCase10Points(int points)
    {
        case10Score += points;
        score += points;

        Debug.Log("Case 10 score: " + case10Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase10Choices(List<int> choices)
    {
        case10Choices = new List<int>(choices);

        Debug.Log("Saved Case 10 choices:");
        for (int i = 0; i < case10Choices.Count; i++)
        {
            Debug.Log("Question " + i + " selected answer: " + case10Choices[i]);
        }
    }
    public void AddCase11Points(int points)
    {
        case11Score += points;
        score += points;

        Debug.Log("Case 11 score: " + case11Score);
        Debug.Log("Total score: " + score);
    }
    public void SaveCase11Choices(List<int> choices)
    {
        case11Choices = new List<int>(choices);

        Debug.Log("Saved Case 11 choices:");
        for (int i = 0; i < case11Choices.Count; i++)
        {
            Debug.Log("Question " + i + " selected answer: " + case11Choices[i]);
        }
    }
}

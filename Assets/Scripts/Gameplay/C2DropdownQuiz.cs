using TMPro;
using UnityEngine;

public class C2DropdownQuiz : MonoBehaviour
{
    public TMP_Dropdown[] dropdowns;
    public int[] correctOptionIndexes;
    public int case2Score = 0;

    public void CheckAnswers()
    {
        if (dropdowns == null || correctOptionIndexes == null)
        {
            return;
        }

        if (dropdowns.Length != correctOptionIndexes.Length)
        {
            return;
        }

        int correctCount = 0;

        for (int i = 0; i < dropdowns.Length; i++)
        {
            int selected = dropdowns[i].value;
            int correct = correctOptionIndexes[i];

            Debug.Log("Q" + (i + 1) + " selected: " + selected + " | correct: " + correct);

            if (selected == correct)
            {
                correctCount++;
            }
        }

        case2Score = correctCount;

        Debug.Log("Correct answers: " + correctCount + " / " + dropdowns.Length);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddPoints(correctCount);
            Debug.Log("Added points: " + correctCount);
            Debug.Log("Total GameManager score: " + GameManager.Instance.score);
        }
       
}
}
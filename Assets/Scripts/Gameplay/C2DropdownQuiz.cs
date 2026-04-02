using TMPro;
using UnityEngine;

public class C2DropdownQuiz : MonoBehaviour
{
    public TMP_Dropdown[] dropdowns;
    public int[] correctOptionIndexes;
    private bool alreadyChecked = false;
    public GameObject GameRaport;

    public void CheckAnswers()
    {
        Debug.Log("CheckAnswers() CALLED");
        if (alreadyChecked) {
            Debug.Log("Already checked, skipping");
            return;
        }

        if (dropdowns == null || correctOptionIndexes == null)
        {
            Debug.LogError("Dropdowns or correctOptionIndexes NULL");
            return;
        }

        if (dropdowns.Length != correctOptionIndexes.Length)
        {
            Debug.LogError("Length mismatch");
            return;
        }

        int correctCount = 0;

        for (int i = 0; i < dropdowns.Length; i++)
        {
            int selected = dropdowns[i].value;
            int correct = correctOptionIndexes[i];

            Debug.Log("Q" + i + " selected: " + selected + " | correct: " + correct);

            if (selected == correct)
            {
                correctCount++;
            }
            else
            {
                Debug.LogError("GameManager is NULL!");
            }
        }

        if (GameManager.Instance != null)
        {
            Debug.Log("Saving to GameManager");
            GameManager.Instance.AddCase2Points(correctCount);
            alreadyChecked = true;
        }
       
    }
    public void YesRaport()
    {
        Debug.Log("YesRaport() CLICKED");
        CheckAnswers();
        Debug.Log("Opening report");
        GameRaport.SetActive(true);
    }
}
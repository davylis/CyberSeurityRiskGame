using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FormManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField degreeField;
    public TMP_InputField ageField;

    public Toggle agreementToggle;
    public GameObject popup;
    public GameObject popup2;

    public void SaveData()
    {
        GameManager.Instance.playerName = nameField.text;
        GameManager.Instance.playerDegree = degreeField.text;
        GameManager.Instance.age = ageField.text;

        Debug.Log("Saved Data:");
        Debug.Log("Name: " + GameManager.Instance.playerName);
        Debug.Log("Degree: " + GameManager.Instance.playerDegree);
        Debug.Log("Age: " + GameManager.Instance.age);
    }

    public void ContinueGame()
    {
        if (!agreementToggle.isOn)
        {
            if (popup != null)
                popup.SetActive(true);

            return;
        }

        if (string.IsNullOrWhiteSpace(nameField.text) ||
            string.IsNullOrWhiteSpace(degreeField.text) ||
            string.IsNullOrWhiteSpace(ageField.text))
        {
            if (popup2 != null)
                popup2.SetActive(true);

            return;
        }
        
        SaveData();
        SceneManager.LoadScene("PlayInfo");
    }
    public void ClosePopup()
    {
        if (popup != null)
            popup.SetActive(false);
    }

    public void ClosePopup2()
    {
        if (popup2 != null)
            popup2.SetActive(false);
    }
}

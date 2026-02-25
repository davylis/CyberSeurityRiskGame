using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FormManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField degreeField;
    public TMP_InputField ageField;

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
        SaveData();
        SceneManager.LoadScene("PlayInfo");
    }
}

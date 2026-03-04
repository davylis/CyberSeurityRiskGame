using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkipTaskPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public string taskSceneName;
    public void OpenPopup()
    {
        popupPanel.SetActive(true);
    }
    public void Yes()
    {
        popupPanel.SetActive(false);

        SceneManager.UnloadSceneAsync(taskSceneName);

        Time.timeScale = 1f;
    }
    public void No()
    {
        popupPanel.SetActive(false);
    }
}
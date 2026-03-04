using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReadyTaskPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject GameRaport;
    public string taskSceneName;
    public void OpenPopup()
    {
        popupPanel.SetActive(true);
    } 
    public void YesRaport()
    {
        GameRaport.SetActive(true);
    }
    public void NoContinue()
    {
        popupPanel.SetActive(false);
    }
}
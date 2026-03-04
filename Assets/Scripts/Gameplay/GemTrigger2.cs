using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemTrigger2 : MonoBehaviour
{
    public string taskScene = "Case2footprint"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(taskScene, LoadSceneMode.Additive);
            Time.timeScale = 0f; 
        }
    }
}
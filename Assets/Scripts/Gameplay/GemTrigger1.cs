using UnityEngine;
using UnityEngine.SceneManagement;

public class GemTrigger1 : MonoBehaviour
{
    public string taskScene = "Case1Privacy";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(taskScene, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
    }
}

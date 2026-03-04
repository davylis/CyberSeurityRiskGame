using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame1 : MonoBehaviour
{
    public string taskScene;
    public int pointsToAdd = 0;

    public void ReturnToGame()
    {
        SceneManager.UnloadSceneAsync(taskScene);
        Time.timeScale = 1f;
    }
}

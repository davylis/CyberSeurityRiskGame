using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("BOOTSTRAP AWAKE");
    }
    void Start()
    {
        Debug.Log("BOOTSTRAP STARTED");
        SceneManager.LoadScene("StartGame"); 
    }
}
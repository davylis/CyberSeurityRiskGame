using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCupTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched by: " + other.name);

        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("Player touched cup. Loading Raport...");
            SceneManager.LoadScene("Raport");
        }
    }
}
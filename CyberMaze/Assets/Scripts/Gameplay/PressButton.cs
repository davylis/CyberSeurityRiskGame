using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public void pressed()
    {
        Debug.Log("Button pressed");
        SceneManager.LoadScene("SampleScene");
    }
}

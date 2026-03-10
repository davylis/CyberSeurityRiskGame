using UnityEngine;

public class C4Manager : MonoBehaviour
{
    public GameObject taskDescription;
    public void SwitchScreen()
    {
        if (taskDescription != null)
            taskDescription.SetActive(false);  
    }
}
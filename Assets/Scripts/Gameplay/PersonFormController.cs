using UnityEngine;

public class PersonFormController : MonoBehaviour
{
    public GameObject personFormPanel;

    public void OpenForm()
    {
        personFormPanel.SetActive(true);
    }

    public void CloseForm()
    {
        personFormPanel.SetActive(false);
    }
}
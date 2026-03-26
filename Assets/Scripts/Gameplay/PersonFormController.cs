using UnityEngine;

public class PersonFormController : MonoBehaviour
{
    public GameObject personFormPanel;
    public GameObject arrow2;

    public void OpenForm()
    {
        personFormPanel.SetActive(true);
        if (arrow2 != null) arrow2.SetActive(false);
    }

    public void CloseForm()
    {
        personFormPanel.SetActive(false);
    }
}
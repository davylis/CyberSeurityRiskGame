using UnityEngine;

public class EmailPopup : MonoBehaviour
{
    private GameObject currentEmail;

    public void OpenEmail(GameObject emailPanel)
    {
        if (currentEmail != null)
        {
            currentEmail.SetActive(false);
        }

        emailPanel.SetActive(true);
        emailPanel.transform.SetAsLastSibling();

        currentEmail = emailPanel;
    }
}
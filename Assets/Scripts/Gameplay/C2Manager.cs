using UnityEngine;

public class C2Manager : MonoBehaviour
{
    public GameObject searchPanel;
    public GameObject resultsPanel;

    public void ShowResults()
    {
        searchPanel.SetActive(false);
        resultsPanel.SetActive(true);
    }

    public void ShowSearch()
    {
        resultsPanel.SetActive(false);
        searchPanel.SetActive(true);
    }
}

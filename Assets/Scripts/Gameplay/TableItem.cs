using UnityEngine;
using UnityEngine.UI;

public class TableItem : MonoBehaviour
{
    private bool collected = false;

    public void OnClick()
    {
        if (collected) return;

        collected = true;

        C4GManager.Instance.AddItem();

        gameObject.SetActive(false);
    }
}
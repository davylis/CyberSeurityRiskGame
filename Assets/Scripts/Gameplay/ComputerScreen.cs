using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    public Image goodbyeImage;
    public Image blackImage;

    public float delay = 1f;

    public void OnScreenPressed()
    {
        StartCoroutine(ScreenSequence());
    }

    IEnumerator ScreenSequence()
    {
        goodbyeImage.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(delay);

        blackImage.gameObject.SetActive(true);
        goodbyeImage.gameObject.SetActive(false);
    }
}
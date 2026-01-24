using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PhoneUIController : MonoBehaviour
{
    public Button actionButton;
    public TextMeshProUGUI buttonText;
    public GameObject appScreen;

    private bool installed = false;

    public Color installedColor;
    public Color pressedInstalledColor;
    public Color highlightedInstalledColor;

    void Awake()
    {
        ColorUtility.TryParseHtmlString("#FB14FF", out installedColor);          // normal
        ColorUtility.TryParseHtmlString("#C010C9", out pressedInstalledColor);  // pressed
        ColorUtility.TryParseHtmlString("#FF5CFF", out highlightedInstalledColor); // hover
    }

    public void OnActionButtonClicked()
    {
        if (!installed)
        {
            installed = true;

            // Change text
            buttonText.text = "Open";

            // Change button colors
            var colors = actionButton.colors;

            colors.normalColor = installedColor;                 // normal
            colors.highlightedColor = pressedInstalledColor;  // hover
            colors.pressedColor = pressedInstalledColor;         // pressed
            colors.selectedColor = installedColor;               // selected = normal (IMPORTANT)

            actionButton.colors = colors;
        }
        else
        {
            // Second click → open app
            appScreen.SetActive(true);
            Debug.Log("App opened!");
        }

        // 🔥 Clear selection so it doesn't stay dark
        EventSystem.current.SetSelectedGameObject(null);
    }
}

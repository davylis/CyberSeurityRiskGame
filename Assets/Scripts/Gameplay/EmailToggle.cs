using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailToggle : MonoBehaviour
{
    public Toggle toggle;
    public bool isSuspicious;

    public bool IsCorrect()
    {
        return toggle.isOn == isSuspicious;
    }
}
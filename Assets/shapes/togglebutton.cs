using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class togglebutton : MonoBehaviour
{
   [SerializeField] private Toggle toggle;
    [SerializeField] private RectTransform uiHandleRectTransform;

    private Vector2 handlePosition;

    private void Awake()
    {
        if (toggle == null)
            toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
        else
            OnSwitch(false);
    }

    private void OnSwitch(bool on)
    {
        uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}

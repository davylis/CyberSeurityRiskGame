using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4GManager : MonoBehaviour
{
    public static C4GManager Instance;

    public int collectedItems = 0;
    public int totalItems = 5;

    void Awake()
    {
        Instance = this;
    }

    public void AddItem()
    {
        collectedItems++;
        Debug.Log("Items collected: " + collectedItems);
    }

    public int CalculatePoints()
    {
        return collectedItems;
    }
}
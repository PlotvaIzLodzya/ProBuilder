using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private GameObject _building;

    private void Start()
    {
        OnLoad(_building);
    }

    private void OnLoad(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }
}

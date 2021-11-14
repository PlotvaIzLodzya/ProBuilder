using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private GameObject _building;

    private void Start()
    {
        EnableOnLoad(_building);
    }

    private void EnableOnLoad(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }
}

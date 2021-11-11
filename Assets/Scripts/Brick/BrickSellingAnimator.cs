using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class BrickSellingAnimator : MonoBehaviour
{
    [SerializeField] private SellPoint sellPoint;
    [SerializeField] private SellingTextAnimation _text;

    private void OnEnable()
    {
        sellPoint.BrickSold += ShowText;
    }

    private void OnDisable()
    {
        sellPoint.BrickSold -= ShowText;
    }

    private void ShowText(int value, Vector3 spawnPoint)
    {
        SellingTextAnimation text =Instantiate(_text, spawnPoint, _text.transform.rotation);
        text.SetText(value);
    }
}

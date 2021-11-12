using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickSellingAnimator : MonoBehaviour
{
    [SerializeField] private CollectionArea _collectionArea;
    [SerializeField] private SellingTextAnimation _text;

    private void OnEnable()
    {
        _collectionArea.Collected += ShowText;
    }

    private void OnDisable()
    {
        _collectionArea.Collected -= ShowText;
    }

    private void ShowText(Brick brick)
    {
        SellingTextAnimation text = Instantiate(_text, brick.transform.position, _text.transform.rotation);
        text.SetText(brick.Price);
    }
}

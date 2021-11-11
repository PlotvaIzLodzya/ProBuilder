using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _price;

    private BrickPlace _brickPlace;

    public int Price => _price;

    public void Init(BrickPlace brickPlace)
    {
        _brickPlace = brickPlace;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bag bag))
        {
            bag.Put();
            _brickPlace.Free();
            Destroy(gameObject);
        }
    }
}

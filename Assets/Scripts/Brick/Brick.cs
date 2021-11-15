using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _price;
    
    public int Price => _price;

    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bag bag))
        {
            bag.Put();
            Taken?.Invoke();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public event UnityAction Taken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bag bag))
        {
            CollectToBag(bag);
            bag.Put();

            if (gameObject.TryGetComponent(out Flyable fly))
                fly.StopFlying();

            Taken?.Invoke();
        }
    }

    private void CollectToBag(Bag bag)
    {
        this.transform.SetParent(bag.transform);
        this.transform.position = bag.BrickContainer.Places[bag.BrickCount].transform.position;
        transform.rotation = bag.BrickContainer.Places[bag.BrickCount].transform.rotation;
    }
}

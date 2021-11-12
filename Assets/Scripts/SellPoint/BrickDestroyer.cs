using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Brick brick))
            Destroy(other.gameObject);
    }
}

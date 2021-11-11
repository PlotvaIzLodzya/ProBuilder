using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Init(Vector3 targetPosition, Quaternion targetRotation)
    {
       StartCoroutine(FlyAnimation(targetPosition, targetRotation));
    }

    private IEnumerator FlyAnimation(Vector3 targetPosition, Quaternion targetRotation)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1);
            yield return null;
        }
    }
}

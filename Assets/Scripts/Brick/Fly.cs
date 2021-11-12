using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    public void InitFlyRoute(Vector3 targetPosition, Quaternion targetRotation)
    {
       StartCoroutine(FlyAnimation(targetPosition, targetRotation));
    }

    private IEnumerator FlyAnimation(Vector3 targetPosition, Quaternion targetRotation)
    {
        transform.SetParent(null);

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
            yield return null;
        }
    }
}

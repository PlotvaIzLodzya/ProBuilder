using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private BrickContainer _brickContainer;
    [SerializeField] private int _brickCount = 0;
    [SerializeField] private BoxCollider _brickCollector;

    public int BrickCount => _brickCount;
    public BrickContainer BrickContainer => _brickContainer;
    private bool _isFull => _brickCount >= _brickContainer.Places.Count;

    public event UnityAction BrickCollected;
    public event UnityAction BrickGiven;

    public void Put()
    {
         BrickCollected?.Invoke();
        _brickCount++;

        if (_isFull)
            _brickCollector.enabled = false;
    }

    public Brick GiveBrick(Vector3 targetPosition, Quaternion targetRotation)
    {
        Brick brick = null;

        if (_brickCount > 0)
        {
            _brickCount--;

            brick = transform.GetChild(_brickCount).GetComponent<Brick>();

            BrickGiven?.Invoke();

            if (_brickCollector.enabled == false && _isFull == false)
                _brickCollector.enabled = true;
        }

        return brick;
    }
}

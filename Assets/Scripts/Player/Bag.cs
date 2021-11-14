using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private BrickContainer _bag;
    [SerializeField] private Brick _brick;
    [SerializeField] private int _brickCount = 0;
    [SerializeField] private BoxCollider _brickCollector;

    public int BrickCount => _brickCount;
    private bool _isFull => _brickCount >= _bag.Places.Count;

    public event UnityAction BrickCollected;
    public event UnityAction BrickGiven;

    public void Put()
    {
        Brick newBrick = Instantiate(_brick, _bag.Places[_brickCount].transform.position, _bag.Places[_brickCount].transform.rotation);
        newBrick.transform.SetParent(this.transform);
        newBrick.SetIndex(_brickCount);

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

            if (_isFull == false)
                _brickCollector.enabled = true;

            BrickGiven?.Invoke();

            return brick;
        }

        return brick;
    }
}

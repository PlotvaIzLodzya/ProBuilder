using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BrickHolder))]
public class Bag : MonoBehaviour
{
    [SerializeField] private BrickHolder _bag;
    [SerializeField] private Brick _brick;
    [SerializeField] private int _brickCount = 0;
    [SerializeField] private BoxCollider _brickCollector;

    private  bool _isFull => _brickCount >= _bag.Places.Count;

    public void Put()
    {
        Brick newBrick = Instantiate(_brick, _bag.Places[_brickCount].transform.position, _bag.Places[_brickCount].transform.rotation);
        _brickCount++;
        newBrick.transform.SetParent(this.transform);

        if (_isFull)
        {
            _brickCollector.enabled = false;
        }
    }

    public Brick TakeBrick(Vector3 targetPosition, Quaternion targetRotation)
    {
        Brick brick = null;

        if (_brickCount > 0)
        {
            _brickCount--;
            brick = transform.GetChild(_brickCount).GetComponent<Brick>();
            Fly fly = brick.GetComponent<Fly>();
            fly.transform.SetParent(null);
            fly.Init(targetPosition, targetRotation);

            if (_isFull == false)
            {
                _brickCollector.enabled = true;
            }

            return brick;
        }

        return brick;
    }
}

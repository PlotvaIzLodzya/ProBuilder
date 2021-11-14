using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickPlace : MonoBehaviour
{
    [SerializeField] private bool _isInfinite;

    private Brick _brick;
    public bool IsAvailible { get; private set; }

    public event UnityAction<BrickPlace> PlaceFree;
    public event UnityAction PlaceTaken;

    private void Start()
    {
        IsAvailible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Brick brick) && _brick == brick)
        {
            PlaceTaken?.Invoke();
        }
    }

    public void Reserve(Brick brick)
    {
        IsAvailible = _isInfinite;
        _brick = brick;
        _brick.Taken += Free;
    }

    public void Free()
    {
        IsAvailible = true;
        PlaceFree?.Invoke(this);
        _brick.Taken -= Free;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickPlace : MonoBehaviour
{
    [SerializeField] private bool _isInfinite;

    public bool IsAvailible { get; private set; }

    public event UnityAction<BrickPlace> FreePlace;

    private void Start()
    {
        IsAvailible = true;
    }

    public void Take()
    {
        if (_isInfinite == false)
            IsAvailible = false;
    }

    public void Free()
    {
        IsAvailible = true;
        FreePlace?.Invoke(this);
    }
}

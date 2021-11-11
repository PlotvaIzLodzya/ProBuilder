using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickPlace : MonoBehaviour
{
    public bool IsAvailible { get; private set; }

    public event UnityAction<BrickPlace> NeedBrick;

    private void Start()
    {
        IsAvailible = true;
    }

    public void Take()
    {
        IsAvailible = false;
    }

    public void Free()
    {
        IsAvailible = true;
        NeedBrick?.Invoke(this);
    }
}

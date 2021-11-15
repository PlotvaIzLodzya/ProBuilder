using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction OnPointerPressed;
    public event UnityAction OnPointerReleased;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            OnPointerPressed?.Invoke();

        if (Input.GetMouseButtonUp(0))
            OnPointerReleased?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInput),typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private Player _player;
    private Pointer _pointer;

    private void Start()
    {
        _pointer = GetComponent<Pointer>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnPointerPressed += Move;
    }

    private void OnDisable()
    {
        _playerInput.OnPointerPressed -= Move;
    }

    private void Move()
    {
        Vector3 direction = _pointer.GetPoint() - transform.position;

        Rotate(direction);
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover),typeof(Rigidbody),typeof(PlayerInput))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnPointerPressed += PlayWalkingAnimation;
        _playerInput.OnPointerReleased += PlayerIdleAnimation;
    }

    private void OnDisable()
    {
        _playerInput.OnPointerPressed -= PlayWalkingAnimation;
        _playerInput.OnPointerReleased -= PlayerIdleAnimation;
    }

    private void PlayWalkingAnimation()
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 2);
    }

    private void PlayerIdleAnimation()
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 0);
    }
}

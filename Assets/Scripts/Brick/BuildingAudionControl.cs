using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingAudionControl : AudioControl
{
    [SerializeField] private BrickContainer brickContainer;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        brickContainer.BrickPlaced += PlayClip;
    }

    private void OnDisable()
    {
        brickContainer.BrickPlaced -= PlayClip;
    }

    private void PlayClip()
    {
        _audioSource.pitch = _startPitch + Math.Abs(_player.Bag.BrickCount) * _pitchPerBrick;
        _audioSource.PlayOneShot(_audioClip, 1);
        _audioSource.pitch += _pitchPerBrick;
        Mathf.Clamp(_audioSource.pitch, 1, _maxPitch);
    }
}

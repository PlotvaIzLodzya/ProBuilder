using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAudioControl : AudioControl
{
    [SerializeField] private Bag _bag;

    private void OnEnable()
    {
        _bag.BrickCollected += PlayClip;
    }

    private void OnDisable()
    {
        _bag.BrickCollected -= PlayClip;
    }

    private void PlayClip(int brickCount)
    {
        _audioSource.pitch = _startPitch + Math.Abs(brickCount) * _pitchPerBrick;
        _audioSource.PlayOneShot(_audioClip, 1);
        _audioSource.pitch += _pitchPerBrick;
        Mathf.Clamp(_audioSource.pitch, 1, _maxPitch);
    }
}

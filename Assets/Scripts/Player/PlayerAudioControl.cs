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
        _bag.BrickGiven += DecreasetPitch;
    }

    private void OnDisable()
    {
        _bag.BrickCollected -= PlayClip;
        _bag.BrickGiven -= DecreasetPitch;
    }
}

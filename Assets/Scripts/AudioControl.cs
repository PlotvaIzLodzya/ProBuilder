using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    [SerializeField] protected AudioClip _audioClip;
    [SerializeField] protected float _maxPitch;
    [SerializeField] protected float _pitchPerBrick;
    [SerializeField] protected float _startPitch;

    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}


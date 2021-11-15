using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    [SerializeField] protected AudioClip AudioClip;
    [SerializeField] protected float MaxPitch;
    [SerializeField] protected float PitchPerBrick;
    [SerializeField] protected float MinPitch;

    protected float PitchLevel;
    private Coroutine _backWardCoroutine;

    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip()
    {
        IncreasePitch();
        Mathf.Clamp(_audioSource.pitch, 1, MaxPitch);
        _audioSource.PlayOneShot(AudioClip, 1);
    }

    public void PlayBackward()
    {
        if (_backWardCoroutine == null)
        {
            _backWardCoroutine = StartCoroutine(PlayBackwardCoroutine());
        }
    }

    private IEnumerator PlayBackwardCoroutine()
    {
        while (_audioSource.pitch > MinPitch)
        {
            DecreasetPitch();
            _audioSource.PlayOneShot(AudioClip, 1);

            yield return new WaitForSeconds(0.05f);
        }

        _backWardCoroutine = null;
    }

    protected void IncreasePitch()
    {
        _audioSource.pitch += PitchPerBrick;
    }

    protected void DecreasetPitch()
    {
        _audioSource.pitch -= PitchPerBrick;
        
    }

    private void PitchConstrain()
    {
        Mathf.Clamp(_audioSource.pitch, MinPitch, MaxPitch);
    }
}


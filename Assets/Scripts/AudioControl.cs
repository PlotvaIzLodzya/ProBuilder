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
    [SerializeField] protected float StartPitch;

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
        Debug.Log("asd");
        if (_backWardCoroutine == null)
        {
            _backWardCoroutine = StartCoroutine(PlayBackwardCoroutine());
        }
    }

    protected void StopBackwardsPlay()
    {
        if (_backWardCoroutine != null)
        {
            StopCoroutine(_backWardCoroutine);
        }

        _backWardCoroutine = null;
    }

    private IEnumerator PlayBackwardCoroutine()
    {
        while (_audioSource.pitch > StartPitch)
        {
            DecreasetPitch();
            _audioSource.PlayOneShot(AudioClip, 1);

            yield return new WaitForSeconds(0.05f);
        }
    }

    protected void IncreasePitch()
    {
        _audioSource.pitch += PitchPerBrick;
    }

    protected void DecreasetPitch()
    {
        _audioSource.pitch -= PitchPerBrick;
    }
}


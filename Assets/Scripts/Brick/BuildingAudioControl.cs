using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CollectionArea))]
public class BuildingAudioControl : AudioControl
{
    [SerializeField] private BrickContainer _brickContainer;

    private void OnEnable()
    {
        for (int i = 0; i < _brickContainer.Places.Count; i++)
        {
            _brickContainer.Places[i].PlaceTaken += PlayBackward;
        }

        _brickContainer.BuildingComplete += OnBuildingComplete;
    }

    private void OnDisable()
    {
        _brickContainer.BuildingComplete -= OnBuildingComplete;

        for (int i = 0; i < _brickContainer.Places.Count; i++)
        {
            _brickContainer.Places[i].PlaceTaken -= PlayBackward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            SetPitch(player.GetComponent<AudioSource>().pitch);
        }
    }

    public void SetPitch(float pitchLevel)
    {
        _audioSource.pitch = pitchLevel;
    }

    private void OnBuildingComplete()
    {
        if(BackWardCoroutine != null)
            StopCoroutine(BackWardCoroutine);
    }
}

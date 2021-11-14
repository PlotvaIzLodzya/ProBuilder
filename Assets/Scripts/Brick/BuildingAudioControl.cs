using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CollectionArea))]
public class BuildingAudioControl : AudioControl
{
    [SerializeField] private BrickContainer _brickContainer;
    private BuildingCollectionArea _collectionArea;

    private void OnEnable()
    {
        _collectionArea = GetComponent<BuildingCollectionArea>();

        _brickContainer.BuildingComplete += OnBuildingComplete;
        _collectionArea.Entered += StopBackwardsPlay;

        for (int i = 0; i < _brickContainer.Places.Count; i++)
        {
            _brickContainer.Places[i].PlaceTaken += PlayBackward;
        }
    }

    private void OnDisable()
    {
        _brickContainer.BuildingComplete -= OnBuildingComplete;
        _collectionArea.Entered -= StopBackwardsPlay;

        for (int i = 0; i < _brickContainer.Places.Count; i++)
        {
            _brickContainer.Places[i].PlaceTaken -= PlayBackward;
        }
    }

    public void SetPitch(float pitchLevel)
    {
        _audioSource.pitch = pitchLevel;
    }

    private void OnBuildingComplete()
    {
        StopBackwardsPlay();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingCollectionArea : CollectionArea
{
    public event UnityAction Entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Entered?.Invoke();

            GetComponent<BuildingAudioControl>().SetPitch(player.GetComponent<AudioSource>().pitch);

            CollectCoroutine = StartCoroutine(CollectFrom(player));
        }
    }
}

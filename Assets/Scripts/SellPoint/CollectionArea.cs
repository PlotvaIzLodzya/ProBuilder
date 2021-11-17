using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class CollectionArea : MonoBehaviour
{
    [SerializeField] protected BrickContainer _brickContainer;
    [SerializeField] protected BoxCollider _interactionZone;
    [SerializeField] protected float _collectionDelay;

    protected Coroutine CollectCoroutine;

    public event UnityAction<Brick> Collected;

    private void OnEnable()
    {
        Collected += OnBrickCollected;
    }

    private void OnDisable()
    {
        Collected -= OnBrickCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            CollectCoroutine = StartCoroutine(CollectFrom(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if (CollectCoroutine != null)
                StopCoroutine(CollectCoroutine);
        }
    }

    protected IEnumerator CollectFrom(Player player)
    {
        Brick brick = null;

        while (Physics.CheckBox(_interactionZone.center, _interactionZone.size))
        {
            BrickPlace place = _brickContainer.Places.FirstOrDefault(place => place.IsAvailible);
            
            if(place != default)
            {
                brick = player.Bag.GiveBrick(place.transform.position, place.transform.rotation);

                if (brick != null)
                {
                    Flyable fly = brick.GetComponent<Flyable>();
                    fly.InitFlyRoute(place.transform.position, place.transform.rotation);

                    place.Reserve(brick);

                    Collected?.Invoke(brick);
                }
            }

            yield return new WaitForSeconds(_collectionDelay);
        }
    }

    private void OnBrickCollected(Brick brick)
    {
        _brickContainer.AddBrick();
    }
}

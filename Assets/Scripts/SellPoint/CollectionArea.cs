using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class CollectionArea : MonoBehaviour
{
    [SerializeField] private BrickContainer _brickContainer;
    [SerializeField] private BoxCollider _interactionZone;
    [SerializeField] private float _collectionDelay;

    private Coroutine _CollectCoroutine;
    private bool IsSellingArea;

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

            _CollectCoroutine = StartCoroutine(CollectFrom(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if (_CollectCoroutine != null)
                StopCoroutine(_CollectCoroutine);
        }
    }

    private IEnumerator CollectFrom(Player player)
    {
        Brick brick = null;

        while (Physics.CheckBox(_interactionZone.center, _interactionZone.size))
        {
            BrickPlace place = _brickContainer.Places.FirstOrDefault(place => place.IsAvailible);
            
            if(place != default)
            {
                brick = player.Bag.TakeBrick(place.transform.position, place.transform.rotation);

                if (brick != null)
                {
                    Fly fly = brick.GetComponent<Fly>();
                    fly.InitFlyRoute(place.transform.position, place.transform.rotation);
                    place.Take();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildPoint : MonoBehaviour
{
    [SerializeField] private BrickHolder _brickHolder;
    [SerializeField] private BoxCollider _buildZone;

    private Coroutine _buildCoroutine;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _buildCoroutine = StartCoroutine(Build(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if (_buildCoroutine != null)
                StopCoroutine(_buildCoroutine);
        }
    }

    private IEnumerator Build(Player player)
    {
        Brick brick = null;

        while (Physics.CheckBox(_buildZone.center, _buildZone.size))
        {
            BrickPlace place = _brickHolder.Places.FirstOrDefault(place => place.IsAvailible);
            
            if(place != default)
            {
                brick = player.Bag.TakeBrick(place.transform.position, place.transform.rotation);

                if (brick != null)
                {
                    place.Take();
                    _brickHolder.OnBrickAdded();
                }
            }

            yield return new WaitForSeconds(0.1f);

        }
    }
}

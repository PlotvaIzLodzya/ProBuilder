using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SellPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private BoxCollider _sellZone;

    private Coroutine _sellCoroutine;

    public event UnityAction<int, Vector3> BrickSold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _sellCoroutine = StartCoroutine(Sell(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            if(_sellCoroutine!=null)
                StopCoroutine(_sellCoroutine);
        }
    }

    private IEnumerator Sell(Player player)
    {
        while(Physics.CheckBox(_sellZone.center, _sellZone.size))
        {
            Brick brick = player.Bag.TakeBrick(_target.position, _target.rotation);

            if (brick != null)
            {
                player.AddMoney(brick.Price);
                BrickSold?.Invoke(brick.Price, brick.transform.position);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}

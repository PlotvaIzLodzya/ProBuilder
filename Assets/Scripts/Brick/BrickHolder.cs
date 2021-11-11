using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class BrickHolder : MonoBehaviour
{
    [SerializeField] private List<BrickPlace> _places;

    private int _maxBricksAmount => _places.Count;
    private int _currentBricksAmount;

    public event UnityAction<BrickPlace> HaveFreePlace;
    public event UnityAction<int, int> BrickAmountChanged;

    public List<BrickPlace> Places => _places;

    private void Start()
    {
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _places.Add(transform.GetChild(i).GetComponent<BrickPlace>());
            _places[i].NeedBrick += OnBrickTaken;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _places[i].NeedBrick -= OnBrickTaken;
        }
    }

    private void OnBrickTaken(BrickPlace position)
    {
        _currentBricksAmount--;
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
        HaveFreePlace?.Invoke(position);
    }

    public void OnBrickAdded()
    {
        _currentBricksAmount++;
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }
}

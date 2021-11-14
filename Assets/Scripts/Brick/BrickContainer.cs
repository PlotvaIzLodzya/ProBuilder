using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class BrickContainer : MonoBehaviour
{
    [SerializeField] private List<BrickPlace> _places;

    private int _currentBricksAmount;

    public List<BrickPlace> Places => _places;
    private int _maxBricksAmount => _places.Count;

    public event UnityAction<int, int> BrickAmountChanged;
    public event UnityAction BrickPlaced;
    public event UnityAction BuildingComplete;

    private void Start()
    {
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _places.Add(transform.GetChild(i).GetComponent<BrickPlace>());
            _places[i].PlaceTaken += OnPlaceTaken;
            _places[i].PlaceFree += OnBrickTaken;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _places[i].PlaceTaken -= OnPlaceTaken;
            _places[i].PlaceFree -= OnBrickTaken;
        }
    }

    public void AddBrick()
    {
        _currentBricksAmount++;
        BrickPlaced?.Invoke();

        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnBrickTaken(BrickPlace position)
    {
        _currentBricksAmount--;
        BrickAmountChanged?.Invoke(_currentBricksAmount, _maxBricksAmount);
    }

    private void OnPlaceTaken()
    {
        if (_currentBricksAmount>=_maxBricksAmount)
        {
            BuildingComplete?.Invoke();
        }
    }
}

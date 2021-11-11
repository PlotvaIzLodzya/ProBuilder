using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private int _money = 0;

    public event UnityAction<int> OnMoneyChange;

    public Bag Bag => _bag;

    public void AddMoney(int value)
    {
        _money += value;
        OnMoneyChange?.Invoke(value);
    }
}

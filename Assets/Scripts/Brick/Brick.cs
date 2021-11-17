using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collectable))]
public class Brick : MonoBehaviour
{
    [SerializeField] private int _price;
    
    public int Price => _price;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettings : MonoBehaviour
{
    [SerializeField] private int minObjects;
    [SerializeField] private int maxObjects;

    [SerializeField] private int minEnemys;
    [SerializeField] private int maxEnemys;

    public int MinObjects => minObjects;
    public int MaxObjects => maxObjects;

    public int MinEnemys => minEnemys;
    public int MaxEnemys => maxEnemys;
}

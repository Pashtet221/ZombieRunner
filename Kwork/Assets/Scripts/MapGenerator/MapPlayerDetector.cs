using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerDetector : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Map map;
    [SerializeField] private MapPartGenerator mapPartGenerator;
    private MapPart currentMapPart;

    private void Awake()
    {
        mapPartGenerator.OnMapGenerated += PrepareDetector;
    }

    private void PrepareDetector()
    {
        mapPartGenerator.OnMapGenerated -= PrepareDetector;
        currentMapPart = map.GetMapPartByID(0);
    }

    public void Update()
    {
        if (currentMapPart == null) return;
        if(player.position.x > currentMapPart.MaxBounds.x)
        {
            ChoseNewMapPartOrCreateNew();
        }
    }

    private void ChoseNewMapPartOrCreateNew()
    {
        mapPartGenerator.GenerateMapPart();
        if(map.MapParts.Count > 3)
            map.RemoveByID(0);
        currentMapPart = map.GetMapPartByID(map.MapParts.Count - 2);
    }

}

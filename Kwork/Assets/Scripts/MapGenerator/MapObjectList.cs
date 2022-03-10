using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapObjects", menuName = "ScriptableObjects/Objects", order = 1)]
public class MapObjectList : ScriptableObject
{
    [SerializeField] private List<MapObjectParam> mapObjects = new List<MapObjectParam>();

    public IReadOnlyCollection<MapObjectParam> MapObjectsParam => mapObjects;

}

[System.Serializable]
public struct MapObjectParam
{
    [Range(0,100)]
    [Tooltip("Частота спавна")]
    public int SpawnFrequency;
    [Tooltip("Объект должен имплементировать интерфейс IMapObject")]
    public GameObject Object;
}

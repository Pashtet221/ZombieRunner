using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<MapPart> mapParts = new List<MapPart>();


    public IReadOnlyCollection<MapPart> MapParts => mapParts;

    public void AddMapPart(MapPart mapPart)
    {
        mapPart.ID = mapParts.Count;
        mapParts.Add(mapPart);
    }

    public MapPart GetMapPartByID(int id)
    {
        if (mapParts.Count > 0 && id < mapParts.Count)
            return mapParts[id];

        return null;
    }

    public void RemoveByID(int id)
    {
        if (mapParts.Count > 0 && id < mapParts.Count)
        {
            MapPart mapPart = mapParts[id];
            mapParts.RemoveAt(id);
            Destroy(mapPart.gameObject);
        }
    }

    public MapPart GetLastMapPart()
    {
        if (mapParts.Count > 0)
            return mapParts[mapParts.Count - 1];

        return null;
    }

    public float GetLastMapPartWidht()
    {
        if (mapParts.Count > 0)
            return mapParts[mapParts.Count - 1].Widht;

        return 0;
    }

    public Vector3 GetLastMapPartPosition()
    {
        if (mapParts.Count > 0)
            return mapParts[mapParts.Count - 1].transform.position;
        return Vector3.zero;
    }

}

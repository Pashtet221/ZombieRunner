using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class MapPart : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private List<IMapObject> mapObjects = new List<IMapObject>();

    public Vector2 MaxBounds => spriteRenderer.bounds.max;
    public Vector2 MinBounds => spriteRenderer.bounds.min;

    public int ID { get; set; }

    public float Widht => spriteRenderer.bounds.size.x;

    public void InitMap()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool CheckObjectOnPosition(Vector2Int position)
    {
        if (mapObjects.Count > 0 && mapObjects.FindLast(item => item.Position == position) != null)
            return true;
        return false;
    }

    public void AddObjectOnMap(IMapObject mapObject)
    {
        mapObjects.Add(mapObject);
    }

}

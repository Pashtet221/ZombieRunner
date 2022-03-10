using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour, IMapObject
{
    public GameObject Object => gameObject;

    public Vector2Int Position => new Vector2Int((int)transform.position.x, (int)transform.position.y);
}

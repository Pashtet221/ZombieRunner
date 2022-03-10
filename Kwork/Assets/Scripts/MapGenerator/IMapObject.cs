using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapObject
{
    GameObject Object { get; }
    public Vector2Int Position { get; }
}

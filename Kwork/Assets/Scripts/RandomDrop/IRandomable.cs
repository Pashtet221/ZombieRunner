using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomable
{
    int Chance { get; }
    object Drop { get; }
}

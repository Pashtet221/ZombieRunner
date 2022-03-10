using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerView
{
    void HealthChange(int health);
    void Shoot();
    void Move();
}

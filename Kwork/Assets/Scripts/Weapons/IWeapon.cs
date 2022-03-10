using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float AttackSpeed { get; }
    int Damage { get; }
    void Attack(Enemy enemyTarget);
    Transform AttackFromPoint { set; }
}

public interface IRangeWeapon : IWeapon
{
    void Reload();
}

public interface IMeleeWeapon : IWeapon
{
    void Repose();
}
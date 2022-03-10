using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : IMeleeWeapon
{
    public float AttackSpeed => throw new System.NotImplementedException();

    public int Damage => throw new System.NotImplementedException();

    public Transform AttackFromPoint { set => throw new System.NotImplementedException(); }

    public void Attack(Enemy enemyTarget)
    {
        throw new System.NotImplementedException();
    }

    public void Repose()
    {
    }
}

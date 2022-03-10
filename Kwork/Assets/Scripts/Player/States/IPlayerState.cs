using UnityEngine;
using UnityEngine.AI;
using System;
public interface IPlayerState
{
    void Enter();
    void DoAction();

    void CancelAction();
}


public interface IPlayerMoveState : IPlayerState
{
    event Action OnPosition;
    void SetStateParams(GameObject player,Vector3 moveTarget, float speed);
}

public interface IPlayerAttackState : IPlayerState
{
    event Action OnEnemyDeath;
    void SetStateParams(WeaponController weaponController , Enemy targetEnemy);
}
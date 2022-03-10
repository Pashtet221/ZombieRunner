using System;
using UnityEngine;

class PlayerAttackState : IPlayerAttackState
{
    private WeaponController weaponController;
    private float nextTime = 0.0F;
    private Enemy targetEnemy;

    public event Action OnEnemyDeath;

    public void CancelAction()
    {
        if (targetEnemy != null)
            targetEnemy.UnselectedEnemy();
    }

    public void DoAction()
    {
        if (Time.time > nextTime)
        {
            weaponController.Attack(targetEnemy);
            nextTime = Time.time + weaponController.CurrentWeapon.AttackSpeed;
        }
        
    }

    public void EnemyDeathHandler()
    {
        targetEnemy.OnDeath -= OnEnemyDeath;

        OnEnemyDeath?.Invoke();
    }

    public void Enter()
    {
        
    }

    public void SetStateParams(WeaponController weaponController, Enemy targetEnemy)
    {
        if (weaponController == null) throw new Exception("weaponController in null");
        if (targetEnemy == null) throw new Exception("targetEnemy in null");

        this.weaponController = weaponController;
        this.targetEnemy = targetEnemy;
        this.targetEnemy.OnDeath += EnemyDeathHandler;
        this.targetEnemy.SelectedEnemy();
    }
}

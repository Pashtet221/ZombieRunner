using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private MachineGunBullet machineGunBullet;
    private float attackSpeed = 0.5f;
    private int damage = 10;
    public float AttackSpeed => attackSpeed;
    private Transform atackFromPoint;
    public int Damage => damage;

    public Transform AttackFromPoint { set => atackFromPoint = value; }

    public void Attack(Enemy enemyTarget)
    {
        Quaternion rotation= Quaternion.Euler(atackFromPoint.rotation.eulerAngles.x, atackFromPoint.rotation.eulerAngles.y, Mathf.Atan2(enemyTarget.transform.position.y - atackFromPoint.position.y, enemyTarget.transform.position.x - atackFromPoint.position.x) * Mathf.Rad2Deg - 90);
        var bullet = Instantiate(machineGunBullet, atackFromPoint.position, rotation);
        bullet.SetParams(enemyTarget ,damage);
        bullet.RunBullet();
    }

    public void Reload()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MachineGunBullet : Bullet
{
    private int damage;
    private Enemy enemyTarget;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestoryBeforeExitTime), 4f);
    }

    private void DestoryBeforeExitTime()
    {

    }

    public void SetParams(Enemy enemyTarget,int damage)
    {
        this.damage = damage;
        this.enemyTarget = enemyTarget;
    }

    public override void CollisionHandler(Enemy enemy)
    {
        enemy.ApplyDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy != enemyTarget) return;

            CollisionHandler(enemy);
            Destroy(gameObject);
        }   
    }

    public override void RunBullet()
    {
        rigidbody2D.velocity = 15 * transform.up;
    }
}

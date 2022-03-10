using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    private float nextTime = 0.0F;


    public void Update()
    {
        if (player == null || GameState.StateGame != StateGame.GAME) return;
        DistanceToDetectPlayer();
        if (isPlayerDetected == false) return;
        DistanceToAttackOrMove();
    }

    public override void Attack()
    {
        if (Time.time > nextTime)
        {
            player.ApplyDamage(damage);
            nextTime = Time.time + attackSpeed;
        }

    }

    public override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
    }

    public void DistanceToAttackOrMove()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= distanceToAttack)
        {
            Attack();
        }
        else
        {
            nextTime = 0;
            Move();
        }
    }

    public override void ApplyDamage(int damage)
    {
        health -= damage;
        UpdateHealthIndicator();
        if (health <= 0)
        {
            Death();
        }
    }
}

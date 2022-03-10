using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int bulletsCount;
    [SerializeField] private int maxBulletsCount;
    [SerializeField] private int moveSpeed;

    public event Action OnPlayerDeath;
    public event Action<int> OnHealthChange;
    public event Action<int> OnBulletsCountChange;

    public int Health
    {
        get => health;
    }

    public int MoveSpeed
    {
        get => moveSpeed;
        set
        {
            if (value < 0)
                moveSpeed = 0;
            else
                moveSpeed = value;
        }
    }

    public int BulletCount
    {
        get => bulletsCount;
        set
        {
            if (value < 0)
                bulletsCount = 0;
            else
                bulletsCount = value;
        }
    }

    public int MaxHealth => maxHealth;

    public void SetMaxBullets(int maxBullets)
    {
        maxBulletsCount = maxBullets;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }


    public void ApplyDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
        }
        OnHealthChange?.Invoke(health);
    }

    public void Treatment(int amout)
    {
        if (health + amout > maxHealth)
            health = maxHealth;
        else
            health += amout;
    }

}

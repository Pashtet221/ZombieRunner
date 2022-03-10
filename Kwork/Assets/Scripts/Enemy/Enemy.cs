using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour , IMapObject
{
    [SerializeField] private GameObject targetImage;
    [SerializeField] protected int damage;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected int health;
    [SerializeField] protected float distanceToAttack;
    [SerializeField] protected float ditanceToDetectedPlayer;
    [SerializeField] private Image healthIndicator;
    protected PlayerPresenter player;
    protected float maxHealth;

    protected bool isPlayerDetected;

    public GameObject Object => gameObject;

    public Vector2Int Position => new Vector2Int((int)transform.position.x, (int)transform.position.y);

    public event System.Action OnDeath;
    public void Start()
    {
        player = FindObjectOfType<PlayerPresenter>();
        maxHealth = health;
    }

    public void DistanceToDetectPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= ditanceToDetectedPlayer)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }

    }

    public void SetStats(int damage, float moveSpeed, float attackSpeed, int health)
    {
        this.damage = damage;
        this.moveSpeed = moveSpeed;
        this.attackSpeed = attackSpeed;
        this.health = health;
    }

    public void SelectedEnemy()
    {
        healthIndicator.gameObject.SetActive(true);
        targetImage.SetActive(true);
    }

    public void UnselectedEnemy()
    {
        healthIndicator.gameObject.SetActive(false);
        targetImage.SetActive(false);
    }

    public abstract void Move();
    public abstract void Attack();
    public abstract void ApplyDamage(int damage);
    public virtual void UpdateHealthIndicator()
    {
        healthIndicator.fillAmount = (float)(health /maxHealth);
    }
    public virtual void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}

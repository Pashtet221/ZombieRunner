using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject" , menuName ="Enemys" , order = 1)]
public class EnemyList : ScriptableObject
{
    [SerializeField] private List<EnemyPack> enemies = new List<EnemyPack>();
    public IList<EnemyPack> Enemies => enemies;


    [System.Serializable]
    public struct EnemyPack
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private int damage;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float attackSpeed;
        [SerializeField] private int health;

        public Enemy Enemy => enemy;

        public int Damage => damage;
        public float MoveSpeed => moveSpeed;
        public float AttackSpeed => attackSpeed;
        public int Health => health;
    }
}

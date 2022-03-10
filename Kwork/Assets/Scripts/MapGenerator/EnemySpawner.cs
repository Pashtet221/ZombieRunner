using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyList _enemyList;
    [SerializeField] private PlayerStatsCounter _playerStatsCounter;
    private int _enemyLevel;

    private void Awake()
    {
        _playerStatsCounter.OnMakeMove += MakeMoveHandler;
    }

    private void OnDisable()
    {
        _playerStatsCounter.OnMakeMove -= MakeMoveHandler;
    }

    public void MakeMoveHandler()
    {
        if((int)_playerStatsCounter.Moves >= 20)
        {
            _enemyLevel = 1;
        }
    }

    public Enemy[] CreateEnemys(int amount)
    {
        List<Enemy> enemies = new List<Enemy>();
        for(int i = 0; i < amount; i++)
        {
            var enemy = Instantiate(_enemyList.Enemies[_enemyLevel].Enemy);
            var packStats = _enemyList.Enemies[_enemyLevel];
            enemy.SetStats(packStats.Damage, packStats.MoveSpeed, packStats.AttackSpeed, packStats.Health);
            enemies.Add(enemy);
        }
        return enemies.ToArray();
    }

}

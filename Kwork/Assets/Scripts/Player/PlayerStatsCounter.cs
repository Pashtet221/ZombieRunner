using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsCounter : MonoBehaviour
{
    private GameObject _player;
    private float _maxXposition;
    private float _moves;

    public float Moves => _moves;

    public event System.Action OnMakeMove;

    public void PlayerStatsCounterConstructor(GameObject player)
    {
        _player = player;
    }

    public int CountMoves()
    {
        if (_player.transform.position.x > _maxXposition)
        {
            _moves += 0.03f;
            _maxXposition = _player.transform.position.x;
            OnMakeMove?.Invoke();
        }
        return (int)_moves;
    }

}

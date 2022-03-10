using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveState : IPlayerMoveState
{
    private float speed;
    private Vector3 moveTarget;
    private GameObject player;

    public event Action OnPosition;

    public void CancelAction()
    {
        // Анимация выхода
    }

    public void DoAction()
    {
        float distance = Vector3.Distance(player.transform.position, moveTarget);
        if(distance <= 0.01f)
        {
            OnPosition?.Invoke();
        }
        else
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(moveTarget.x, moveTarget.y, player.transform.position.z), speed * Time.deltaTime);
        }
    }

    public void Enter()
    {
        // Анимация входа
    }

    public void SetStateParams(GameObject player, Vector3 moveTarget, float speed)
    {
        if (!player) throw new Exception("player is null");

        this.player = player;
        this.speed = speed;
        this.moveTarget = moveTarget;

    }
}

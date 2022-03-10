using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class TargetDetector : MonoBehaviour
    {
        public event Action<Vector3> OnPositionDetected;
        public event Action<Enemy> OnEnemyDetected;

        public void TouchDetect()
        {
            if (Input.GetMouseButtonDown(0) && GameState.StateGame == StateGame.GAME)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.transform.TryGetComponent(out Enemy enemy))
                    {
                        OnEnemyDetected(enemy);
                    }
                }
                else
                {
                    OnPositionDetected?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                }
            }
        }
    }
}

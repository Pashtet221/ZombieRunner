using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform camera;
    [SerializeField] private float followSpeed;
    private float limitHorizontal;

    private void Update()
    {
        if (GameState.StateGame == StateGame.PAUSE) return;
        if (target == null || camera == null) return;
        CalculateLimit();
        camera.position = Vector3.MoveTowards(camera.position, new Vector3(target.position.x, camera.position.y , camera.position.z), Time.deltaTime * followSpeed);
        camera.position = new Vector3(Mathf.Clamp(camera.position.x, limitHorizontal, Mathf.Infinity), camera.position.y, camera.position.z);
    }

    private void CalculateLimit()
    {
        if (target.position.x > limitHorizontal)
        {
            limitHorizontal = target.position.x;
        }
    }


}

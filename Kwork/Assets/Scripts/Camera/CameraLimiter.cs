using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float limitHorizontal;
    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        CalculateLimit();
        camera.position = new Vector3(Mathf.Clamp(camera.position.x, limitHorizontal, Mathf.Infinity), camera.position.y, camera.position.z);
    }

    private void CalculateLimit()
    {
        if(player.position.x > limitHorizontal)
        {
            limitHorizontal = player.position.x;
        }
    }

}

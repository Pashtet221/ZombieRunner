using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected Vector3 startPosition;
    protected Rigidbody2D rigidbody2D;

    public abstract void RunBullet();

    public abstract void CollisionHandler(Enemy enemy);
    public virtual void DestroyBeforeExitFromDistance()
    {
        float distance = Vector3.Distance(startPosition, transform.position);
        if (distance >= 30)
            Destroy(gameObject);
    }
}

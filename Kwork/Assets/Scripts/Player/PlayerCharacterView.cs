using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterView : MonoBehaviour, IPlayerCharacterView
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Coroutine takeDamageCoroutine;
    private Animator animator;

    public void PlayerCharacterViewConstructor(Animator animator , Sprite characterSprite)
    {
        spriteRenderer.sprite = characterSprite;
        //this.animator.runtimeAnimatorController = animator.runtimeAnimatorController;
    }

    public void HealthChange(int health)
    {
        if (takeDamageCoroutine == null)
            takeDamageCoroutine = StartCoroutine(DamageSpriteAnimator());
    }

    public void Move()
    {
    }

    public void Shoot()
    {
    }

    private IEnumerator DamageSpriteAnimator()
    {
        int i = 0;
        while (true)
        {

            i++;
            if (i >= 6)
            {
                spriteRenderer.color = Color.white;
                takeDamageCoroutine = null;
                break;
            }
            else if (i % 2 == 0)
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}

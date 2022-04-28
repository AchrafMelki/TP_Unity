using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Attack : MonoBehaviour
{

    public Transform attackPointR;
    public Transform attackPointL;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerAttack();
        }
    }

    void PlayerAttack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(whichAttackPointIsUse().position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<SnakePatrol>().Die();
        }
    }


    private Transform whichAttackPointIsUse()
    {
        if (this.GetComponent<Movement>().isFlipX())
        {
            return attackPointL;
        }
        else
        {
            return attackPointR;
        }
    }
    private void OnDrawGizmos()
    {
        if (whichAttackPointIsUse() == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(whichAttackPointIsUse().position, attackRange);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public Animator animator;
    public int damageOnCollision = 20;
    public SpriteRenderer graphics;
    private Transform target;

    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            Health health = collision.transform.GetComponent<Health>();
            health.TakeDamage(damageOnCollision);
        }
    }

    public void Die()
    {
        animator.SetTrigger("Dead");
        StartCoroutine(waitTwoSeconds());
        

    }

    private IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        graphics.enabled = false;
    }
}
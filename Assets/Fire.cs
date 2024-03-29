using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public int damageOnCollision = 50;
    public SpriteRenderer graphics;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            Health health = collision.transform.GetComponent<Health>();
            health.TakeDamage(damageOnCollision);
        }
    }
}

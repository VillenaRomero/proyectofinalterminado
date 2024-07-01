using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movedbullet : MonoBehaviour
{
    private Rigidbody2D rigy;
    public int speed;
    void Awake()
    {
        rigy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movementDirection = transform.right.normalized;

        rigy.velocity = movementDirection * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombi") {
            Destroy(this.gameObject);
        }
        else {
            Destroy(gameObject, 0.5f);
        }

    }
}
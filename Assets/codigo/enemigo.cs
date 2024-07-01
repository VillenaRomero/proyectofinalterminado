using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : estadisticas
{
    public GameObject objective;
    public zonazombi avanzar;
    private Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (avanzar != null && avanzar.ischasingplayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            Destroy(this.gameObject);

        }
    }
}
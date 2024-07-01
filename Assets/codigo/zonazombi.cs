using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonazombi : enemigo
{
    public bool ischasingplayer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ischasingplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ischasingplayer = false;
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala") 
        {
            Destroy(gameObject);
        }
    }
}

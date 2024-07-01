using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class movimientodeljugador : estadisticas
{
    public float horizontal;
    public float vertical;
    public float speedx;
    public float speedy;
    private Rigidbody2D _compRigidbody2D;
    public GameObject bulletprefab;
    private SpriteRenderer _comSpriteRenderer;
    public int directionx;
    public int directiony;
    public Transform spawner;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _comSpriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 )
        {
            _comSpriteRenderer.flipX = false;
            directionx = 1;
            directiony = 0;
        }
        else if (horizontal < 0 )
        {
            _comSpriteRenderer.flipX = true;
            directionx = -1;
            directiony = 0;
        }

        if (vertical > 0)
        {
            _comSpriteRenderer.flipY = false;
            directiony = 1;
            directionx = 0;
        }
        else if (vertical < 0)
        {
            _comSpriteRenderer.flipY = true;
            directiony = -1;
            directionx = 0;
        }

        Girar();
        _compRigidbody2D.velocity = new Vector2(speedx * horizontal, speedy * vertical);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(bulletprefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
        }

    } 
    private void Girar()
    {
        if (directionx != 0)
        {
            transform.localScale = new Vector3(directionx, 1, 1);
            spawner.localScale = new Vector3(directionx, 1, 1);
        }
        else if (directiony != 0)
        {
            transform.localScale = new Vector3(1, directiony, 1);
            spawner.localScale = new Vector3(1, directiony, 1);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombi")
        {
            life = life - 1;

            if (life == 0)
            {
                SceneManager.LoadScene("derrota");
            }
        }
    }
}

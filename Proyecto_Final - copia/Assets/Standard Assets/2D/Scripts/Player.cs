
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50;
    public float JumpPower = 150;
    public bool grounded = true;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private int piso;
    public KeyCode jumpkey = KeyCode.Space;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        piso = ~LayerMask.NameToLayer("Piso");
    }

    void Update()
    {
     if (Input.GetKeyDown(jumpkey) && grounded)
        {
            rb2d.AddForce(Vector2.up * JumpPower);
            grounded = false;
        }
    }

    void FixedUpdate() {

        float h = Input.GetAxis("Horizontal");

        rb2d.position += Vector2.right * h * speed * Time.deltaTime;

        //limitando velocidad del jugador (verificar) ??
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position - new Vector3(0.0f, bc2d.size.y / 2), new Vector2(bc2d.size.x, 0.01f), 0.0f, Vector2.down, 0.01f, piso);
        if (hit.collider != null) grounded = true;
    }
}

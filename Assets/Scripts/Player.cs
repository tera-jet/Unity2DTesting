using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float maxSpeed = 3, speed = 50f, jumpPow = 280f;
    public bool grounded = true, faceRight = true, doubleJump = true, movingTouch = false;


    public Rigidbody2D r2;

    public Animator anim;
    public Vector2 move;


    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded)
            {
                doubleJump = true;
                grounded = false;
                r2.AddForce(Vector2.up * jumpPow);

                Debug.Log("Vector up jump: " + jumpPow + " / Rigidbody2D velocity y: " + r2.velocity.y);
            }
            else {
                if (doubleJump) {
                    doubleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow);
                    Debug.Log("Vector up double jump: " + jumpPow + " / Rigidbody2D velocity y: " + r2.velocity.y);
                }
            }
                
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxSpeed) {
            r2.velocity = new Vector2(maxSpeed,r2.velocity.y);
        }

        if (r2.velocity.x < -maxSpeed)
        {
            r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);
        }

        if (h > 0 && !faceRight) {
            Flip();
        }

        if (h < 0 && faceRight)
        {
            Flip();
        }

        if (grounded) {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        if (movingTouch) {
            move = transform.position;
            move.x += MovingPlatform.movingSpeed;
            transform.position = move;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }

}

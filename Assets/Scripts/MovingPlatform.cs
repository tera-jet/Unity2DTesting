using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D r2;

    public static float movingSpeed = 0.06f;
    int changeDirection = -1;

    Vector3 move;
    Vector2 move2;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        move = transform.position;
        move2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move2.x += movingSpeed;
        transform.position = move2;
    }

    /**
     * 
     * 
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            movingSpeed *= changeDirection;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D r2;

    public float fallingDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        } 
    }

    IEnumerator Fall() {
        yield return new WaitForSeconds(fallingDelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}

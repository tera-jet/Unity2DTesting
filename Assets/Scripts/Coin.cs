using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float flyingSpeed = 0.06f;
    public bool touch = false;
    Animator anim;
    Rigidbody2D r2;
    public SpriteRenderer rend;

    Vector2 prePos;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        prePos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (touch) {
            prePos.y += flyingSpeed;
            transform.position = prePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2)
    {
        if (collider2.CompareTag("Player"))
        {
            Debug.Log("Float f: Enter");
            touch = true;
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut() {
        Debug.Log("Float f1111: ");
        for (float f = 1f; f >= -0.05; f -= 0.05f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            Debug.Log("Float f: " + f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return 0;
    }

}

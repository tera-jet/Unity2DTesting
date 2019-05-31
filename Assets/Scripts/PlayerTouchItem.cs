using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{

    Animator anim;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (touch) {
            anim.SetBool("PlayerTouch", touch);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider2)
    {
        if (collider2.CompareTag("Player"))
        {
            touch = true;
        }
    }
}

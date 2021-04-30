using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocityX = 10f;
    private Rigidbody2D rb2D;

    private PlayerController playerController;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>(); //buscar el objeto dentro de mi player controller
        
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = Vector2.right * velocityX;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

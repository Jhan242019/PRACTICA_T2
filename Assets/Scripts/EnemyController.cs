using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector2.left * 5;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "EnemiesCleaner")
            Destroy(this.gameObject);
    }
}

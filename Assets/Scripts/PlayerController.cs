using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool puedoSaltar = false;
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;
    
    public float speed = 10;
    public float upSpeed = 50;
    
    public GameObject rigthBullet1;
    public GameObject rigthBullet2;
    public GameObject rigthBullet3;
    
    private float tiempo = 1f;
    
    private const float Bala1 = 1f;
    private const float Bala2 = 3f;
    private const float Bala3 = 5f;

    private float switchColorDelay = .1f;
    private float switchColorTime = 0f;
    
    private bool esIntangible = false;
    
    private Color originalCOlor;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        _animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
        originalCOlor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        //para lanzar la bola

        if (Input.GetKey("x"))
        {
            tiempo += Time.deltaTime;
            Debug.Log("El tiempo es de : " + tiempo);
            
            //COLOR
            switchColorTime += Time.deltaTime;
            if (switchColorTime > switchColorDelay)
            {
                SwitchColor();
            }
        }

        if (Input.GetKeyUp("x"))
        {

            if (tiempo >= Bala1 && tiempo <= Bala2)
            {
                if (!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.5f, transform.position.y - 0.1f);
                    Instantiate(rigthBullet1, position, rigthBullet1.transform.rotation);
                }
            }

            if (tiempo >= Bala2 && tiempo <= Bala3)
            {
                if (!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.5f, transform.position.y - 0.1f);
                    Instantiate(rigthBullet2, position, rigthBullet2.transform.rotation);
                }
            }
            
            if (tiempo >= Bala3)
            {
                if (!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.5f, transform.position.y - 0.1f);
                    Instantiate(rigthBullet3, position, rigthBullet3.transform.rotation);
                }
            }
            tiempo = 1;
        }
        
        //movimientos

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sr.flipX = false;
            setRunAnimation();
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            setRunAnimation();
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        else
        {
            setQuietoAnimation();
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && puedoSaltar)
        {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * upSpeed; // solo para centrarme en el eje x
            puedoSaltar = false;
        }
    }

    //COLOR

    private void SwitchColor()
    {
        if (sr.color == originalCOlor)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = originalCOlor;
        }
        switchColorTime = 0;
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        puedoSaltar = true;
    }

    //Velocidad
    private void OnTriggerEnter2D(Collider2D other)
    {
        puedoSaltar = true;

    }

    private void setCorrerDisparandoAnimation()
    {
        _animator.SetInteger("Estado",3);
    }
    private void setJumpAnimation()
    {
        _animator.SetInteger("Estado",2);
    }
    private void setRunAnimation()
    {
        _animator.SetInteger("Estado",1);
    }

    private void setQuietoAnimation()
    {
        _animator.SetInteger("Estado", value:0);
    }

}

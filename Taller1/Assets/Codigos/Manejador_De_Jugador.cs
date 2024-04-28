using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Manejador_De_Jugador : MonoBehaviour
{
    public int velocidad;
    public float FuerzaDeSalto;
    public int vidajugador = 3;
    public int contador = 0;
    public GameObject Coin;
    public AudioClip sound;




    private Rigidbody2D rb2D;
    private Vector3 initialPosition;
    private Animator animator;
    private float movimientoHorizontal;
    private bool ConecTierra;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        if (movimientoHorizontal < 0.0f)
        {
            transform.localScale = new Vector3(-0.5f,0.5f,0.5f);

        } else if (movimientoHorizontal > 0.0f)
        {
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
        animator.SetBool("runnig", movimientoHorizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.blue);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.2f))
        {
            ConecTierra = true;
        }
        else
        {
            ConecTierra = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ConecTierra)
        {
            jump();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
        }
        
        

    }
    private void jump()
    {
        rb2D.AddForce(Vector2.up * FuerzaDeSalto);
    }

    private void FixedUpdate()
    {
       
        rb2D.velocity = new Vector2(movimientoHorizontal * velocidad, rb2D.velocity.y);
        
        //float movimientoVertical = Input.GetAxis("Vertical");

        //Vector3 movimiento = new Vector2(movimientoHorizontal);

       /*if(tipoDeMovimiento == 1)
        {
            transform.Translate(movimiento * velocidadDeMovimiento * Time.deltaTime);
        } else if(tipoDeMovimiento == 2)
        {
            rb2D.velocity = movimiento * velocidadDeMovimiento;
        }
        else
        {
            rb2D.AddForce(movimiento * velocidadDeMovimiento);
        }
       */
    }
    public void daño()
    {
        vidajugador = vidajugador - 1;     
        if(vidajugador == 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sierra"))
        {
            transform.position = initialPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.IncremetnoMonedas();
        }
    }
    
}

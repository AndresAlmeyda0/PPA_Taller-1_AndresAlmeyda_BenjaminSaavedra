using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    public static Cofre instance;
    private Animator animator;
    public AudioClip sound;
    private AudioSource FondoSound;
    public TextMeshProUGUI FinalCofre;
    private string texto = "Juego Terminado";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        FondoSound = Camera.main.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            if(GameManager.instance.contador == 14)
            {
                AbrirCofre();
                Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
                CambiarTexto();
            }
        }
    }
    private void AbrirCofre()
    {
        animator.SetTrigger("Abrir");
        DetenerSonidoFondo();
    }
    private void DetenerSonidoFondo()
    {
        if (FondoSound.isPlaying)
        {
            FondoSound.Stop(); // Detener el sonido de fondo si está sonando
        }
    }
    void CambiarTexto()
    {
        FinalCofre.text = texto;
    }



}

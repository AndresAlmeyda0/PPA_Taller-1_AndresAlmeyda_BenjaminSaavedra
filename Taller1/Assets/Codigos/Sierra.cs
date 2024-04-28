using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    public AudioClip sound;
    private Transform rotacionZ;
    [SerializeField] private float velocidadRotacion = 80f;
    [SerializeField] private bool direccionRotacion = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotacionSierra();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manejador_De_Jugador jugador = collision.collider.GetComponent<Manejador_De_Jugador>();
        if (jugador != null)
        {
            jugador.daño();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
    void rotacionSierra()
    {
        this.transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}

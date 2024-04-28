using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    [SerializeField] private float amplitud = 5f;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition + amplitud*new Vector3(0f, Mathf.Sin(Time.time), 0f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manejador_De_Jugador jugador = collision.collider.GetComponent<Manejador_De_Jugador>();
        if (jugador != null)
        {
            jugador.daño();
        }
    }


}

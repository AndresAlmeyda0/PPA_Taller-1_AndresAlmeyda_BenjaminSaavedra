using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPersonaje : MonoBehaviour
{
    public GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Jugador == null) { return; }
        Vector3 position = transform.position;
        position.x = Jugador.transform.position.x;
        transform.position = position;
    }
}

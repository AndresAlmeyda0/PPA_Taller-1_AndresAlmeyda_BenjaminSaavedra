using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI TextoContadorMonedas;
    public AudioClip sound;
    public int contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IncremetnoMonedas()
    {
        contador++;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        TextoContadorMonedas.text = "Monedas: " + contador.ToString();
    }
}

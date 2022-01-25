using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Net;
using UnityEngine.UI;


public class A3 : MonoBehaviour
{
    public GameObject antorcha;
    public GameObject jugador;

    public Button boton;
    BotonActivar script;

    bool jugadorenrango;
    bool activado;
    Animator anim;

    int tamano;


    // Start is called before the first frame update
    void Start()
    {
        //Archivamos los datos recibidos en codigo binario
        BinaryFormatter formatter = new BinaryFormatter();
        //Abrimos el fichero del objeto
        FileStream fs = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Open);
        JugadorEnPartida jugadordatos = (JugadorEnPartida)formatter.Deserialize(fs);

        fs.Close();

        Investigador j = jugadordatos.getInvestigadores();
        Caracteristicas c = jugadordatos.getCaracteristicas();

        tamano = c.getTamano();

        script = boton.GetComponent<BotonActivar>();

        anim = antorcha.GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jugadorenrango)
        {
            if (tamano >= 11)
            {
                Debug.Log("owo 3");
                activado = true;
                anim.enabled = true;
            }
            else
            {
                Debug.Log("Te has muerto wey");
            }

        }
        else if (jugadorenrango && script.GetPressed())
        {
            if (tamano >= 11)
            {
                Debug.Log("owo 3");
                activado = true;
                anim.enabled = true;
            }
            else
            {
                Debug.Log("Te has muerto wey");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = false;
        }
    }
}
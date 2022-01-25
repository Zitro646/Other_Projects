using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Net;
using UnityEngine.EventSystems;

public class A1 : MonoBehaviour
{
    public GameObject antorcha;
    public GameObject jugador;

    public Button boton;
    BotonActivar script;

    bool jugadorenrango;
    bool activado;
    Animator anim;


    int destreza;

    // Start is called before the first frame update
    void Start()
    {
        //Archivamos los datos recibidos en codigo binario
        BinaryFormatter formatter = new BinaryFormatter();
        //Abrimos el fichero del objeto
        FileStream fs = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Open);
        JugadorEnPartida jugadordatos = (JugadorEnPartida)formatter.Deserialize(fs);

        fs.Close();
        //cogemos las caracteristicas del personaje
        Investigador j = jugadordatos.getInvestigadores();
        Caracteristicas c = jugadordatos.getCaracteristicas();
        //para poder comparar un stat
        destreza = c.getDestreza();
        //coger el script del boton para utilizar un variable
        script=boton.GetComponent<BotonActivar>();
        //coger el animator de la antorcha
        anim = antorcha.GetComponent<Animator>();
        //desactivar la animacion para asegurarnos
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //encender la antorcha utilizando el espacio o el boton
        if (Input.GetKeyDown(KeyCode.Space) && jugadorenrango)
        {
            if (destreza >= 11) {
                Debug.Log("A1");
                activado = true;
                anim.enabled = true;
            }
            else
            {
                Debug.Log("No tienes el stat");
            }
            

        }else if( jugadorenrango && script.GetPressed())
        {
            if (destreza >= 11)
            {
                Debug.Log("A1");
                activado = true;
                anim.enabled = true;
            }
            else
            {
                Debug.Log("No tienes el stat");
            }
        }
        
    }
    //comprobar si el jugador esta en rango
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = true;
        }
    }
    //comprobar si el jugador ha salido de rango
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = false;
        }
    }

   
}

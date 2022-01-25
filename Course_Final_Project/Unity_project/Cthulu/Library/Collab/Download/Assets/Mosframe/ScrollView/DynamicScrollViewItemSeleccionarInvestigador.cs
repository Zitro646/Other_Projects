namespace Mosframe {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using TMPro;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;

    public class DynamicScrollViewItemSeleccionarInvestigador : UIBehaviour, IDynamicScrollViewItem 
    {
        //Declaramos el GameObject objeto(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;
        //Declaramos el GameObject de distintos botones y paneles donde poner informacion
        public GameObject botonJugar;
        public GameObject botonCogerObjetos;
        public GameObject seleccionado;
        //Estas variables sirven para marcar la posicion y si se puede tocar el item
        public bool touchi;
        private int pos;
        //Declaramos las distintas variables para los textos necesarios
        public Text title;
        public Text titleFuerza;
        public Text titleTamano;
        public Text titleConstitucion;
        public Text titleDestreza;
        public Text titleApariencia;
        public Text titlePoder;
        public Text titleEducacion;
        public Text titleVida;
        public Text titleSanidad;
        public Image background;

        //En este metodo se declaran los colores a usar
        private readonly Color[] colors = new Color[] {
		    Color.cyan,
		    Color.green,
	    };

        //Este metodo inicia la clase
        void Start()
        {
            touchi = false;
            botonJugar.active = false;
            botonCogerObjetos.active = false;
        }

        //Cuando se actualize el Item realizara lo siguente
        public void onUpdateItem( int index ) {

            //Pide al manejo de ficheros los datos del investigador(generales y caracteristicas)
            Investigador n = objeto.GetComponent<ManejoFicheroDatos>().ObtenerInvestigador(index);
            Caracteristicas c = objeto.GetComponent<ManejoFicheroDatos>().buscarCaracteristicasPorID(n.getIdCaracteristicas());

            //Establecemos los distintos strings a cada cada variable
            this.title.text = string.Format(n.getNombreCompleto());
            this.titleVida.text = "HP  " + c.getPuntosVidaActual() + " / " + c.getPuntosVidaMax();
            this.titleSanidad.text = "COR " + c.getPuntosCorduraActual() + " / " + c.getPuntosCorduraMax();

            this.titleFuerza.text = "FUE " + c.getFuerza();
            this.titleTamano.text = "TAM " + c.getTamano();
            this.titleConstitucion.text = "CON " + c.getConstitucion();
            this.titleDestreza.text = "DES " + c.getDestreza();
            this.titleApariencia.text = "APA " + c.getApariencia();
            this.titlePoder.text = "POD " + c.getPoder();
            this.titleEducacion.text = "EDU " + c.getEducacion();


            this.background.color   = this.colors[Mathf.Abs(index) % this.colors.Length];
            this.pos = index;
            
        }

        //Este metodo comprueba constantemente si ha pulsado el item y esta colisionando con el raton
        public void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0) && touchi == true)
            {

                Investigador j = objeto.GetComponent<ManejoFicheroDatos>().ObtenerInvestigador(pos);

                
                seleccionado.GetComponent<TextMeshProUGUI>().text = " Investigador : "+"\n"+ j.getNombreCompleto();

                //Activamos el boton que nos lleva al juego
                botonJugar.active = true;
                botonCogerObjetos.active = true;
                //Creamos el fichero del jugador

                //Archivamos los datos recibidos en codigo binario
                BinaryFormatter formatter = new BinaryFormatter();

                //Creamos el fichero del investigador


                Investigador i = objeto.GetComponent<ManejoFicheroDatos>().ObtenerInvestigador(pos);
                Caracteristicas c = objeto.GetComponent<ManejoFicheroDatos>().buscarCaracteristicasPorID(i.getIdCaracteristicas());
                Trastornos t = objeto.GetComponent<ManejoFicheroDatos>().buscarTrastornoPorID(i.getIdTrastornos());
                HashSet<Objetos> o = new HashSet<Objetos>();

                JugadorEnPartida jugador = new JugadorEnPartida(i, c, t , o);

                //Creamos el fichero del investigador
                FileStream fs1 = new FileStream("./Assets/Cthulhu/FicheroDatos/Investigador_Juego.dat", FileMode.Create);
                formatter.Serialize(fs1, jugador);
                fs1.Close();

            }

        }
            
        public void OnTriggerEnter(Collider other)
        {
            touchi = true;
        }

        public void OnTriggerExit(Collider other)
        {
            touchi = false;
        }

    }
}
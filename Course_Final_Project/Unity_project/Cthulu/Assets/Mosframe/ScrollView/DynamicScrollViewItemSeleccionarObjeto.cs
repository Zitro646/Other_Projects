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

    public class DynamicScrollViewItemSeleccionarObjeto : UIBehaviour, IDynamicScrollViewItem 
    {
        //Declaramos el GameObject objeto(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;
        //Declaramos el GameObject de distintos botones y paneles donde poner informacion
        public GameObject botonJugar;
        public GameObject botonCambiarInvestigador;
        public GameObject botonQuitarObjeto;
        public GameObject seleccionado;
        //Estas variables sirven para marcar la posicion y si se puede tocar el item
        public bool touchi;
        private int pos;
        //Declaramos las distintas variables para los textos necesarios
        public Text title;
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
            botonCambiarInvestigador.active = false;
            botonQuitarObjeto.active = false;
        }

        //Cuando se actualize el Item realizara lo siguente
        public void onUpdateItem( int index ) {
            //Pide al manejo de ficheros los datos del inventario del Investigador_Jugable
            Objetos o = objeto.GetComponent<ManejoFicheroDatos>().ObtenerObjeto(index);

            this.title.text = o.getDescripcion();
            this.background.color   = this.colors[Mathf.Abs(index) % this.colors.Length];
            this.pos = index;
            
        }

        //Este metodo comprueba constantemente si ha pulsado el item y esta colisionando con el raton
        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && touchi == true)
            {
                //Activamos los botones
                botonJugar.active = true;
                botonCambiarInvestigador.active = true;
                botonQuitarObjeto.active = true;
                //Archivamos los datos recibidos en codigo binario
                BinaryFormatter formatter = new BinaryFormatter();
                //Abrimos el fichero del objeto
                FileStream fs = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Open);
                JugadorEnPartida almacen = (JugadorEnPartida)formatter.Deserialize(fs);
                fs.Close();

                HashSet<Objetos> o1 = new HashSet<Objetos>();
                o1 = almacen.getListaObjetos();
                Objetos o = objeto.GetComponent<ManejoFicheroDatos>().ObtenerObjeto(pos);

                bool test = false;
                foreach (Objetos x in o1)
                {
                    if (x.getDescripcion() == o.getDescripcion())
                    {
                        test= true;
                    }
                }
                if (!test) {

                    o1.Add(o);

                    almacen.setListaObjetos(o1);

                    //Sobreescribimos/Creamos el fichero del investigador
                    FileStream fs1 = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Create);
                    formatter.Serialize(fs1, almacen);
                    fs1.Close();

                    
                    seleccionado.GetComponent<TextMeshProUGUI>().text = o.getDescripcion() + " añadido";
                    print("Objeto añadido al inventario");
                }
                else
                {
                    print("El objeto ya esta en el inventario");
                    seleccionado.GetComponent<TextMeshProUGUI>().text = "Ese objeto ya esta en su inventario";
                }

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
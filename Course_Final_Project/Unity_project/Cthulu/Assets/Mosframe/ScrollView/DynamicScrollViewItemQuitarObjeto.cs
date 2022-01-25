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

    public class DynamicScrollViewItemQuitarObjeto : UIBehaviour, IDynamicScrollViewItem 
    {
        //Declaramos el GameObject objeto(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;
        //Declaramos el GameObject seleccionado(donde podremos lo que hace al pulsar un item)
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
        }

        //Cuando se actualize el Item realizara lo siguente
        public void onUpdateItem( int index ) {
            //Pide al manejo de ficheros los datos del inventario del Investigador_Jugable
            Objetos o = objeto.GetComponent<ManejoFicheroDatos>().ObtenerObjetoDeInventario(index);

            this.title.text = o.getDescripcion();

            this.background.color   = this.colors[Mathf.Abs(index) % this.colors.Length];
            this.pos = index;
            
        }

        //Cada momento que se actualize hara lo siguiente
        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && touchi == true)
            {
                //Archivamos los datos recibidos en codigo binario
                BinaryFormatter formatter = new BinaryFormatter();
                //Abrimos el fichero del jugador para leerlo
                JugadorEnPartida inventario = objeto.GetComponent<ManejoFicheroDatos>().obtenerDatosInvestigadorJugable();
                
                HashSet<Objetos> o1 = new HashSet<Objetos>();
                HashSet<Objetos> o2 = new HashSet<Objetos>();
                o1 = inventario.getListaObjetos();
                Objetos o = objeto.GetComponent<ManejoFicheroDatos>().ObtenerObjetoDeInventario(pos);
                
                //Eliminamos el objeto de la lista
                foreach (Objetos x in o1)
                {
                    if(x.getDescripcion() != o.getDescripcion())
                    {
                        o2.Add(x);
                    }
                }
                inventario.setListaObjetos(o2);

                //Sobreescribimos/Creamos el fichero del investigador
                FileStream fs1 = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Create);
                formatter.Serialize(fs1, inventario);
                fs1.Close();

                seleccionado.GetComponent<TextMeshProUGUI>().text = o.getDescripcion() + " eliminado del inventario";
                this.Start();

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
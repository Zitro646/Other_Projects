namespace Mosframe {

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    

    public class DynamicScrollViewItemExample : UIBehaviour, IDynamicScrollViewItem 
    {
        //Declaramos el GameObject(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;

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

        //Cuando se actualize el Item realizara lo siguente
        public void onUpdateItem( int index ) {

            //Pide al manejo de ficheros los datos del investigador(generales y caracteristicas)
            Investigador n = objeto.GetComponent<ManejoFicheroDatos>().ObtenerInvestigador(index);
            Caracteristicas c = objeto.GetComponent<ManejoFicheroDatos>().buscarCaracteristicasPorID(n.getIdCaracteristicas());
            
            //Establecemos los distintos strings a cada cada variable
            this.title.text = string.Format(n.getNombreCompleto());
            this.titleVida.text = "HP  " + c.getPuntosVidaActual()+" / "+ c.getPuntosVidaMax();
            this.titleSanidad.text = "COR " + c.getPuntosCorduraActual() + " / " + c.getPuntosCorduraMax();
            this.titleFuerza.text = "FUE " + c.getFuerza();
            this.titleTamano.text = "TAM " + c.getTamano();
            this.titleConstitucion.text = "CON " + c.getConstitucion();
            this.titleDestreza.text = "DES " + c.getDestreza();
            this.titleApariencia.text = "APA " + c.getApariencia();
            this.titlePoder.text = "POD " + c.getPoder();
            this.titleEducacion.text = "EDU " + c.getEducacion();

            //Establece el color de fondo
            this.background.color   = this.colors[Mathf.Abs(index) % this.colors.Length];

        }

    }
}
namespace Mosframe {

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    

    public class DynamicScrollViewItemObjetos : UIBehaviour, IDynamicScrollViewItem 
    {
        //Declaramos el GameObject(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;

        //Declaramos las distintas variables para los textos necesarios
        public Text title;
        public Image background;

        //En este metodo se declaran los colores a usar
        private readonly Color[] colors = new Color[] {
		    Color.cyan,
		    Color.green,
	    };

        //Cuando se actualize el Item realizara lo siguente
        public void onUpdateItem( int index ) {

            //Pide al manejo de ficheros los datos de objetos de la posicion actual
            Objetos o = objeto.GetComponent<ManejoFicheroDatos>().ObtenerObjeto(index);

            this.title.text = o.getDescripcion();
            this.background.color   = this.colors[Mathf.Abs(index) % this.colors.Length];

        }


    }
}
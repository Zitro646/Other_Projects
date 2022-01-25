namespace Mosframe
{

    using UnityEngine;

    /// <summary>
    /// Dynamic Vertical Scroll View
    /// </summary>
    [AddComponentMenu("UI/Dynamic V Scroll View")]
    public class DynamicVScrollViewInvestigador : DynamicScrollView
    {

        //Declaramos el GameObject objeto(que sera el que maneja los Ficheros.bat)
        public GameObject objeto;

        protected override float contentAnchoredPosition { get { return -this.contentRect.anchoredPosition.y; }  set { this.contentRect.anchoredPosition = new Vector2(this.contentRect.anchoredPosition.x, -value); } }
        protected override float contentSize { get { return this.contentRect.rect.height; } }
        protected override float viewportSize { get { return this.viewportRect.rect.height; } }
        protected override float itemSize { get { return this.itemPrototype.rect.height; } }

        public override void init()
        {

            this.direction = Direction.Vertical;
            base.init();
        }
        protected override void Awake()
        {

            base.Awake();
            this.direction = Direction.Vertical;
        }

        //Hemos sobreescrito este metodo para que establezca el tamaño maximo del Sroll View Al tamaño del Almacen de Investigadores
        protected override void Start()
        {
            this.totalItemCount = objeto.GetComponent<ManejoFicheroDatos>().ObtenerTamañoMaximoAlmacenInvestigadores();
            base.Start();
        }

        //En este metodo comprobamos que el tamaño del fichero de investigadores con el tamaño del Scroll View , si sale distinto reiniciamos el Scroll View
        public void Update()
        {
            
            int x = objeto.GetComponent<ManejoFicheroDatos>().ObtenerTamañoMaximoAlmacenInvestigadores();
            
            if (this.totalItemCount != x)
            {
                this.totalItemCount = objeto.GetComponent<ManejoFicheroDatos>().ObtenerTamañoMaximoAlmacenInvestigadores();
                base.Start();
            }
            base.refresh();
        }
    }
}


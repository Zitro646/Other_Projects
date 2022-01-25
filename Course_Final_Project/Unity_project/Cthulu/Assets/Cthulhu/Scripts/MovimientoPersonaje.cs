using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D cuerpoRigido;
    private Vector3 cambio;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cambio = Vector3.zero;
        
        
        //para teclado
        //cambio.x = Input.GetAxisRaw("Horizontal");
        //cambio.y = Input.GetAxisRaw("Vertical");

        //para joystick
        //utilizamos el joystick para reflejar los cambios en la variable cambio
        cambio.x = joystick.Horizontal;
        cambio.y = joystick.Vertical;

        if (cambio!= Vector3.zero)
        {
            MoverPersonaje();
        }
    }

    void MoverPersonaje()
    {
        //se puede usar tambien * Time.deltaTime dentro
        //cogemos la variable cambio y movemos el rigidbody
        cuerpoRigido.MovePosition(transform.position + cambio * velocidad);
    }
}

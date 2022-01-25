using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public Vector3 mouse;

    //Este metodo actualiza la posicion del raton constantemente
    void Update()
    {
        mouse = Input.mousePosition;
        this.transform.position = new Vector3(mouse.x,mouse.y,0);
        
    }
}

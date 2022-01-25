using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPedirInvestigador : MonoBehaviour
{
    public GameObject objeto;
    public bool touchi;

    //Este metodo actualiza constantemete el boton y comprueba la condicion
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && touchi == true)
        {
            objeto.GetComponent<PeticionesServidor>().PedirInvestigador();
        }
    }

    //Cuando un objeto toque el collider activara este metodo
    public void OnTriggerEnter(Collider other)
    {
        touchi = true;

    }

    //Cuando un objeto salga del collider activara este metodo
    public void OnTriggerExit(Collider other)
    {
        touchi = false;
    }
}

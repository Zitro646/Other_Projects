using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonActivar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed=false;
    //el boton esta pulsado
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pulsado");
        buttonPressed = true;
    }
    //el boton no esta pulsado
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    //comprobar el estado del boton
    public bool GetPressed()
    {
        return buttonPressed;
    }
}

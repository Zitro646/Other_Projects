using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mago : MonoBehaviour
{

    public GameObject antorcha1;
    public GameObject antorcha2;
    public GameObject antorcha3;
    public GameObject jugador;
    public GameObject victoria;
    public GameObject derrota;
    bool jugadorenrango;
    bool activado;
    Animator anim1;
    Animator anim2;
    Animator anim3;

    // Start is called before the first frame update
    void Start()
    {
        //recoger el animador de las antorchas
        anim1 = antorcha1.GetComponent<Animator>();
        anim2 = antorcha2.GetComponent<Animator>();
        anim3 = antorcha3.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //si el jugador esta en rango
        if (jugadorenrango)
        {
            //y las 3 antorchas puedes matar el boss si no se muere
            if (anim1.isActiveAndEnabled && anim3.isActiveAndEnabled && anim2.isActiveAndEnabled)
            {
                Debug.Log("Shinobi Execution");
                victoria.SetActive(true);
                StartCoroutine(Wait());
                
           
            }
            else
            {
                Debug.Log("Te has muerto");
                derrota.SetActive(true);
                StartCoroutine(Wait());
                
            }

        }
    }
    //busca si el jugador esta en rango
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = true;
        }
    }
    //el jugador ha salido de rango
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(jugador.tag))
        {
            jugadorenrango = false;
        }
    }
    //esperar unos segundos antes de volver al menu
    private IEnumerator Wait()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        SceneManager.LoadScene("Menu");
    }
}

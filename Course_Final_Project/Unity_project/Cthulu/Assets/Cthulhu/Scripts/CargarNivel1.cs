using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel1 : MonoBehaviour
{

    
    
    //cargar el primer nivel
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

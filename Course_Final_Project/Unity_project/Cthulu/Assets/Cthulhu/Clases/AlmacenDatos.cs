using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
//La clase almacen datos es la clase en la que almacenaremos los datos en ficheros binarios
public class AlmacenDatos
{
    //Las variables son HashSet que almacenaran las distintas clases
    private HashSet<Investigador> investigadores;
    private HashSet<Caracteristicas> caracteristicas;
    private HashSet<Trastornos> trastornos;
    private HashSet<Objetos> objetos;

    //Hacemos un metodo constructor vacio
    public AlmacenDatos() {

        investigadores = new HashSet<Investigador>();
        caracteristicas = new HashSet<Caracteristicas>();
        trastornos = new HashSet<Trastornos>();
        objetos = new HashSet<Objetos>();

    }

    //Hacemos el metodo constructor
    public AlmacenDatos(HashSet<Investigador> i , HashSet<Caracteristicas> c , HashSet<Trastornos> t, HashSet<Objetos> o) {

        //Inicializamos los arraylist 
        investigadores = new HashSet<Investigador>();
        caracteristicas = new HashSet<Caracteristicas>();
        trastornos = new HashSet<Trastornos>();
        objetos = new HashSet<Objetos>();

        //Metemos los datos
        investigadores = i;
        caracteristicas = c;
        trastornos = t;
        objetos = o;
    }

    //Hacemos los metodos get/set de las variables

    public HashSet<Investigador> getListaInvestigadores()
    {
        return investigadores;
    }

    public void setListaInvestigadores(HashSet<Investigador> i )
    {
        this.investigadores = i;
    }

    public HashSet<Caracteristicas> getListaCaracteristicas()
    {
        return this.caracteristicas;
    }

    public void setListaCaracteristicas(HashSet<Caracteristicas> c)
    {
        this.caracteristicas = c;
    }

    public HashSet<Trastornos> getListaTrastornos()
    {
        return this.trastornos;
    }

    public void setListaTrastornos(HashSet<Trastornos> t)
    {
        this.trastornos = t;
    }

    public HashSet<Objetos> getListaObjetos()
    {
        return this.objetos;
    }

    public void setListaObjetos(HashSet<Objetos> o)
    {
        this.objetos = o;
    }

}

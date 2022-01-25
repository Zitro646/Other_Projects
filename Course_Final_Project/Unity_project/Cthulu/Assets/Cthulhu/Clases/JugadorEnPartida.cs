using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class JugadorEnPartida
{
    private Investigador investigadores;
    private Caracteristicas caracteristicas;
    private Trastornos trastornos;
    private HashSet<Objetos> objetos;

    public JugadorEnPartida()
    {

        investigadores = new Investigador();
        caracteristicas = new Caracteristicas();
        trastornos = new Trastornos();
        objetos = new HashSet<Objetos>();

    }

    public JugadorEnPartida(Investigador i, Caracteristicas c, Trastornos t , HashSet<Objetos> o )
    {

        //Inicializamos los objetos y Hashset 
        investigadores = new Investigador();
        caracteristicas = new Caracteristicas();
        trastornos = new Trastornos();
        objetos = new HashSet<Objetos>();

        //Metemos los datos
        investigadores = i;
        caracteristicas = c;
        trastornos = t;
        objetos = o;
    }

    public Investigador getInvestigadores()
    {
        return investigadores;
    }

    public void setInvestigadores(Investigador i)
    {
        this.investigadores = i;
    }

    public Caracteristicas getCaracteristicas()
    {
        return this.caracteristicas;
    }

    public void setCaracteristicas(Caracteristicas c)
    {
        this.caracteristicas = c;
    }

    public Trastornos getTrastornos()
    {
        return this.trastornos;
    }

    public void setTrastornos(Trastornos t)
    {
        this.trastornos = t;
    }

    public HashSet<Objetos> getListaObjetos()
    {
        return this.objetos;
    }

    public void setListaObjetos(HashSet<Objetos> t)
    {
        this.objetos = t;
    }
}


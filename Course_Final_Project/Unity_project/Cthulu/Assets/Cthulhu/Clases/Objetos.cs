using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Objetos 
{
	//Declaramos las variables de la clase
	private string idObjeto;
	private string descripcion;
	private string coste;
	private string valor;

	//creamos un constructor vacio
	public Objetos() { 
	}

	//Creamos un constructor con solo la variable principal
	public Objetos(string idObjeto)
	{
		this.idObjeto = idObjeto;
	}

	//Creamos el constructor
	public Objetos(string idObjeto, string descripcion, string coste, string valor)
	{
		this.idObjeto = idObjeto;
		this.descripcion = descripcion;
		this.coste = coste;
		this.valor = valor;
	}

	//Creamos los metodos get / set de las variables
	public string getIdObjeto()
	{
		return this.idObjeto;
	}

	public void setIdObjeto(string idObjeto)
	{
		this.idObjeto = idObjeto;
	}


	public string getDescripcion()
	{
		return this.descripcion;
	}

	public void setDescripcion(string descripcion)
	{
		this.descripcion = descripcion;
	}

	
	public string getCoste()
	{
		return this.coste;
	}

	public void setCoste(string coste)
	{
		this.coste = coste;
	}

	public string getValor()
	{
		return this.valor;
	}

	public void setValor(string valor)
	{
		this.valor = valor;
	}
}

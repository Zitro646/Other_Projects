using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos_Recepcion
{
	public string idObjeto;
	public string descripcion;
	public string coste;
	public string valor;

	public Objetos_Recepcion()
	{
	}

	public Objetos_Recepcion(string idObjeto)
	{
		this.idObjeto = idObjeto;
	}

	public Objetos_Recepcion(string idObjeto, string descripcion, string coste, string valor)
	{
		this.idObjeto = idObjeto;
		this.descripcion = descripcion;
		this.coste = coste;
		this.valor = valor;
	}

}

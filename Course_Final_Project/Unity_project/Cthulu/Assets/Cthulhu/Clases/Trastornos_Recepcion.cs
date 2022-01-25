using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class Trastornos_Recepcion
{ 
	public string idTrastornos;
	public bool trastorno1;
	public bool trastorno2;
	public bool trastorno3;
	public bool trastorno4;
	public bool trastorno5;
	public bool trastorno6;

	public Trastornos_Recepcion()
	{
	}

	public Trastornos_Recepcion(string idTrastornos)
	{
		this.idTrastornos = idTrastornos;
	}

	public Trastornos_Recepcion(string idTrastornos, bool trastorno1, bool trastorno2, bool trastorno3,
			bool trastorno4, bool trastorno5, bool trastorno6)
	{
		this.idTrastornos = idTrastornos;
		this.trastorno1 = trastorno1;
		this.trastorno2 = trastorno2;
		this.trastorno3 = trastorno3;
		this.trastorno4 = trastorno4;
		this.trastorno5 = trastorno5;
		this.trastorno6 = trastorno6;
	}
}

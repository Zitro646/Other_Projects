using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Trastornos 
{
	//Declaramos las variables de la clase
	private string idTrastornos;
	private bool trastorno1;
	private bool trastorno2;
	private bool trastorno3;
	private bool trastorno4;
	private bool trastorno5;
	private bool trastorno6;

	//creamos un constructor vacio
	public Trastornos() {
	}

	//Creamos un constructor con solo la variable principal
	public Trastornos(string idTrastornos)
	{
		this.idTrastornos = idTrastornos;
	}

	//Creamos el constructor
	public Trastornos(string idTrastornos, bool trastorno1, bool trastorno2, bool trastorno3,
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

	//Creamos los metodos get / set de las variables
	public string getIdTrastornos()
	{
		return this.idTrastornos;
	}

	public void setIdTrastornos(string idTrastornos)
	{
		this.idTrastornos = idTrastornos;
	}

	public bool getTrastorno1()
	{
		return this.trastorno1;
	}

	public void setTrastorno1(bool trastorno1)
	{
		this.trastorno1 = trastorno1;
	}

	public bool getTrastorno2()
	{
		return this.trastorno2;
	}

	public void setTrastorno2(bool trastorno2)
	{
		this.trastorno2 = trastorno2;
	}

	public bool getTrastorno3()
	{
		return this.trastorno3;
	}

	public void setTrastorno3(bool trastorno3)
	{
		this.trastorno3 = trastorno3;
	}

	public bool getTrastorno4()
	{
		return this.trastorno4;
	}

	public void setTrastorno4(bool trastorno4)
	{
		this.trastorno4 = trastorno4;
	}

	public bool getTrastorno5()
	{
		return this.trastorno5;
	}

	public void setTrastorno5(bool trastorno5)
	{
		this.trastorno5 = trastorno5;
	}

	public bool getTrastorno6()
	{
		return this.trastorno6;
	}

	public void setTrastorno6(bool trastorno6)
	{
		this.trastorno6 = trastorno6;
	}

}

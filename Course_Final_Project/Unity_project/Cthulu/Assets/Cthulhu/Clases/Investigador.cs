using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Investigador
{
	//Declaramos las variables de la clase
	public string nombreCompleto;
	public string profesion;
	public string lugarNacimiento;
	public string idCaracteristicas;
	public string idTrastornos;
	public string sexo;
	public int edad;

	//creamos un constructor vacio
	public Investigador() { }

	//Creamos un constructor con las variables minimas
	public Investigador(string n, string p, string l, string idCar,
			string idTras)
	{
		nombreCompleto = n;
		profesion = p;
		lugarNacimiento = l;
		idCaracteristicas = idCar;
		idTrastornos = idTras;
	}

	//Creamos el constructor
	public Investigador(string n, string p, string l, string idCar,
			string idTras, string s, int e)
	{
		nombreCompleto = n;
		profesion = p;
		lugarNacimiento = l;
		idCaracteristicas = idCar;
		idTrastornos = idTras;
		sexo = s;
		edad = e;
	}

	//Creamos los metodos get / set de las variables
	public string getNombreCompleto()
	{
		return nombreCompleto;
	}

	public void setNombreCompleto(string nombreC)
	{
		nombreCompleto = nombreC;
	}

	public string getProfesion()
	{
		return profesion;
	}

	public void setProfesion(string prof)
	{
		profesion = prof;
	}

	public string getLugarNacimiento()
	{
		return this.lugarNacimiento;
	}

	public void setLugarNacimiento(string lugarN)
	{
		lugarNacimiento = lugarN;
	}

	public string getIdCaracteristicas()
	{
		return idCaracteristicas;
	}

	public void setIdCaracteristicas(string idC)
	{
		idCaracteristicas = idC;
	}

	
	public string getIdTrastornos()
	{
		return idTrastornos;
	}

	public void setIdTrastornos(string idT)
	{
		idTrastornos = idT;
	}

	public string getSexo()
	{
		return sexo;
	}

	public void setSexo(String s)
	{
		sexo = s;
	}

	
	public int getEdad()
	{
		return this.edad;
	}

	public void setEdad(int e)
	{
		edad = e;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


class Investigador_Recepcion
{
	public string nombreCompleto;
	public string profesion;
	public string lugarNacimiento;
	public string idCaracteristicas;
	public string idTrastornos;
	public string sexo;
	public int edad;

	public Investigador_Recepcion()
	{
	}

	public Investigador_Recepcion(string n, string p, string l, string idCar,
			string idTras)
	{
		nombreCompleto = n;
		profesion = p;
		lugarNacimiento = l;
		idCaracteristicas = idCar;
		idTrastornos = idTras;
	}

	public Investigador_Recepcion(string n, string p, string l, string idCar,
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
}

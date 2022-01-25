using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class Caracteristicas_Recepcion 
{
	public string idCaracteristicas;
	public int fuerza;
	public int constitucion;
	public int tamano;
	public int destreza;
	public int apariencia;
	public int inteligencia;
	public int educacion;
	public int poder;
	public int idea;
	public int suerte;
	public int conocimiento;
	public int puntosCorduraMax;
	public int puntosVidaMax;
	public int puntosMagiaMax;
	public int puntosVidaActual;
	public int puntosMagiaActual;
	public int puntosCorduraActual;

	public Caracteristicas_Recepcion()
	{
	}

	public Caracteristicas_Recepcion(string idCaracteristicas)
	{
		this.idCaracteristicas = idCaracteristicas;
	}

	public Caracteristicas_Recepcion(string idCaracteristicas, int fuerza, int constitucion, int tamano,
			int destreza, int apariencia, int inteligencia, int poder, int educacion, int idea, int suerte,
			int conocimiento, int puntosCorduraMax, int puntosVidaMax, int puntosMagiaMax,
			int puntosVidaActual, int puntosMagiaActual, int puntosCorduraActual)
	{
		this.idCaracteristicas = idCaracteristicas;
		this.fuerza = fuerza;
		this.constitucion = constitucion;
		this.tamano = tamano;
		this.destreza = destreza;
		this.apariencia = apariencia;
		this.inteligencia = inteligencia;
		this.educacion = educacion;
		this.poder = poder;
		this.idea = idea;
		this.suerte = suerte;
		this.conocimiento = conocimiento;
		this.puntosCorduraMax = puntosCorduraMax;
		this.puntosVidaMax = puntosVidaMax;
		this.puntosMagiaMax = puntosMagiaMax;
		this.puntosVidaActual = puntosVidaActual;
		this.puntosMagiaActual = puntosMagiaActual;
		this.puntosCorduraActual = puntosCorduraActual;
	}
}

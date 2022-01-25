using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Caracteristicas 
{
	//Declaramos las variables de la clase
	private string idCaracteristicas;
	private int fuerza;
	private int constitucion;
	private int tamano;
	private int destreza;
	private int apariencia;
	private int inteligencia;
	private int educacion;
	private int poder;
	private int idea;
	private int suerte;
	private int conocimiento;
	private int puntosCorduraMax;
	private int puntosVidaMax;
	private int puntosMagiaMax;
	private int puntosVidaActual;
	private int puntosMagiaActual;
	private int puntosCorduraActual;

	//creamos un constructor vacio
	public Caracteristicas() {
	}

	//Creamos un constructor con solo la variable principal
	public Caracteristicas(string idCaracteristicas)
	{
		this.idCaracteristicas = idCaracteristicas;
	}

	//Creamos el constructor
	public Caracteristicas(string idCaracteristicas, int fuerza, int constitucion, int tamano,
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


	//Creamos los metodos get / set de las variables
	public string getIdCaracteristicas()
	{
		return this.idCaracteristicas;
	}

	public void setIdCaracteristicas(string idCaracteristicas)
	{
		this.idCaracteristicas = idCaracteristicas;
	}

	public int getFuerza()
	{
		return this.fuerza;
	}

	public void setFuerza(int fuerza)
	{
		this.fuerza = fuerza;
	}

	public int getConstitucion()
	{
		return this.constitucion;
	}

	public void setConstitucion(int constitucion)
	{
		this.constitucion = constitucion;
	}

	public int getTamano()
	{
		return this.tamano;
	}

	public void setTamano(int tamano)
	{
		this.tamano = tamano;
	}

	public int getDestreza()
	{
		return this.destreza;
	}

	public void setDestreza(int destreza)
	{
		this.destreza = destreza;
	}

	public int getApariencia()
	{
		return this.apariencia;
	}

	public void setApariencia(int apariencia)
	{
		this.apariencia = apariencia;
	}

	public int getInteligencia()
	{
		return this.inteligencia;
	}

	public void setInteligencia(int inteligencia)
	{
		this.inteligencia = inteligencia;
	}

	public int getEducacion()
	{
		return this.educacion;
	}

	public void setEducacion(int educacion)
	{
		this.educacion = educacion;
	}

	public int getPoder()
	{
		return this.poder;
	}

	public void setPoder(int poder)
	{
		this.poder = poder;
	}

	public int getIdea()
	{
		return this.idea;
	}

	public void setIdea(int idea)
	{
		this.idea = idea;
	}

	public int getSuerte()
	{
		return this.suerte;
	}

	public void setSuerte(int suerte)
	{
		this.suerte = suerte;
	}

	public int getConocimiento()
	{
		return this.conocimiento;
	}

	public void setConocimiento(int conocimiento)
	{
		this.conocimiento = conocimiento;
	}

	public int getPuntosCorduraMax()
	{
		return this.puntosCorduraMax;
	}

	public void setPuntosCorduraMax(int puntosCorduraMax)
	{
		this.puntosCorduraMax = puntosCorduraMax;
	}

	public int getPuntosVidaMax()
	{
		return this.puntosVidaMax;
	}

	public void setPuntosVidaMax(int puntosVidaMax)
	{
		this.puntosVidaMax = puntosVidaMax;
	}

	public int getPuntosMagiaMax()
	{
		return this.puntosMagiaMax;
	}

	public void setPuntosMagiaMax(int puntosMagiaMax)
	{
		this.puntosMagiaMax = puntosMagiaMax;
	}

	public int getPuntosVidaActual()
	{
		return this.puntosVidaActual;
	}

	public void setPuntosVidaActual(int puntosVidaActual)
	{
		this.puntosVidaActual = puntosVidaActual;
	}

	public int getPuntosMagiaActual()
	{
		return this.puntosMagiaActual;
	}

	public void setPuntosMagiaActual(int puntosMagiaActual)
	{
		this.puntosMagiaActual = puntosMagiaActual;
	}

	public int getPuntosCorduraActual()
	{
		return this.puntosCorduraActual;
	}

	public void setPuntosCorduraActual(int puntosCorduraActual)
	{
		this.puntosCorduraActual = puntosCorduraActual;
	}

}

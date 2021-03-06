package com.example.callof.modelo;

// Generated 17-abr-2020 4:27:13 by Hibernate Tools 5.2.12.Final

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * Caracteristicas generated by hbm2java
 */
@Entity
@Table(name = "caracteristicas", catalog = "db_servidor")
public class Caracteristicas implements java.io.Serializable {

	private String idCaracteristicas;
	private Integer fuerza;
	private Integer constitucion;
	private Integer tamano;
	private Integer destreza;
	private Integer apariencia;
	private Integer inteligencia;
	private Integer educacion;
	private Integer poder;
	private Integer idea;
	private Integer suerte;
	private Integer conocimiento;
	private Integer puntosCorduraMax;
	private Integer puntosVidaMax;
	private Integer puntosMagiaMax;
	private Integer puntosVidaActual;
	private Integer puntosMagiaActual;
	private Integer puntosCorduraActual;

	public Caracteristicas() {
	}

	public Caracteristicas(String idCaracteristicas) {
		this.idCaracteristicas = idCaracteristicas;
	}

	public Caracteristicas(String idCaracteristicas, Integer fuerza, Integer constitucion, Integer tamano,
			Integer destreza, Integer apariencia, Integer inteligencia, Integer poder,Integer educacion, Integer idea, Integer suerte,
			Integer conocimiento, Integer puntosCorduraMax, Integer puntosVidaMax, Integer puntosMagiaMax,
			Integer puntosVidaActual, Integer puntosMagiaActual, Integer puntosCorduraActual) {
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

	@Id

	@Column(name = "id_caracteristicas", unique = true, nullable = false, length = 10)
	public String getIdCaracteristicas() {
		return this.idCaracteristicas;
	}

	public void setIdCaracteristicas(String idCaracteristicas) {
		this.idCaracteristicas = idCaracteristicas;
	}

	@Column(name = "Fuerza")
	public Integer getFuerza() {
		return this.fuerza;
	}

	public void setFuerza(Integer fuerza) {
		this.fuerza = fuerza;
	}

	@Column(name = "Constitucion")
	public Integer getConstitucion() {
		return this.constitucion;
	}

	public void setConstitucion(Integer constitucion) {
		this.constitucion = constitucion;
	}

	@Column(name = "tamano")
	public Integer getTamano() {
		return this.tamano;
	}

	public void setTamano(Integer tamano) {
		this.tamano = tamano;
	}

	@Column(name = "Destreza")
	public Integer getDestreza() {
		return this.destreza;
	}

	public void setDestreza(Integer destreza) {
		this.destreza = destreza;
	}

	@Column(name = "Apariencia")
	public Integer getApariencia() {
		return this.apariencia;
	}

	public void setApariencia(Integer apariencia) {
		this.apariencia = apariencia;
	}

	@Column(name = "Inteligencia")
	public Integer getInteligencia() {
		return this.inteligencia;
	}

	public void setInteligencia(Integer inteligencia) {
		this.inteligencia = inteligencia;
	}
	
	@Column(name = "Educacion")
	public Integer getEducacion() {
		return this.educacion;
	}

	public void setEducacion(Integer educacion) {
		this.educacion = educacion;
	}
	
	@Column(name = "Poder")
	public Integer getPoder() {
		return this.poder;
	}

	public void setPoder(Integer poder) {
		this.poder = poder;
	}

	@Column(name = "Idea")
	public Integer getIdea() {
		return this.idea;
	}

	public void setIdea(Integer idea) {
		this.idea = idea;
	}

	@Column(name = "Suerte")
	public Integer getSuerte() {
		return this.suerte;
	}

	public void setSuerte(Integer suerte) {
		this.suerte = suerte;
	}

	@Column(name = "Conocimiento")
	public Integer getConocimiento() {
		return this.conocimiento;
	}

	public void setConocimiento(Integer conocimiento) {
		this.conocimiento = conocimiento;
	}

	@Column(name = "Puntos_Cordura_Max")
	public Integer getPuntosCorduraMax() {
		return this.puntosCorduraMax;
	}

	public void setPuntosCorduraMax(Integer puntosCorduraMax) {
		this.puntosCorduraMax = puntosCorduraMax;
	}

	@Column(name = "Puntos_Vida_Max")
	public Integer getPuntosVidaMax() {
		return this.puntosVidaMax;
	}

	public void setPuntosVidaMax(Integer puntosVidaMax) {
		this.puntosVidaMax = puntosVidaMax;
	}

	@Column(name = "Puntos_Magia_Max")
	public Integer getPuntosMagiaMax() {
		return this.puntosMagiaMax;
	}

	public void setPuntosMagiaMax(Integer puntosMagiaMax) {
		this.puntosMagiaMax = puntosMagiaMax;
	}

	@Column(name = "Puntos_Vida_Actual")
	public Integer getPuntosVidaActual() {
		return this.puntosVidaActual;
	}

	public void setPuntosVidaActual(Integer puntosVidaActual) {
		this.puntosVidaActual = puntosVidaActual;
	}

	@Column(name = "Puntos_Magia_Actual")
	public Integer getPuntosMagiaActual() {
		return this.puntosMagiaActual;
	}

	public void setPuntosMagiaActual(Integer puntosMagiaActual) {
		this.puntosMagiaActual = puntosMagiaActual;
	}

	@Column(name = "Puntos_Cordura_Actual")
	public Integer getPuntosCorduraActual() {
		return this.puntosCorduraActual;
	}

	public void setPuntosCorduraActual(Integer puntosCorduraActual) {
		this.puntosCorduraActual = puntosCorduraActual;
	}

}

package com.example.callof.modelo;

// default package
// Generated 17-abr-2020 4:27:13 by Hibernate Tools 5.2.12.Final

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * Objetos generated by hbm2java
 */
@Entity
@Table(name = "objetos", catalog = "db_servidor")
public class Objetos implements java.io.Serializable {

	private String idObjeto;
	private String descripcion;
	private String coste;
	private String valor;

	public Objetos() {
	}

	public Objetos(String idObjeto) {
		this.idObjeto = idObjeto;
	}

	public Objetos(String idObjeto, String descripcion, String coste, String valor) {
		this.idObjeto = idObjeto;
		this.descripcion = descripcion;
		this.coste = coste;
		this.valor = valor;
	}

	@Id

	@Column(name = "id_objeto", unique = true, nullable = false, length = 10)
	public String getIdObjeto() {
		return this.idObjeto;
	}

	public void setIdObjeto(String idObjeto) {
		this.idObjeto = idObjeto;
	}

	@Column(name = "Descripcion", length = 50)
	public String getDescripcion() {
		return this.descripcion;
	}

	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}

	@Column(name = "Coste", length = 20)
	public String getCoste() {
		return this.coste;
	}

	public void setCoste(String coste) {
		this.coste = coste;
	}

	@Column(name = "Valor", length = 20)
	public String getValor() {
		return this.valor;
	}

	public void setValor(String valor) {
		this.valor = valor;
	}

}

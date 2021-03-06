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
@Table(name = "Profesiones", catalog = "db_servidor")
public class Profesiones implements java.io.Serializable {

	private int idProfesion;
	private String profesion;

	public Profesiones() {
	}

	public Profesiones(int idProfesion) {
		this.idProfesion = idProfesion;
	}

	public Profesiones(int idProfesion, String profesion) {
		this.idProfesion = idProfesion;
		this.profesion = profesion;
	}

	@Id

	@Column(name = "id_profesion", unique = true, nullable = false)
	public int getIdProfesion() {
		return this.idProfesion;
	}

	public void setIdProfesion(int idProfesion) {
		this.idProfesion = idProfesion;
	}

	@Column(name = "profesion", length = 50)
	public String getProfesion() {
		return this.profesion;
	}

	public void setProfesion(String profesion) {
		this.profesion = profesion;
	}

	
}


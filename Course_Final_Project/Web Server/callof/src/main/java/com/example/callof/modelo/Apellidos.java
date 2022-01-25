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
@Table(name = "Apellidos", catalog = "db_servidor")
public class Apellidos implements java.io.Serializable {

	private int idApellido;
	private String apellido;

	public Apellidos() {
	}

	public Apellidos(int idApellido) {
		this.idApellido = idApellido;
	}

	public Apellidos(int idApellido, String apellido) {
		this.idApellido = idApellido;
		this.apellido = apellido;
	}

	@Id

	@Column(name = "id_apellido", unique = true, nullable = false)
	public int getIdApellido() {
		return this.idApellido;
	}

	public void setIdApellido(int id_apellido) {
		this.idApellido = id_apellido;
	}

	@Column(name = "apellido", length = 50)
	public String getApellido() {
		return this.apellido;
	}

	public void setApellido(String apellido) {
		this.apellido = apellido;
	}

	
}


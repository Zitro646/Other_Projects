package com.example.callof.servicios;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.callof.modelo.*;
import com.example.callof.repositorio.*;


@Service
public class CaracteristicasService {
	
	@Autowired
	private CaracteristicasRepositorio CaracteristicasRepository;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo Crea y devuelve las caracteristicas
	public Caracteristicas crearCaracteristicas(String id){
		
		Caracteristicas caracteristicas = new Caracteristicas();
		caracteristicas.setIdCaracteristicas(id);
		//Establecemos las caracteristicas principales
		caracteristicas.setFuerza(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6());
		caracteristicas.setConstitucion(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6());
		caracteristicas.setTamano(this.un_dado_de_6()+this.un_dado_de_6()+6);
		caracteristicas.setDestreza(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6());
		caracteristicas.setApariencia(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6());
		caracteristicas.setInteligencia(this.un_dado_de_6()+this.un_dado_de_6()+6);
		caracteristicas.setPoder(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6());
		caracteristicas.setEducacion(this.un_dado_de_6()+this.un_dado_de_6()+this.un_dado_de_6()+3);
		
		//Establecemos las caracteristicas secundarias
		caracteristicas.setIdea(caracteristicas.getInteligencia()*5);
		caracteristicas.setConocimiento(caracteristicas.getEducacion()*5);
		caracteristicas.setSuerte(caracteristicas.getPoder()*5);
		
		//Establecemos los puntos de vida/magia/cordura (tanto actual como maximo)
		caracteristicas.setPuntosCorduraActual(caracteristicas.getPoder()*5);
		caracteristicas.setPuntosCorduraMax(caracteristicas.getPoder()*5);
		
		caracteristicas.setPuntosMagiaActual(caracteristicas.getPoder());
		caracteristicas.setPuntosMagiaMax(caracteristicas.getPoder());
		
		caracteristicas.setPuntosVidaMax((int)(caracteristicas.getConstitucion()+caracteristicas.getTamano())/2);
		caracteristicas.setPuntosVidaActual(caracteristicas.getPuntosVidaMax());
		
		return caracteristicas;
		
	}
	
	//Este metodo genera un numero entre 1 - 6
	public int un_dado_de_6 () {
		int num = (int)(Math.random() * 6) + 1;
		return num;
	}
	
	
}

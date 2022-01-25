package com.example.callof.servicios;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.callof.modelo.*;
import com.example.callof.repositorio.*;


@Service
public class ObjetosService {
	
	@Autowired
	private ObjetosRepositorio ObjetosRepositorio;
	
	//Ponemos los metodos que vamos ha utilizar
	
	//Este metodo devuelve un objeto aleatorio de la base de Datos
	public Objetos consultaAleatoria(){
		
		int tam = (int)ObjetosRepositorio.count();
		int obj = (int)(Math.random() * tam);
		
		String n = String.valueOf(obj + 1);
		
		Optional<Objetos> objeto = ObjetosRepositorio.findById(n);
		 if(objeto.isPresent()) {
			 Objetos o = objeto.get();
			 return o;
	 	 }else {
	 		 System.out.println("Tam BD : "+tam+"\n Num : "+obj);
	 		 return null;
	 	 }
	}
	
	//Este metodo devuelve un Objeto de la base de datos
	public Optional<Objetos> consultaporid(String id){
			return ObjetosRepositorio.findById(id);
	}
	
}

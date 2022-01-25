package com.example.callof.servicios;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.example.callof.modelo.*;
import com.example.callof.repositorio.*;


@Service
public class NombresService {
	
	@Autowired
	private NombresRepositorio nombresrepositorio;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo devuelve un nombre elegido al azar de la Base de Datos
	public String darNombre(){
		
		int tam = (int)nombresrepositorio.count();
		
		int nom = (int)(Math.random() * tam) ;
		
		Optional<Nombres> nombre = nombresrepositorio.findById(nom+1);
		
		 if(nombre.isPresent()) {
			 Nombres n = nombre.get();
			 return n.getNombre();
	 	 }else {
	 		 System.out.println("Tam BD : "+tam+"\n Num : "+nom);
	 		 return "Nombre no encontrado.";
	 	 }
		
				
		
	}
	
}

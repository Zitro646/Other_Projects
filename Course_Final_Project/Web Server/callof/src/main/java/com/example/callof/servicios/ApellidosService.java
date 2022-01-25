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
public class ApellidosService {
	
	@Autowired
	private ApellidosRepositorio apellidosrepositorio;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo devuelve un nombre elegido al azar de la Base de Datos
	public String darApellido(){
		
		int tam = (int)apellidosrepositorio.count();
		
		int ape = (int)(Math.random() * tam) ;
		
		Optional<Apellidos> apellido = apellidosrepositorio.findById(ape+1);
		
		 if(apellido.isPresent()) {
			 Apellidos a = apellido.get();
			 return a.getApellido();
	 	 }else {
	 		 System.out.println("Tam BD : "+tam+"\n Num : "+ape);
	 		 return "Apellido no encontrado.";
	 	 }
		
				
		
	}
	
}

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
public class ProfesionesService {
	
	@Autowired
	private ProfesionesRepositorio profesionesrepositorio;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo devuelve un nombre elegido al azar de la Base de Datos
	public String darProfesion(){
		
		int tam = (int)profesionesrepositorio.count();
		
		int ape = (int)(Math.random() * tam) ;
		
		Optional<Profesiones> profesion = profesionesrepositorio.findById(ape+1);
		
		 if(profesion.isPresent()) {
			 Profesiones p = profesion.get();
			 return p.getProfesion();
	 	 }else {
	 		 System.out.println("Tam BD : "+tam+"\n Num : "+ape);
	 		 return "Profesion no encontrada.";
	 	 }
		
				
		
	}
	
}

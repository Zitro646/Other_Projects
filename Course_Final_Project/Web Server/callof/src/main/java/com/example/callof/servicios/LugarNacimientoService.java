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
public class LugarNacimientoService {
	
	@Autowired
	private LugarNacimientoRepositorio lugaresNacimientorepositorio;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo devuelve un nombre elegido al azar de la Base de Datos
	public String darlugarNacimiento(){
		
		int tam = (int)lugaresNacimientorepositorio.count();
		
		int lug = (int)(Math.random() * tam) ;
		
		Optional<LugarNacimiento> lugarnac = lugaresNacimientorepositorio.findById((lug+1));
		
		 if(lugarnac.isPresent()) {
			 LugarNacimiento l = lugarnac.get();
			 return l.getLugarNac();
	 	 }else {
	 		 System.out.println("Tam BD : "+tam+"\n Num : "+lug);
	 		 return "Lugar de nacimiento no encontrado.";
	 	 }
		
	}
	
	public List<LugarNacimiento> getLugar(){
		
		//System.out.println("Id -> "+id);
		
		return lugaresNacimientorepositorio.findAll();
	}
	
}

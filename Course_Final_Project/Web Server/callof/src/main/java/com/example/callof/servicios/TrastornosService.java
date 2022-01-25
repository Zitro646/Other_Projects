package com.example.callof.servicios;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.callof.modelo.*;
import com.example.callof.repositorio.*;


@Service
public class TrastornosService {
	
	@Autowired
	private TrastornosRepositorio TranstornosRepository;
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo
	public Trastornos crearTranstornos(String id){
		
		Trastornos trastornos = new Trastornos();
		trastornos.setIdTrastornos(id); 
		trastornos.setTrastorno1(false);
		trastornos.setTrastorno2(false);
		trastornos.setTrastorno3(false);
		trastornos.setTrastorno4(false);
		trastornos.setTrastorno5(false);
		trastornos.setTrastorno6(false);
		
		return trastornos;
	}
	
	
	
	
	
	
	
}

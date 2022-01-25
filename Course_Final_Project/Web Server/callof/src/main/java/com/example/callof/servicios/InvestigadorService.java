package com.example.callof.servicios;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.callof.modelo.*;
import com.example.callof.repositorio.*;


@Service
public class InvestigadorService {
	
	@Autowired
	private InvestigadorRepositorio InvestigadorRepository;
	@Autowired
	private NombresService nombresService;
	@Autowired
	private ApellidosService apellidosService;
	@Autowired
	private ProfesionesService profesionesService;
	@Autowired
	private LugarNacimientoService lugarNacimientoService;
	
	//Ponemos los metodos que vamos ha utilizar
	
	
	//Este metodo genera un investigador
	public Investigador generar_investigador(){
		
		Investigador investigador = new Investigador();
		
		investigador.setNombreCompleto(this.generarNombreCompleto());
		investigador.setProfesion(profesionesService.darProfesion());
		investigador.setEdad(this.generarEdad());
		investigador.setLugarNacimiento(lugarNacimientoService.darlugarNacimiento());
		investigador.setSexo("Hombre");//"Hombre" / "Mujer"
		investigador.setIdCaracteristicas(this.generarid());
		investigador.setIdTrastornos(this.generarid());
		
		return investigador;
	}
	
	
	//Este metodo generara un nombre
	public String generarNombreCompleto() {
	
		String nombre= "";
		nombre = nombresService.darNombre() +" "+ apellidosService.darApellido() +" "+ apellidosService.darApellido();
		return nombre;
	}
	

	//Este metodo determina la edad del investigador
	public int generarEdad() {
		int edad =  (int)(Math.random() * 50) + 22;
		return edad;
	}
	
	//Este metodo genera el sexo del investigador
	public String generarSexo() {
		
		int num = (int)(Math.random() * 2) ;
			
		ArrayList<String> genero = new ArrayList<String>();
		genero.add("Hombre");
		genero.add("Mujer");
		
		return genero.get(num);
		
	}
	
	//Este metodo sirve para generar una id aleatoria
	public String generarid() {
		
		String id="";
		//Mejorar eficiencia haciendo una tabla nueva
		ArrayList<String> ids = new ArrayList<String>();
		ids.add("a");
		ids.add("b");
		ids.add("c");
		ids.add("d");
		ids.add("e");
		ids.add("f");
		ids.add("g");
		ids.add("h");
		ids.add("i");
		ids.add("j");
		ids.add("k");
		ids.add("l");
		ids.add("m");
		ids.add("n");
		ids.add("o");
		ids.add("p");
		ids.add("k");
		ids.add("r");
		ids.add("s");
		ids.add("t");
		ids.add("u");
		ids.add("v");
		ids.add("w");
		ids.add("x");
		ids.add("y");
		ids.add("z");
		ids.add("0");
		ids.add("1");
		ids.add("2");
		ids.add("3");
		ids.add("4");
		ids.add("5");
		ids.add("6");
		ids.add("7");
		ids.add("8");
		ids.add("9");
		
		do {
			
			int num = (int)(Math.random() * 35) + 1;
			id= id+ids.get(num);
			
		}while(id.length()<10);
		
		return id;
		
	}
	
	
}

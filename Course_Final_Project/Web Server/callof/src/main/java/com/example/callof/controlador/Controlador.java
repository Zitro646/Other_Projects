package com.example.callof.controlador;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.callof.modelo.Caracteristicas;
import com.example.callof.modelo.Investigador;
import com.example.callof.modelo.LugarNacimiento;
import com.example.callof.modelo.Objetos;
import com.example.callof.modelo.Trastornos;
import com.example.callof.servicios.CaracteristicasService;
import com.example.callof.servicios.InvestigadorService;
import com.example.callof.servicios.LugarNacimientoService;
import com.example.callof.servicios.ObjetosService;
import com.example.callof.servicios.TrastornosService;
@Controller

public class Controlador {
	
	@Autowired
	private ObjetosService objetosService;
	@Autowired
	private InvestigadorService investigadorService;
	@Autowired
	private CaracteristicasService caracteristicasService;
	@Autowired
	private TrastornosService trastornosService;
	
	 @RequestMapping("/")
	 @ResponseBody
		 String home() {
		 	return "Controller";
		 }
	 
	 /* 1 Este metodo devuelve un objeto */
	 @RequestMapping(value = "/objetos", method = RequestMethod.GET)
	 public ResponseEntity<Objetos> pedirObjetoConcreto(){
		 	 Objetos obj = objetosService.consultaAleatoria();
		 	 return new ResponseEntity<Objetos>(obj,HttpStatus.OK);
	 }
	 
	 /* 2 Este metodo crea la informacion del investigador */
	 @RequestMapping(value = "/investigador/parametros_generales", method = RequestMethod.GET)
	 public ResponseEntity<Investigador> crearInvestigador_parametros_generales(){
	    	 return new ResponseEntity<Investigador>(investigadorService.generar_investigador(),HttpStatus.OK);
	 }
	 
	 /* 3 Este metodo crea las caracteristicas del investigador */
	 @RequestMapping(value = "/investigador/caracteristicas/{id}", method = RequestMethod.GET)
	 public ResponseEntity<Caracteristicas> crearInvestigador_caracteristicas(@PathVariable("id") String id){
		 	return new ResponseEntity<Caracteristicas>(caracteristicasService.crearCaracteristicas(id),HttpStatus.OK);	 
	 } 
	 
	 /* 4 Este metodo crea los transtornos del investigador */
	 @RequestMapping(value = "/investigador/trastornos/{id}", method = RequestMethod.GET)
	 public ResponseEntity<Trastornos> crearInvestigador_trastornos(@PathVariable("id") String id){
		 	return new ResponseEntity<Trastornos>(trastornosService.crearTranstornos(id),HttpStatus.OK);
	 } 
	 
 
}

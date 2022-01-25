package com.example.buscaminas;

import android.util.Log;

public class logicaBuscaMinas {

    //Establecemos la logica
    private int tablero[][];
    private int tablero_pulsados[][];
    private int tamanomaximo;
    private int poner_minas;

    //Creamos el modo constructor
    public logicaBuscaMinas(){

    }

    //Creamos el metodo iniciar que pone todos los valores a 0
    public void iniciar(String dificultad){
        //Establecemos la dificultad
        if(dificultad.equals("Principiante")){
            tablero=new int[8][8];
            tablero_pulsados=new int[8][8];
            tamanomaximo=8;
            poner_minas=10;
        }else if(dificultad.equals("Amateur")){
            tablero=new int[12][12];
            tablero_pulsados=new int[12][12];
            tamanomaximo=12;
            poner_minas=20;
        }else if(dificultad.equals("Profesional")){
            tablero=new int[16][16];
            tablero_pulsados=new int[16][16];
            tamanomaximo=16;
            poner_minas=30;
        }
        //Llamamos a los metodos correspondientes
        limpia_comprobaciones();
        limpia_tablero();
        //Colocamos minas aleatoriamente
        colocarMinas();
    }

    //Creamos un metodo que coloque 10 minas
    public void colocarMinas(){
        double aleatorio;
        int acorte;
        int acorte2;
        int minasrestantes = poner_minas;
        //Esta funcion creara posiciones aleatorias donde poner minas, si ya hubiera una
        //se se descartaria
        do{
            aleatorio = Math.random()*tamanomaximo;
            acorte = (int) aleatorio;
            aleatorio = Math.random()*tamanomaximo;
            acorte2 = (int) aleatorio;
            if(!compruebaMina(acorte,acorte2)){
                minasrestantes--;
                tablero[acorte][acorte2]=1;
            }
        }while(minasrestantes>0);
        generar_mapa();
    }

    //Creamos un metodo que nos diga si la casilla tiene una mina
    public boolean compruebaMina(int filas,int columnas){
        if(tablero[filas][columnas]!=1){
            return false;
        }else{
            return true;
        }
    }

    //Este metodo dice si hay minas cerca de la casilla
    public int calculaminasproximas(int fila,int columna) {
        int minascerca=0;
        if(fila > 0 && columna > 0) {
            if(tablero[fila-1][columna-1]==1 ){
                minascerca++;
            }
        }
        if(fila>0){
            if(tablero[fila-1][columna]==1 ){
                minascerca++;
            }
        }
        if(fila>0 && columna<(tamanomaximo-1)){
            if(tablero[fila-1][columna+1]==1 ) {
                minascerca++;
            }
        }
        if(columna>0) {
            if(tablero[fila][columna-1]==1 ) {
                minascerca++;
            }
        }
        if(columna<(tamanomaximo-1)) {
            if(tablero[fila][columna+1]==1 ) {
                minascerca++;
            }
        }
        if(fila<(tamanomaximo-1) && columna>0){
            if(tablero[fila+1][columna-1]==1 ) {
                minascerca++;
            }
        }
        if(fila<(tamanomaximo-1)){
            if(tablero[fila+1][columna]==1 ) {
                minascerca++;
            }
        }
        if(fila<(tamanomaximo-1) && columna<(tamanomaximo-1) ){
            if(tablero[fila+1][columna+1]==1 ) {
                minascerca++;
            }
        }

        return minascerca;
    }


    //este metodo comprieba si la casilla fue pulsada anteriormente
    public boolean comprobar_Casilla_pulsada(int fila,int columna){

        if(tablero_pulsados[fila][columna]==0){
            return false;
        }else{
            return true;
        }

    }
    //Este metodo marca la casilla como pulsada
    public void  pulsar_Casilla(int fila,int columna){
        tablero_pulsados[fila][columna]=1;
    }

    //Calcula la posicion x de una casilla
    public int calculaFila(int posicion){
        int fila=0;
        //por el tamaño del tablero
        if(tamanomaximo==8){
            while(posicion>=8){
                fila++;
                posicion=posicion-8;
            }
        }else if(tamanomaximo==12){
            while(posicion>=12){
                fila++;
                posicion=posicion-12;
            }
        }else if(tamanomaximo==16){
            while(posicion>=16){
                fila++;
                posicion=posicion-16;
            }
        }


        return fila;
    }
    //Calcula la posicion y de una casilla
    public int calculaColumna(int posicion){
        int columna=-1;
        //por tamaño de tablero
        if(tamanomaximo==8){
            while(posicion>=8){
                posicion = posicion - 8;
            }
            if(posicion<8){
                columna=posicion;
            }
        }else if(tamanomaximo==12){
            while(posicion>=12){
                posicion = posicion - 12;
            }
            if(posicion<12){
                columna=posicion;
            }
        }else if(tamanomaximo==16){
            while(posicion>=16){
                posicion = posicion - 16;
            }
            if(posicion<16){
                columna=posicion;
            }
        }

        return columna;

    }

    //Calculamos la posicion en el adapter introduciendo el numero de fila y de columna
    public int calculaposicionadapter(int fila,int columna){
        //Por tamaño de tablero
        int posicion=0;
        if(tamanomaximo == 8){
            while(fila>0){
                posicion=posicion+8;
                fila--;
            }
            posicion=posicion+columna;
        }else if(tamanomaximo == 12){
            while(fila>0){
                posicion=posicion+12;
                fila--;
            }
            posicion=posicion+columna;
        }else if(tamanomaximo == 16){
            while(fila>0){
                posicion=posicion+16;
                fila--;
            }
            posicion=posicion+columna;
        }
        //Log.e("Pulsado","posicion :"+posicion);
        return posicion;
    }

    //este metodo establece todas las posiciones del tablero a 0(sin minas)
    public void limpia_tablero(){
        for(int i=0; i<=(tamanomaximo-1); i++){
            for(int i2=0;i2<=(tamanomaximo-1);i2++){
                tablero[i][i2] = 0;
            }
        }
    }

    //Este metodo establece que el tablero no ha sido pulasado
    public void limpia_comprobaciones(){
        for(int i=0; i<=(tamanomaximo-1); i++){
            for(int i2=0;i2<=(tamanomaximo-1);i2++){
                tablero_pulsados[i][i2] = 0;
            }
        }
    }


    //este metodo nos devuelve el tamaño del tablero
    public int getTamanomaximo(){
        return tamanomaximo;
    }

    //este metodo genera un mapa logico del tablero por Log.e en "Error"
    public void generar_mapa(){

        String fila= "";

        for(int i=0;i<(tamanomaximo);i++){

            for(int i2=0;i2<(tamanomaximo);i2++){

                if(compruebaMina(i,i2)){
                    fila = fila+ "M ";
                }else{
                    fila = fila +calculaminasproximas(i,i2)+" ";
                }

            }
            Log.e("Error",fila + " : "+i);

            fila= "";
        }

    }
}

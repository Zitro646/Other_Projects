package com.example.buscaminas;

import android.media.MediaPlayer;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.view.Menu;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Toolbar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;


public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    //Instanciamos las variables necesarias para correr el programa
    private RecyclerView recyclerView;
    private MediaPlayer mplayer;
    private ExampleAdapter adapter;
    private RecyclerView.LayoutManager layoutManager;
    private ArrayList<ExampleItem> exampleList=new ArrayList<>();
    private logicaBuscaMinas logica;
    private String dificultad;
    private boolean juegoactivo;
    private int minas_activas;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //Cuando creamos la app instanciamos la musica
        //Aun que esta vez fue apagada para de manera temporal, se puede reiniciar en el menu opciones
        if(mplayer!=null){
            mplayer.release();
        }
        mplayer = MediaPlayer.create(this,R.raw.cancion);

        mplayer.seekTo(0);
        //mplayer.start();

        //establecemos el adapter y la logica
        adapter = new ExampleAdapter();
        logica = new logicaBuscaMinas();

        //Establecemos la dificultad y activamos el juego
        establecerDificultad("Principiante");
        juegoactivo=true;




        adapter.setOnLongClickListener(new ExampleAdapter.OnItemLongClickListener() {
            //Método que responde ante el evento de click en uno de los items(elemento del recycler view)
            //Problema:(¿Qué item dentro del recycler view ha generado el evento?)
            @Override
            public boolean onItemLongClicked(int position) {

                if(juegoactivo){

                    //Sacamos las posiciones del array
                    int columna = logica.calculaColumna(position);//x
                    int fila = logica.calculaFila(position);//y
                    //Comprobamos que la casilla este pulsada
                    if(!logica.comprobar_Casilla_pulsada(fila,columna)){
                        //Si no hay mina se acaba el juego
                        if(!logica.compruebaMina(fila,columna)){

                            Toast.makeText(MainActivity.this, "Has fallado , sige intentadolo", Toast.LENGTH_SHORT).show();
                            juegoactivo = false;
                            exampleList.get(position).setImageResource(R.drawable.mina_fallo);
                            logica.pulsar_Casilla(fila,columna);
                            revelar_mapa();

                        }else{
                            //Si la hay se reduce el contador y si este llega a 0 gana
                            minas_activas--;

                            if(minas_activas==0){

                                Toast.makeText(MainActivity.this, "Genial has desactivado todas las minas", Toast.LENGTH_SHORT).show();
                                juegoactivo=false;
                            }else{
                                Toast.makeText(MainActivity.this, "Bien echo sigue asi", Toast.LENGTH_SHORT).show();
                            }

                            exampleList.get(position).setImageResource(R.drawable.mina_desactivada);

                        }
                        logica.pulsar_Casilla(fila,columna);
                    }else{

                        Toast.makeText(MainActivity.this, "Esta casilla ya fue pulsada", Toast.LENGTH_SHORT).show();
                    }

                    adapter.notifyItemChanged(position);
                }else{
                    Toast.makeText(MainActivity.this, "Esta partida ya acabo", Toast.LENGTH_SHORT).show();
                }
                return false;
            }
        });


        adapter.setOnClickListener(new ExampleAdapter.OnItemClickListener() {
            //Método que responde ante el evento de click en uno de los items(elemento del recycler view)
            //Problema:(¿Qué item dentro del recycler view ha generado el evento?)
            @Override
            public void OnItemClick(int position) {
                //Sacamos las posiciones del array
                int columna = logica.calculaColumna(position);//x
                int fila = logica.calculaFila(position);//y
                Log.e("Pulsado"," columna : "+columna+" , fila :"+fila + ", posicion : "+ position);
                //Log.e("Error", logica.calculaminasproximas(fila,columna)+" minas cerca");
                if(juegoactivo){
                    //Comprobamos que la casilla no este pulsada
                    if(!logica.comprobar_Casilla_pulsada(fila,columna)){
                        //Si no hay mina llamamos al metodo que rellena la casilla
                        if(!logica.compruebaMina(fila,columna)){
                            rellena_casilla(fila,columna);
                            logica.pulsar_Casilla(fila,columna);
                        }else{
                            //La casilla pulsada contiene una mina el jugador ha perdido
                            juegoactivo=false;

                            exampleList.get(position).setImageResource(R.drawable.mina_explosion);
                            Toast.makeText(MainActivity.this, "Mina pisada abortando simulacion", Toast.LENGTH_SHORT).show();
                            logica.pulsar_Casilla(fila,columna);
                            revelar_mapa();
                        }
                    }else{
                        Toast.makeText(MainActivity.this, "Esta casilla esta pulsada , prueba otra", Toast.LENGTH_SHORT).show();
                    }
                }else{
                    Toast.makeText(MainActivity.this, "Esta partida ya acabo", Toast.LENGTH_SHORT).show();
                }
                adapter.notifyItemChanged(position);
            }
        });
        recyclerView.setLayoutManager(layoutManager);
        recyclerView.setAdapter(adapter);

    }

    //Este metodo establece la dificultad
    public void establecerDificultad(String nivel){
        //Establecemos los distintos tipos de dificultad
        // Principiante Amateur Profesional
        int numColumnas, numFilas;
        switch ((nivel)){
            case "Principiante":
                //Creamos el reciclerView
                numColumnas=8;
                numFilas=8;
                //Limpiamos el example list
                exampleList.clear();
                //Ponemos la cantidad de minas
                minas_activas=10;
                //Rellenamos el examplelist
                for (int i=0;i<numColumnas*numFilas;i++) {
                    exampleList.add(new ExampleItem(R.drawable.fondo));
                }

                recyclerView=findViewById(R.id.recyclerView);
                recyclerView.setMinimumHeight(264);
                recyclerView.setMinimumWidth(264);
                recyclerView.setHasFixedSize(true);
                layoutManager=new GridLayoutManager(this,numColumnas);
                recyclerView.setLayoutManager(layoutManager);
                //Establecemos en logica el nivel
                logica.iniciar("Principiante");
                adapter.setExampleList(exampleList);
                //Establecemos en Main el nivel
                dificultad = "Principiante";


                break;
            case "Amateur":
                numColumnas=12;
                numFilas=12;
                //Es igual quie el principiante solo que algunos parametros se cambian para adaptar la dificultad
                exampleList.clear();

                minas_activas=20;

                for (int i=0;i<numColumnas*numFilas;i++) {
                    exampleList.add(new ExampleItem(R.drawable.fondo));
                }

                recyclerView=findViewById(R.id.recyclerView);
                recyclerView.setMinimumHeight(396);
                recyclerView.setMinimumWidth(396);
                recyclerView.setHasFixedSize(true);
                layoutManager=new GridLayoutManager(this,numColumnas);
                recyclerView.setLayoutManager(layoutManager);
                logica.iniciar("Amateur");
                adapter.setExampleList(exampleList);
                dificultad = "Amateur";


                break;
            case "Profesional":
                numColumnas=16;
                numFilas=16;
                //Es igual quie el principiante solo que algunos parametros se cambian para adaptar la dificultad
                exampleList.clear();

                minas_activas=30;
                for (int i=0;i<numColumnas*numFilas;i++) {
                    exampleList.add(new ExampleItem(R.drawable.fondo));
                }

                recyclerView=findViewById(R.id.recyclerView);
                recyclerView.setMinimumHeight(512);
                recyclerView.setMinimumWidth(512);
                recyclerView.setHasFixedSize(true);
                layoutManager=new GridLayoutManager(this,numColumnas);
                recyclerView.setLayoutManager(layoutManager);

                logica.iniciar("Profesional");
                adapter.setExampleList(exampleList);
                dificultad = "Profesional";
                Log.e("Error","la dificultad es "+dificultad);

                break;
        }

    }



    @Override
    //Cuando hagan click en uno de los distintos botones haran lo siguiente
    public void onClick(View view){

        switch (view.getId()) {}

    }

    //Este metodo comprueba las casillas adyacentes(estilo arriba,izquierda,derecha,abajo)
    public void llama_casillas_adyacentes(int fila,int columna){
        //Obtenemos el tamaño maximo de la logica
        int maximo = logica.getTamanomaximo();
        //Comprbamos una a una si el parametro es el correcto
        if(columna>0){
            //Una vez dentro comprobamos que la casilla fue pulsada, si no lo fue llamamos al metodo rellenar casilla
            if(!logica.comprobar_Casilla_pulsada(fila,columna-1)){
                rellena_casilla(fila,columna-1);
            }
        }

        if(columna<(maximo-1)){
            if(!logica.comprobar_Casilla_pulsada(fila,columna+1)){
                rellena_casilla(fila,columna+1);
            }
        }

        if(fila>0){
            if(!logica.comprobar_Casilla_pulsada(fila-1,columna)){
                rellena_casilla(fila-1,columna);
            }
        }

        if(fila<(maximo-1)){
            if(!logica.comprobar_Casilla_pulsada(fila+1,columna)){
                rellena_casilla(fila+1,columna);
            }
        }

    }

    //El metodo rellenar casilla rellena una casilla segun la informacion que contenga
    public void rellena_casilla(int fila,int columna){
        //Calculamos la posicion en el examplelist
        int position=logica.calculaposicionadapter(fila,columna);
        //Calculamos si hay minas cerca de la casilla
        int minascercanas=logica.calculaminasproximas(fila,columna);
        //Comprobamos si la casilla fue pulsada anteriormente
        if(!logica.comprobar_Casilla_pulsada(fila,columna)){

            if(minascercanas==0){
                //Si la cantidad de minas cerca es 0 debera de declarar pulsado y entonces se llama al rellena casillas adyacentes
                exampleList.get(position).setImageResource(R.drawable.adyacente0);
                logica.pulsar_Casilla(fila,columna);
                llama_casillas_adyacentes(fila,columna);
            }else if(minascercanas==1){
                exampleList.get(position).setImageResource(R.drawable.adyacente1);
            }else if(minascercanas==2){
                exampleList.get(position).setImageResource(R.drawable.adyacente2);
            }else if(minascercanas==3){
                exampleList.get(position).setImageResource(R.drawable.adyacente3);
            }else if(minascercanas==4){
                exampleList.get(position).setImageResource(R.drawable.adyacente4);
            }else if(minascercanas==5){
                exampleList.get(position).setImageResource(R.drawable.adyacente5);
            }else if(minascercanas==6){
                exampleList.get(position).setImageResource(R.drawable.adyacente6);
            }else if(minascercanas==7){
                exampleList.get(position).setImageResource(R.drawable.adyacente6);
            }else if(minascercanas==8){
                exampleList.get(position).setImageResource(R.drawable.adyacente6);
            }
            //Aqui comprobamos que la casilla no sea mina
            if(logica.compruebaMina(fila,columna)){
                exampleList.get(position).setImageResource(R.drawable.mina);
            }
            //Notificamos el cambio
            adapter.notifyItemChanged(position);

        }
    }

    //Metodo para crear mostrar y ocultar el menu

        public boolean onCreateOptionsMenu(Menu menu){

            getMenuInflater().inflate(R.menu.overflow,menu);
            return true ;
        }

        public boolean onOptionsItemSelected(MenuItem item){
            int id = item.getItemId();
            //Aqui establecemos las distintas opciones del codigo
            // Principiante Amateur Profesional
            if(id== R.id.item_1){
                opendialog();
            }else if(id== R.id.item_2){

            }else if(id== R.id.item_3){
                //Reiniciamos la partida
                juegoactivo=true;
                if(dificultad.equals("Principiante")){

                    for(int i = 0;i<64;i++) {
                        //Reiniciamos las imagenes del reciclerview
                        exampleList.get(i).setImageResource(R.drawable.fondo);
                        adapter.notifyItemChanged(i);
                    }
                    //Reiniciamos la logica con el metodo iniciar
                    logica.iniciar("Principiante");

                }else if(dificultad.equals("Amateur")){

                    for(int i = 0;i<144;i++) {
                        //Reiniciamos las imagenes del reciclerview
                        exampleList.get(i).setImageResource(R.drawable.fondo);
                        adapter.notifyItemChanged(i);
                    }
                    logica.iniciar("Amateur");



                }else
                Log.e("Error","Dificultad : " +dificultad);
                if(dificultad=="Profesional"){
                    for(int i = 0;i<256;i++) {    //Reiniciamos las imagenes del reciclerview
                        exampleList.get(i).setImageResource(R.drawable.fondo);
                        adapter.notifyItemChanged(i);
                    }
                    logica.iniciar("Profesional");
                }

            }else if(id== R.id.subitem_1){
                //Restablecemos el juego
                juegoactivo=true;
                //Su dificultad
                establecerDificultad("Principiante");
                for(int i = 0;i<64;i++) {
                    //Reiniciamos las imagenes del reciclerview
                    exampleList.get(i).setImageResource(R.drawable.fondo);
                    adapter.notifyItemChanged(i);
                }
                //Log.e("Error","tamaño maximo es de -> "+logica.getTamanomaximo());

            }else if(id== R.id.subitem_2){
                //Restablecemos el juego
                juegoactivo=true;
                //Su dificultad
                establecerDificultad("Amateur");
                for(int i = 0;i<144;i++) {
                    //Reiniciamos las imagenes del reciclerview
                    exampleList.get(i).setImageResource(R.drawable.fondo);
                    adapter.notifyItemChanged(i);
                }
                //Log.e("Error","tamaño maximo es de -> "+logica.getTamanomaximo());

            }else if(id== R.id.subitem_3){
                //Restablecemos el juego
                juegoactivo=true;
                //Su dificultad
                establecerDificultad("Profesional");
                for(int i = 0;i<256;i++) {    //Reiniciamos las imagenes del reciclerview
                    exampleList.get(i).setImageResource(R.drawable.fondo);
                    adapter.notifyItemChanged(i);
                }
                //Log.e("Error","tamaño maximo es de -> "+logica.getTamanomaximo());

            }else if(id== R.id.subitem_4){

                //Metodo para parar la musica
                if(mplayer!=null){
                    mplayer.release();
                }

            }else if(id== R.id.subitem_5){
                //Comprobamos que haya musica, si la hay se detiene
                if(mplayer!=null){
                    mplayer.release();
                }
                //Establecemos la cancion a poner
                mplayer = MediaPlayer.create(this,R.raw.cancion);
                //Ponemos la cancion al segundo 0
                mplayer.seekTo(0);
                //iniciamos cancion
                mplayer.start();
            }

            return super.onOptionsItemSelected(item);
        }

        public void opendialog(){

            ExampleDialog prueba = new ExampleDialog();
            prueba.show(getSupportFragmentManager(),"example");

        }

        //este metodo es para cuando se pierde la partida, que revele el mapa
        public void revelar_mapa(){
        //Miramos la dificultad del juego
        if(dificultad=="Principiante"){
            //aqui es dimplemente ir casilla por casilla rellenandolas
            for(int i=0;i<8;i++) {
                for (int i2 = 0; i2 < 8; i2++) {
                    rellena_casilla(i, i2);
                }
            }

        }else if(dificultad=="Amateur"){

            for(int i=0;i<12;i++) {
                for (int i2 = 0; i2 < 12; i2++) {
                    rellena_casilla(i, i2);
                }
            }
        }else if(dificultad=="Profesional"){

            for(int i=0;i<16;i++) {
                for (int i2 = 0; i2 < 16; i2++) {
                    rellena_casilla(i, i2);
                }
            }
    }

        }

}


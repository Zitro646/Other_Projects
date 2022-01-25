using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



public class PeticionesServidor : MonoBehaviour
{

    //Este metodo se utilizara para pedir los datos de un investigador
    public void PedirInvestigador()
    {
        //Se utiliza para poder conectarse a un servidor en la web.
        WebClient client = new WebClient();



        //Descargamos los datos del investigador
        string generales = client.DownloadString("http://192.168.1.129:9090/investigador/parametros_generales");
        Investigador_Recepcion i = new Investigador_Recepcion();
        //Convertimos el Json descargado en un objeto Investigador
        i = JsonUtility.FromJson<Investigador_Recepcion>(generales);
        Investigador inv = new Investigador(i.nombreCompleto, i.profesion, i.lugarNacimiento, i.idCaracteristicas, i.idTrastornos, i.sexo, i.edad);



        //Descargamos las caracteristicas del investigador
        string caracteristicas = client.DownloadString("http://192.168.1.129:9090/investigador/caracteristicas/" + inv.getIdCaracteristicas());
        Caracteristicas_Recepcion c = new Caracteristicas_Recepcion();
        //Convertimos el Json descargado en un objeto Caracteristicas
        c = JsonUtility.FromJson<Caracteristicas_Recepcion>(caracteristicas);

        Caracteristicas car = new Caracteristicas(c.idCaracteristicas, c.fuerza, c.constitucion, c.tamano, c.destreza,
            c.apariencia, c.inteligencia, c.educacion, c.poder, c.idea, c.suerte, c.conocimiento, c.puntosCorduraMax, c.puntosVidaMax,
            c.puntosMagiaMax, c.puntosVidaActual, c.puntosMagiaActual, c.puntosCorduraActual);


        //Descargamos los trastornos del investigador
        string trastornos = client.DownloadString("http://192.168.1.129:9090/investigador/trastornos/" + inv.getIdTrastornos());
        Trastornos_Recepcion t = new Trastornos_Recepcion();
        //Convertimos el Json descargado en un objeto Trastornos
        t = JsonUtility.FromJson<Trastornos_Recepcion>(trastornos);

        Trastornos tra = new Trastornos(t.idTrastornos, t.trastorno1, t.trastorno2, t.trastorno3, t.trastorno4, t.trastorno5, t.trastorno6);


        //Creamos la BD en el fichero

        //Archivamos los datos recibidos en codigo binario
        BinaryFormatter formatter = new BinaryFormatter();

        //Creamos el fichero del investigador
        AlmacenDatos almacen = new AlmacenDatos();
        bool keepfichero = true;
        
        try {

            FileStream fs = new FileStream(Application.persistentDataPath + "/Datos_Almacenados.dat", FileMode.Open);
            almacen = (AlmacenDatos)formatter.Deserialize(fs);
            fs.Close();
            print("Fichero encontrado");
        }
        catch (FileNotFoundException e)
        {

            print("Fichero no encontrado");
            keepfichero = false;

        }
        

        HashSet<Investigador> i1 = new HashSet<Investigador>();
        HashSet<Caracteristicas> c1 = new HashSet<Caracteristicas>();
        HashSet<Trastornos> t1 = new HashSet<Trastornos>();
        HashSet<Objetos> o1 = new HashSet<Objetos>();

        if (keepfichero == true)
        {
            i1 = almacen.getListaInvestigadores();
            c1 = almacen.getListaCaracteristicas();
            t1 = almacen.getListaTrastornos();
            o1  = almacen.getListaObjetos();
        }

        i1.Add(inv);
        c1.Add(car);
        t1.Add(tra);

        AlmacenDatos alma = new AlmacenDatos(i1, c1, t1, o1);

        //Creamos el fichero del investigador
        FileStream fs1 = new FileStream(Application.persistentDataPath + "/Datos_Almacenados.dat", FileMode.OpenOrCreate);
        formatter.Serialize(fs1, alma);
        fs1.Close();

        print("Nuevo investigador añadido ->" + inv.getNombreCompleto());
        print("tamaño ->" + i1.Count);



    }

    public void pedirObjeto()
    {
        //Se utiliza para poder conectarse a un servidor en la web.
        WebClient client = new WebClient();

        //Descargamos los datos del objeto
        string objeto = client.DownloadString("http://192.168.1.129:9090/objetos");
        Objetos_Recepcion o = new Objetos_Recepcion();
        //Convertimos el Json descargado en un objeto Investigador
        o = JsonUtility.FromJson<Objetos_Recepcion>(objeto);
        Objetos obj = new Objetos(o.idObjeto, o.descripcion, o.coste, o.valor);

        //Archivamos los datos recibidos en codigo binario
        BinaryFormatter formatter = new BinaryFormatter();
        AlmacenDatos almacen = new AlmacenDatos();
        bool keepfichero = true;

        //Abrimos el fichero del objeto
        try
        {
            FileStream fs = new FileStream(Application.persistentDataPath + "/Datos_Almacenados.dat", FileMode.Open);
            almacen = (AlmacenDatos)formatter.Deserialize(fs);
            fs.Close();
            print("Fichero encontrado");
        }
        catch (FileNotFoundException e)
        {
            print("Fichero no encontrado");
            keepfichero = false;
        }
        HashSet<Objetos> o1 = new HashSet<Objetos>();

        if (keepfichero == true)
        {
            o1 = almacen.getListaObjetos();
        }

        o1.Add(obj);
        almacen.setListaObjetos(o1);

        //Sobreescribimos/Creamos el fichero del investigador
        FileStream fs1 = new FileStream(Application.persistentDataPath + "/Datos_Almacenados.dat", FileMode.OpenOrCreate);
        formatter.Serialize(fs1, almacen);
        fs1.Close();

    }

}

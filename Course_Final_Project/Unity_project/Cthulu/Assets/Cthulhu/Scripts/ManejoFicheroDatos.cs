using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



//Desde esta clase trataremos de manejar todos los ficheros
public class ManejoFicheroDatos : MonoBehaviour
{
    //Este metodo nos devuelve el almacen de Datos del Fichero.dat
    public AlmacenDatos obtenerDatosFichero()
    {
        try
        {
            //Archivamos los datos en codigo binario
            BinaryFormatter formatter = new BinaryFormatter();
            //Creamos el fichero del investigador
            FileStream fs = new FileStream(Application.persistentDataPath + "/Datos_Almacenados.dat", FileMode.Open);
            //FileStream fs = new FileStream("./Assets/Cthulhu/FicheroDatos/Datos_Almacenados.dat", FileMode.Open);
            AlmacenDatos almacen = new AlmacenDatos();
            try
            {
                almacen = (AlmacenDatos)formatter.Deserialize(fs);
            }
            catch(InvalidCastException e)
            {
                print("Fallo de carga de clase");
            }
            fs.Close();
            return almacen;
        }
        catch (FileNotFoundException e)
        {
            print("Fichero no encontrado");
            return new AlmacenDatos();
        }

    }

    //Este metodo nos devuelve el Investigador_Jugable del Fichero.dat
    public JugadorEnPartida obtenerDatosInvestigadorJugable()
    {

        //Archivamos los datos en codigo binario
        BinaryFormatter formatter = new BinaryFormatter();

        //Creamos el fichero del investigador
        FileStream fs = new FileStream(Application.persistentDataPath + "/Investigador_Juego.dat", FileMode.Open);
        JugadorEnPartida jugador = (JugadorEnPartida)formatter.Deserialize(fs);
        fs.Close();

        return jugador;

    }

    //Este metodo busca las caracteristicas por la id en el Fichero.dat del Almacen de Datos
    public Caracteristicas buscarCaracteristicasPorID(string id)
    {

        AlmacenDatos almacen = obtenerDatosFichero();
        HashSet<Caracteristicas> c1 = almacen.getListaCaracteristicas();

        foreach (Caracteristicas c in c1)
        {
          
            if (c.getIdCaracteristicas().Equals(id))
            {
                return c;
            }

        }

        return null;
    }

    //Este metodo busca los trastornos por id en el Fichero.dat del Almacen de Datos
    public Trastornos buscarTrastornoPorID(string id)
    {
        AlmacenDatos almacen = obtenerDatosFichero();
        HashSet<Trastornos> t1 = almacen.getListaTrastornos();

        foreach (Trastornos t in t1)
        {
            if (t.getIdTrastornos().Equals(id))
            {
                return t;
            }

        }
        return null;
    }

    //Este metodo devuelve el investigador por posicion en el Fichero.dat del Almacen de Datos
    public Investigador ObtenerInvestigador(int posicion)
    {
        AlmacenDatos almacen = obtenerDatosFichero();

        HashSet<Investigador> i1 = almacen.getListaInvestigadores();
        int vuelta = 0;
        foreach (Investigador i in i1)
        {
            if (vuelta == posicion)
            {
                return i;
            }
            else
            {
                vuelta++;
            }
        }
        return null;
    }

    //Este metodo devuelve el objeto por posicion en el Fichero.dat del Almacen de Datos
    public Objetos ObtenerObjeto(int posicion)
    {
        AlmacenDatos almacen = obtenerDatosFichero();
        HashSet<Objetos> o1 = almacen.getListaObjetos();

        int vuelta = 0;
        foreach (Objetos o in o1)
        {
            if (vuelta == posicion)
            {
                return o;
            }
            else
            {
                vuelta++;
            }
        }
        return null;
    }

    //Este metodo devuelve el objeto por posicion en el Fichero.dat del Investigador Jugable
    public Objetos ObtenerObjetoDeInventario(int posicion)
    {
        JugadorEnPartida inventario = obtenerDatosInvestigadorJugable();
        HashSet<Objetos> o1 = inventario.getListaObjetos();

        int vuelta = 0;
        foreach (Objetos o in o1)
        {
            if (vuelta == posicion)
            {
                return o;
            }
            else
            {
                vuelta++;
            }
        }
        return null;
    }

    //Este metodo devuelve el tamaño maximo de los investigadores guardados en el Fichero.dat del Almacen de Datos
    public int ObtenerTamañoMaximoAlmacenInvestigadores()
    {

        AlmacenDatos almacen = obtenerDatosFichero();
        HashSet<Investigador> i1 = almacen.getListaInvestigadores();

        return i1.Count;
    }

    //Este metodo devuelve el tamaño maximo de los objetos guardados en el Fichero.dat del Almacen de Datos
    public int ObtenerTamañoMaximoAlmacenObjetos()
    {

        AlmacenDatos almacen = obtenerDatosFichero();
        HashSet<Objetos> o1 = almacen.getListaObjetos();

        return o1.Count;
    }

    //Este metodo devuelve el tamaño maximo de los objetos guardados en el Fichero.dat del Investigador Jugable
    public int ObtenerTamañoMaximoInventarioJugador()
    {
        JugadorEnPartida jugador = obtenerDatosInvestigadorJugable();
        HashSet<Objetos> o1 = jugador.getListaObjetos();
        return o1.Count;
    }

}

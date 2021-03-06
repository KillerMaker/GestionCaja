﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCaja.Entidades
{
    //Clase abstracta padre de CEmpleado y CEstudiante
    public abstract class CPersona
    {
        /*Campo nullable int, el cual tendra un valor distinto de null unicamente al momento de actualizar
         Cuando se tenga que instanciar el objeto de tipo CPersona oldPersona*/
        public int? id { get; protected set; }
        
        //Atributos de Persona.
        public readonly string nombre;
        public readonly string fecha;
        public readonly string genero;
        public readonly string cedula;
        public readonly bool cedulaValida;

        // Variable global estatica utilizada para comunicarce con la base de datos.
        static protected SqlDataManagement dataManagement;

        //Constructor de CPersona donde se inicializan los atributos de la misma.
        public CPersona(string nombre, string fecha,string genero,string cedula)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.genero = genero;
            this.cedula = cedula;

            if (validaCedula(cedula))
                cedulaValida = true;
            else
                cedulaValida = false;

        }

        //Metodo abstracto para Insertar CPersona's en la base de datos
        public abstract void Insertar();

        //Metodo abstracto para Eliminar CPersona's(modificar el campo estado a "Inactivo") en la base de datos.
        public abstract void Eliminar();

        /*Metodo estatico Actualizar el cual utiliza dos parametros de tipo CPersona oldPersona y newPersona
         oldPersona debera tomar los datos actuales de registro que se desea actualizar, mientras que new persona los nuevos*/ 
        public static void Actualizar(CPersona oldPersona, CPersona newPersona)
        {
            dataManagement = new SqlDataManagement();

            if(newPersona is CEmpleado)
                dataManagement.ExecuteCommand($"UPDATE PERSONA SET NOMBRE='{newPersona.nombre}',GENERO='{newPersona.genero}' FROM PERSONA P INNER JOIN EMPLEADO E ON E.ID_PERSONA=P.ID_PERSONA WHERE IDENTIFICADOR={oldPersona.id}");
            
            else if(newPersona is CEstudiante)
                dataManagement.ExecuteCommand($"UPDATE PERSONA SET NOMBRE='{newPersona.nombre}' ,GENERO='{newPersona.genero}' FROM PERSONA P INNER JOIN ESTUDIANTE E ON E.ID_PERSONA=P.ID_PERSONA WHERE IDENTIFICADOR={oldPersona.id}");

        }
        private bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };


            //if (pLongCed < 11 || pLongCed > 11 || vcCedula== "00000000000")
                if (pLongCed < 11 || pLongCed > 11 )
                    return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
    }
}

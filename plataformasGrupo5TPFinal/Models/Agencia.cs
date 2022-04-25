using System;
using System.Collections.Generic;
using System.Linq;

namespace plataformasGrupo5TPFinal.Models

{
    class Agencia
    {
        private List<Alojamiento> misAlojamientos;
        private int cantAlojamientos;

        public Agencia(int CantidadAlojamientos)
        {
            misAlojamientos = new List<Alojamiento>();
            cantAlojamientos = CantidadAlojamientos;
        }


        //reviso que no haya otro con el mismo código, si ya hay devuelvo false
        public bool insertarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
                if (a.igualCodigo(aloj))
                    return false;
            //si llegó hasta acá es porque no está ese código
            misAlojamientos.Add(aloj);
            return true;
        }
        //modifico el alojamiento cuando encuentra el mismo codigo
        public bool modificarAlojamiento(Alojamiento aloj)
        {
            foreach(Alojamiento a in misAlojamientos)
                if(misAlojamientos != null)
                    if(a.igualCodigo(aloj))       
                         return true;
            // si me retorna a falso es porque no encontro el codigo             
            return false;
        }
        // elimino el alojamiento cuando encuentra el mismo codigo que se ingresa
        public bool eliminarAlojamiento(int codAloj)
        {

            if (misAlojamientos == null)
            {
                return false;
            }
            else
            {
                foreach (Alojamiento a in misAlojamientos)
                {
                    if (a.codigo == codAloj)
                    {
                        misAlojamientos.Remove(a);
                        return true;
                    }
                }
                return false;
            }

        }

        public bool estaLlena() { return cantAlojamientos <= misAlojamientos.Count; }
        public bool HayAlojamientos() { return misAlojamientos.Count > 0; }

        public Agencia AlojamientosPorCantidadDePersonas(int cantPersonas)
        {
            Agencia salidaPersonas = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos) { 
                if (a.cantPersonas == cantPersonas)
                    salidaPersonas.insertarAlojamiento(a);
            }
            return salidaPersonas;              
        }

        //chequeo si el codigo esta o no, con metodo de tipo alojamiento, ya que reservas lo pide
        public Alojamiento estaCodigo(int codigoAlojamiento)
        {
            return this.getAlojamientos().Find(al => al.codigo == codigoAlojamiento);
        }

        public Agencia CiudadesDeAlojamientos(String ciudades)
        {
            Agencia ciudadesAlojs = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos) { 
                if (a.ciudad == ciudades)
                    ciudadesAlojs.insertarAlojamiento(a);
            }
            return ciudadesAlojs;
        }

        public Agencia MasEstrellas(int cant)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)
                if (a.estrellas >= cant)
                    Salida.insertarAlojamiento(a);
            return Salida;
        }

        public Agencia AlojamientosEntrePrecios(float precioMin, float precioMax)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)

                if (a is Cabaña)
                {
                    Cabaña c = (Cabaña)a;
                    if (c.precioDia >= precioMin && c.precioDia <= precioMax) { 
                        Salida.insertarAlojamiento(c);                      
                    }

                }
                else if(a is Hotel)
                {
                    Hotel h = (Hotel)a;
                    if (h.precioPorPersona >= precioMin && h.precioPorPersona <= precioMax) { 
                        Salida.insertarAlojamiento(h);
                    }
       
                }
            return Salida;
        }

        public int getCantidad() { return cantAlojamientos; }
        public void setCantidad(int CantAlojamientos) { cantAlojamientos = CantAlojamientos; }

        public List<Alojamiento> getAlojamientos()
        {
            return misAlojamientos.OrderBy(a => a.estrellas).ThenBy(a => a.cantPersonas).ThenBy(a => a.codigo).ToList();
        }
    }
}
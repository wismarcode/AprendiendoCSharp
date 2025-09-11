﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContactos
{
    public class Contacto
    {
        public int Id {get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion {  get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Telefono: {Telefono}, Correo: {Correo}, Dirección: {Direccion}";
        }
    }
}

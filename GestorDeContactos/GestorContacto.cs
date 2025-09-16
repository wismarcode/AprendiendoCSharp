using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDeContactos
{
    public class GestorContacto
    {
        private List<Contacto> _contactos;
        private string _archivo = "contactos.json";



        public void Agregar(Contacto nuevoContacto)
        {


            if (!File.Exists(_archivo))
            {
                _contactos = new List<Contacto>();

            }
            else
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);

            }

            nuevoContacto.Id = _contactos.Count > 0 ? _contactos.Max(t => t.Id) + 1 : 1;
            _contactos.Add(nuevoContacto);

            var contactoJson = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_archivo, contactoJson);


        }

        public List<Contacto> Obtener()
        {
            if (!File.Exists(_archivo))
            {
                _contactos = new List<Contacto>();
            }
            else
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);

            }

            return _contactos;
        }

        public void Editar(Contacto contacto, Contacto cambios)
        {
            contacto.Nombre = cambios.Nombre;
            contacto.Telefono = cambios.Telefono;
            contacto.Correo = cambios.Correo;
            contacto.Direccion = cambios.Direccion;

            var json = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_archivo, json);

        }

        public void Eliminar(Contacto contacto)
        {
            _contactos.Remove(contacto);
            var json = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_archivo, json);
        }

        public Contacto ObtenerPorId(int id)
        {
            if (File.Exists(_archivo))
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);

                return _contactos.Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                File.Create(_archivo);
                return null;
            }


        }

        public Contacto ObtenerPorNombre(string nombre)
        {
            if (File.Exists(_archivo))
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);

            }
            else
            {
                File.Create(_archivo);
                return null;
            }

            return _contactos.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())).FirstOrDefault();


        }


        public Contacto ObtenerPorTelefono(string telefono)
        {
            if (File.Exists(_archivo))
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);
            }
            else
            {
                File.Create(_archivo);
                return null;
            }
            return _contactos.Where(c => c.Telefono.Contains(telefono)).FirstOrDefault();



        }
    }
}

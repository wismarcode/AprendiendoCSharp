using System;
using System.Collections;
using System.Collections.Generic;
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

        public void Editar(int id, Contacto contacto)
        {
            var obtenerContacto = ObtenerPorId(id);

            if (obtenerContacto != null)
            {
                obtenerContacto.Nombre = contacto.Nombre;
                obtenerContacto.Telefono = contacto.Telefono;
                obtenerContacto.Correo = contacto.Correo;
                obtenerContacto.Direccion = contacto.Direccion;

                var json = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_archivo, json);
            } 
            else
            {
                Console.WriteLine("No se encontro el contacto");
            }

        }

        public void Eliminar(int id)
        {
            var obtenerContacto = ObtenerPorId(id);

            if (obtenerContacto != null)
            {
                _contactos.Remove(obtenerContacto);
                var json = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions {WriteIndented = true});
                File.WriteAllText(_archivo, json);
            }
            else
            {
                Console.WriteLine("No se encontro el contacto");
            }
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


    }
}

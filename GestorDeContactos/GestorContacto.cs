using System;
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
        private string _archivo;

        public GestorContacto(string archivo)
        {
            _archivo = archivo;
            _contactos = new List<Contacto>();
        }

        public void Agregar(Contacto nuevoContacto)
        {


            if (File.Exists(_archivo))
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);
                _contactos.Add(nuevoContacto);


                var contactoJson = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions {WriteIndented = true});
                File.WriteAllText(_archivo, contactoJson);
            }
            else
            {
                var contactoJson = JsonSerializer.Serialize(_contactos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_archivo, contactoJson);
            }

        }

        public List<Contacto> Obtener()
        {
            if (File.Exists(_archivo))
            {
                string json = File.ReadAllText(_archivo);
                _contactos = JsonSerializer.Deserialize<List<Contacto>>(json);
                return _contactos;
            }
            else
            {
                File.Create(_archivo);
                return _contactos;
            }
        }

        public void Editar(int id,  Contacto contacto)
        {

        }

        public void Eliminar(int id)
        {

        }

        public Contacto ObtenerPorId(int id)
        {
            return null;
        }


    }
}

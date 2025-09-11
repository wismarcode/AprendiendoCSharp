using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContactos
{
    public class Validaciones
    {
        public string PedirTexto(string mensaje, int min, int max)
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(texto) || texto.Length > max || texto.Length < min)
            {
                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("Debes colocar algo en este campo.");
                    Console.WriteLine(mensaje);
                    texto = Console.ReadLine();
                }
                else if (texto.Length > max || texto.Length < min)
                {
                    Console.WriteLine("El contenido de este campo debe");
                    Console.WriteLine(mensaje);
                    texto = Console.ReadLine();
                }
            }

            return texto;
        }

        public int PedirId(string mensaje)
        {
            int id = 0;
            try
            {
                Console.WriteLine(mensaje);
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se puede colocar números enteros.");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error.");
            }

            return id;
            
        }

        public string PedirCorreo(string mensaje)
        {

            Console.WriteLine("Este campo es opcional ¿Quieres agregarlo?");
            Console.WriteLine("Presiona enter para no colocar el correo.");
            Console.WriteLine("Escribe cualquier cosas si lo quieres poner.");
            string opcion = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(opcion))
            {
                Console.WriteLine(mensaje);
                string correo = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(opcion) || !correo.EndsWith("@gmail.com") && !correo.EndsWith("@hotmail.com"))
                {
                    if (string.IsNullOrWhiteSpace(opcion))
                    {
                        Console.WriteLine("Debes colocar el correo.");
                        Console.WriteLine(mensaje);
                        correo = Console.ReadLine();
                    }
                    else if(!correo.EndsWith("@gmail.com") || !correo.EndsWith("@hotmail.com"))
                    {
                        Console.WriteLine("El correo al final debe tener @gmail.com o @hotmail.com");
                        Console.WriteLine(mensaje);
                        correo = Console.ReadLine();
                    }
                }

                return correo;
            } 
            else
            {
                return "";
            }

        }


        public string PedirDireccion(string mensaje, int min, int max)
        {
            Console.WriteLine("Este campo es opcional ¿Quieres agregarlo?");
            Console.WriteLine("Presiona enter para no colocar el correo.");
            Console.WriteLine("Escribe cualquier cosas si lo quieres poner.");
            string opcion = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(opcion))
            {
                Console.WriteLine(mensaje);
                string texto = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(texto) || texto.Length > max || texto.Length < min)
                {
                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        Console.WriteLine("Debes colocar algo en este campo.");
                        Console.WriteLine(mensaje);
                        texto = Console.ReadLine();
                    }
                    else if (texto.Length > max || texto.Length < min)
                    {
                        Console.WriteLine("El contenido de este campo debe");
                        Console.WriteLine(mensaje);
                        texto = Console.ReadLine();
                    }
                }

                return texto;
            }
            else
            {
                return "";
            }

             
        }



    }
}

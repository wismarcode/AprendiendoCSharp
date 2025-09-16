namespace GestorDeContactos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorContacto gestor = new GestorContacto();
            Validaciones validacion = new Validaciones();

            bool centinela = true;

            while (centinela)
            {
                Menu();

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarContacto(gestor, validacion);
                        break;
                    case 2:
                        ListarContactos(gestor);
                        break;
                    case 3:
                        EditarContacto(gestor, validacion);
                        break;
                    case 4:
                        EliminarContacto(gestor, validacion);
                        break;
                    case 5:
                        Console.WriteLine("Saliste del programa.");
                        centinela = false;
                        break;
                    default:
                        Console.WriteLine("Debes elegir una de las opciones.");
                        break;
                }
            }

        }

        static void Menu()
        {
            Console.WriteLine("=============== Menú ===============");
            Console.WriteLine("1. Para agregar un nuevo contacto.");
            Console.WriteLine("2. Para ver la lista de contactos,");
            Console.WriteLine("3. Para editar un contacto.");
            Console.WriteLine("4. Para eliminar un contacto.");
            Console.WriteLine("5. Para salir del programa.");
            Console.WriteLine("=====================================");
            Console.WriteLine("");
            Console.WriteLine("Elige una de las opciones:");
        }

        static void AgregarContacto(GestorContacto gestor, Validaciones validacion)
        {
            Console.WriteLine("Datos para crear el contacto:\n");

            string nombre = validacion.PedirTexto("Coloca el nombre del contacto:", 3, 60);
            string telefono = validacion.PedirTexto("Coloca el número del contacto:", 10, 10);
            string? correo = validacion.PedirCorreo("Coloca el correo electrónico:");
            string? direccion = validacion.PedirDireccion("Coloca la dirección:", 10, 150);

            var contacto = new Contacto() 
            {
                Nombre = nombre,
                Telefono = telefono,
                Correo = correo,
                Direccion = direccion
            };

            gestor.Agregar(contacto);


        }

        static void ListarContactos(GestorContacto gestor)
        {
            var listaContactos = gestor.Obtener();

            foreach (var lista in listaContactos)
            {
                Console.WriteLine(lista);
            }

        }

        static void EditarContacto(GestorContacto gestor, Validaciones validacion)
        {
            Console.WriteLine("Lista de contactos:");
            ListarContactos(gestor);

            int id = validacion.PedirId("Colocar el id del contacto a editar:");
            var encontrarContacto = gestor.ObtenerPorId(id);

            if (encontrarContacto != null)
            {
                Console.WriteLine("\n--- Editar Contacto ---");


                Console.Write($"Nombre ({encontrarContacto.Nombre}): ");
                string inputNombre = Console.ReadLine();
                string nombre = string.IsNullOrWhiteSpace(inputNombre)
                                ? encontrarContacto.Nombre
                                : validacion.PedirTexto("Coloca el nombre del contacto:", 3, 60);

                Console.Write($"Teléfono ({encontrarContacto.Telefono}): ");
                string inputTelefono = Console.ReadLine();
                string telefono = string.IsNullOrWhiteSpace(inputTelefono)
                                ? encontrarContacto.Telefono
                                : validacion.PedirTexto("Coloca el número del contacto:", 10, 10);


                Console.Write($"Correo ({encontrarContacto.Correo}): ");
                string inputCorreo = Console.ReadLine();
                string correo = string.IsNullOrWhiteSpace(inputCorreo)
                                ? encontrarContacto.Correo
                                : validacion.PedirCorreo("Coloca el correo electrónico:");


                Console.Write($"Dirección ({encontrarContacto.Direccion}): ");
                string inputDireccion = Console.ReadLine();
                string direccion = string.IsNullOrWhiteSpace(inputDireccion)
                                ? encontrarContacto.Direccion
                                : validacion.PedirDireccion("Coloca la dirección:", 10, 150);

                var contacto = new Contacto()
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    Correo = correo,
                    Direccion = direccion
                };

                gestor.Editar(encontrarContacto, contacto);
            }
            else
            {
                Console.WriteLine("No se encontró el contacto.");
            }

        }

        static void EliminarContacto(GestorContacto gestor, Validaciones validacion)
        {
            Console.WriteLine("Lista de contactos:");
            ListarContactos(gestor);

            int id = validacion.PedirId("Colocar el id del contacto a eliminar:");

            var encontrarContacto = gestor.ObtenerPorId(id);

            if (encontrarContacto != null)
            {
                gestor.Eliminar(encontrarContacto);
            }
            else
            {
                Console.WriteLine("No se encontro");
            }


        }

    }
}

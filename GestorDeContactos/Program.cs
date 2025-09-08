namespace GestorDeContactos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorContacto gestor = new GestorContacto();

            bool centinela = true;

            while (centinela)
            {
                Menu();

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarContacto(gestor);
                        break;
                    case 2:
                        ListarContactos(gestor);
                        break;
                    case 3:
                        EditarContacto(gestor);
                        break;
                    case 4:
                        EliminarContacto(gestor);
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

        static void AgregarContacto(GestorContacto gestor)
        {
            Console.WriteLine("Datos para crear el contacto:\n");

            Console.WriteLine("Coloca el nombre del contacto:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Colocar el número de telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Coloca el correo electrónico:");
            string correo = Console.ReadLine();
            Console.WriteLine("Coloca la dirección:");
            Console.WriteLine("Esta parte es opcional, presiona enter si no lo vas a poner.");
            string? direccion = Console.ReadLine();

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

        static void EditarContacto(GestorContacto gestor)
        {

        }

        static void EliminarContacto(GestorContacto gestor)
        {

        }

    }
}

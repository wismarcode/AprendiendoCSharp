namespace GestorDeContactos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorContacto gestor = new GestorContacto("Contactos.json");

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

        }

        static void ListarContactos(GestorContacto gestor)
        {

        }

        static void EditarContacto(GestorContacto gestor)
        {

        }

        static void EliminarContacto(GestorContacto gestor)
        {

        }

    }
}

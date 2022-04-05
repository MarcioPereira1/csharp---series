using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        //static int id = repositorio.ProximoId();

        static void Main(string[] args)
        {
            string op = Menu();
            while(op.ToUpper() != "X")
            {
                switch (op)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                            
                }
                op = Menu();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("\nListar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma séria cadastrada\n");
                return;
            }

            foreach(var serie in lista)
            {
                //Console.WriteLine($"#ID: {serie.Id}\nTìtulo: {serie.GetTitulo()}");
                Console.WriteLine("\n" + serie.ToString() + "\n");
            }
        }

        private static void InserirSerie()
        {
           
            Console.WriteLine("\nInserir Série\n");

            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine($"{Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o gênero dentre as opções acima:");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a decrição da série:");
            string descricao = Console.ReadLine();

            Serie serie = new Serie(repositorio.ProximoId(), (Genero) genero, titulo, descricao, ano);

            repositorio.Insere(serie);
        }

        private static void AtualizarSerie()
        {
            var lista = repositorio.Lista();
            Console.WriteLine("\nAtualiza Série\n");

            Console.WriteLine("Digite o ID da série que deseja atualizar:");
            int id = int.Parse(Console.ReadLine());

            foreach(var item in lista)
            {
                if(item.Id == id)
                {
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine($"{Enum.GetName(typeof(Genero), i)}");
                    }

                    Console.WriteLine("Digite o gênero dentre as opções acima:");
                    int genero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o título da série:");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Digite o ano da série:");
                    int ano = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a decrição da série:");
                    string descricao = Console.ReadLine();

                    Serie serie = new Serie(id, (Genero)genero, titulo, descricao, ano);

                    repositorio.Atualiza(id, serie);
                    Console.WriteLine("Série atualizada!");
                    break;
                } 
            }
             Console.WriteLine("Série inexistente.");
            
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("\nExcluir Sèrie\n");

            Console.WriteLine("Digite o ID da série que deseja excluir:");
            int id = int.Parse(Console.ReadLine());

            repositorio.Exclui(id);

            Console.WriteLine("Série excluída!\n");
        }

        private static string Menu()
        {
            Console.WriteLine("Insira a opção desejada: ");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            string op = Console.ReadLine().ToUpper();

            return op;
        }
    }
}

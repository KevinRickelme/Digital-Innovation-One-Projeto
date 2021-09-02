using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine(" --------------------------------------------------");
            Console.WriteLine("|                                                  |\n| Meu primeiro projeto na Digital Innovation One!  |\n| Me chamo Kevin e sou estudante de ADS na FATEC   |\n| Guarulhos! Estou muito feliz com o projeto.      |\n|                                                  |\n|          Este é um catálogo de séries.           |");
            Console.WriteLine(" --------------------------------------------------");

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario) {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluiSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Você digitou "+opcaoUsuario+". Opção inválida.");
                        break;

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        public static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");

                return;
            }

           

            foreach (var serie in lista)
            {
                    
                Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie.retornaTitulo());

            }
        }

        public static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite uma descrição para a série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaserie = new Series(Id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                Titulo: entradaTitulo,
                Ano: entradaAno,
                Descricao: entradaDescricao);
            repositorio.Insere(novaserie);
            

        }

        public static void AtualizarSeries()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            try
            {
                try
                {
                    var serie = repositorio.RetornoPorId(indiceSerie);
                }
                catch(Exception err)
                {
                    Console.WriteLine("ID não encontrado.\n");
                    Console.WriteLine(err.Message);
                    return;
                }
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite uma descrição para a série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(Id: indiceSerie,
                genero: (Genero)entradaGenero,
                Titulo: entradaTitulo,
                Ano: entradaAno,
                Descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie,atualizaSerie);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }


        }

        public static void ExcluiSeries()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            try { 
            repositorio.Exclui(indiceSerie);
            }
            catch (Exception err)
            {
                Console.WriteLine("ID não encontrado.\n");
                Console.WriteLine("Erro: "+err.Message);
            }


        }

        public static void VisualizarSeries()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            try { 
            var serie = repositorio.RetornoPorId(indiceSerie);

            Console.WriteLine(serie);
            }
            catch (Exception err)
            {
                Console.WriteLine("ID não encontrado.\n");
                Console.WriteLine(err.Message);
                Console.WriteLine();

            }


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}

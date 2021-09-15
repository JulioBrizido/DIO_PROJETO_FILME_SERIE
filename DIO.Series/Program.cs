using System;

namespace DIO.Series
{
    class Program
    {
        static FilmeSerieRepositorio repositorio = new FilmeSerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "0":
						Listar();
						break;
					case "1":
						Inserir(true);
						break;
					case "2":
						Atualizar(true);
						break;
					case "3":
						Excluir(true);
						break;
					case "4":
						Visualizar(true);
						break;
					case "5":
						Inserir(false);
						break;
					case "6":
						Atualizar(false);
						break;
					case "7":
						Excluir(false);
						break;
					case "8":
						Visualizar(false);
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluir(bool tipo)
		{
			Console.Write("Digite o id {0}: ", (tipo ? "da série" : "do filmes"));
			int indice = int.Parse(Console.ReadLine());

			repositorio.Excluir(indice);
		}

        private static void Visualizar(bool tipo)
		{
			Console.Write("Digite o id {0}: ", (tipo ? "da série" : "do filmes"));
			int indice = int.Parse(Console.ReadLine());

			var filmeSerie = repositorio.RetornaPorId(indice);

			Console.WriteLine(filmeSerie);
		}

        private static void Atualizar(bool tipo)
		{
			Console.Write("Digite o id {0}: ", (tipo ? "da série" : "do filmes"));
			int indice = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie atualiza = new FilmeSerie(id: indice,
						  			   genero: (Genero)entradaGenero,
									   titulo: entradaTitulo,
									   ano: entradaAno,
									   descricao: entradaDescricao,
									   tipo: (tipo ? "Série" : "Filme"));

			repositorio.Atualizar(indice, atualiza);
		}

        private static void Listar()
		{
			Console.WriteLine("Listar filmes e séries");		
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme ou série cadastrado");
				return;
			}

			foreach (var filmeSerie in lista)
			{
                var excluido = filmeSerie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filmeSerie.retornaId(), filmeSerie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserir(bool tipo)
		{
			Console.WriteLine("Inserir {0}", (tipo ? "nova série" : "novo filme"));

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			FilmeSerie novo = new FilmeSerie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
									    tipo: (tipo ? "Série" : "Filme"));

			repositorio.Inserir(novo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("0- Listar filmes e séries");
			Console.WriteLine("1- Inserir nova série");
			Console.WriteLine("2- Atualizar série");
			Console.WriteLine("3- Excluir série");
			Console.WriteLine("4- Visualizar série");

			Console.WriteLine("5- Inserir novo filme");
			Console.WriteLine("6- Atualizar filme");
			Console.WriteLine("7- Excluir filme");
			Console.WriteLine("8- Visualizar filme");

			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}


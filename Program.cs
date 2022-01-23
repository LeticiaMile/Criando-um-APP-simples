using System;

namespace DIO.Doramas
{
    class Program
    {
        static DoramaRepositorio repositorio = new DoramaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarDoramas();
						break;
					case "2":
						InserirDorama();
						break;
					case "3":
						AtualizarDorama();
						break;
					case "4":
						ExcluirDorama();
						break;
					case "5":
						VisualizarDorama();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Sayonara, Obrigado por utilizar nossos serviços.");
			Console.ReadLine();                  
        }


        private static void ExcluirDorama()
		{
			Console.Write("Digite o id do dorama: ");
			int indiceDorama = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceDorama);
		}

        private static void VisualizarDorama()
		{
			Console.Write("Digite o id do dorama: ");
			int indiceDorama = int.Parse(Console.ReadLine());

			var dorama = repositorio.RetornaPorId(indiceDorama);

			Console.WriteLine(dorama);
		}

        private static void AtualizarDorama()
		{
			Console.Write("Digite o id da série: ");
			int indiceDorama = int.Parse(Console.ReadLine());

		
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Dorama: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Dorama: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Dorama: ");
			string entradaDescricao = Console.ReadLine();

			Dorama atualizaDorama = new Dorama(id: indiceDorama,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceDorama, atualizaDorama);
		}
        private static void ListarDoramas()
		{
			Console.WriteLine("Listar doramas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma dorama cadastrado.");
				return;
			}

			foreach (var dorama in lista)
			{
                var excluido = dorama.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", dorama.retornaId(), dorama.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirDorama()
		{
			Console.WriteLine("Inserir novo dorama");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Dorama: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Dorama: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Dorama: ");
			string entradaDescricao = Console.ReadLine();

			Dorama novaDorama = new Dorama(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaDorama);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Sejam bem-vindo ao DramaPlay!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar dorama");
			Console.WriteLine("2- Inserir novo dorama");
			Console.WriteLine("3- Atualizar dorama");
			Console.WriteLine("4- Excluir dorama");
			Console.WriteLine("5- Visualizar dorama");
			Console.WriteLine("C- Limpar dorama");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

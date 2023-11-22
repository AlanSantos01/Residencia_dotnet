class Program{
    static void Main()
    {
        GerenciadorTarefas gerenciador = new GerenciadorTarefas();

        while (true)
        {
            MostrarMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    gerenciador.CriarTarefa();
                    break;
                case "2":
                    gerenciador.VisualizarTarefas();
                    break;
                case "3":
                    gerenciador.EditarTarefa();
                    break;
                case "4":
                    gerenciador.ExcluirTarefa();
                    break;
                case "5":
                    gerenciador.MarcarComoConcluida();
                    break;
                case "6":
                    gerenciador.PesquisarTarefas();
                    break;
                case "7":
                    gerenciador.ExibirEstatisticas();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("===== Sistema de Gerenciamento de Tarefas =====");
        Console.WriteLine("1. Criar Tarefa");
        Console.WriteLine("2. Visualizar Tarefas");
        Console.WriteLine("3. Editar Tarefa");
        Console.WriteLine("4. Excluir Tarefa");
        Console.WriteLine("5. Marcar Tarefa como Concluída");
        Console.WriteLine("6. Pesquisar Tarefas");
        Console.WriteLine("7. Exibir Estatísticas");
        Console.WriteLine("8. Sair");
        Console.Write("Escolha uma opção: ");
    }
}

class GerenciadorTarefas
{
    private List<Tarefa> listaDeTarefas;

    public GerenciadorTarefas()
    {
        listaDeTarefas = new List<Tarefa>();
    }

    public void CriarTarefa()
    {
        Console.Write("Digite o título da tarefa: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite a data de vencimento da tarefa (formato DD/MM/AAAA): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            Tarefa novaTarefa = new Tarefa(titulo, descricao, dataVencimento);
            listaDeTarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido.");
        }
    }

    public void VisualizarTarefas()
    {
        Console.WriteLine("===== Lista de Tarefas =====");

        if (listaDeTarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }
        else
        {
            for (int i = 0; i < listaDeTarefas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listaDeTarefas[i].Titulo} - Vencimento: {listaDeTarefas[i].DataVencimento.ToShortDateString()} - Concluída: {listaDeTarefas[i].Concluida}");
            }
        }
    }

    public void EditarTarefa()
    {
        VisualizarTarefas();

        Console.Write("Digite o número da tarefa que deseja editar: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= listaDeTarefas.Count)
        {
            Console.Write("Digite o novo título da tarefa: ");
            string novoTitulo = Console.ReadLine();

            Console.Write("Digite a nova descrição da tarefa: ");
            string novaDescricao = Console.ReadLine();

            Console.Write("Digite a nova data de vencimento da tarefa (formato DD/MM/AAAA): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime novaDataVencimento))
            {
                listaDeTarefas[indice - 1].Titulo = novoTitulo;
                listaDeTarefas[indice - 1].Descricao = novaDescricao;
                listaDeTarefas[indice - 1].DataVencimento = novaDataVencimento;

                Console.WriteLine("Tarefa editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Formato de data inválido.");
            }
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void ExcluirTarefa()
    {
        VisualizarTarefas();

        Console.Write("Digite o número da tarefa que deseja excluir: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= listaDeTarefas.Count)
        {
            listaDeTarefas.RemoveAt(indice - 1);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void MarcarComoConcluida()
    {
        VisualizarTarefas();

        Console.Write("Digite o número da tarefa que deseja marcar como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= listaDeTarefas.Count)
        {
            listaDeTarefas[indice - 1].Concluida = true;
            Console.WriteLine("Tarefa marcada como concluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void PesquisarTarefas()
    {
        Console.Write("Digite a palavra-chave para a pesquisa: ");
        string palavraChave = Console.ReadLine().ToLower();

        var tarefasEncontradas = listaDeTarefas
            .Where(t => t.Titulo.ToLower().Contains(palavraChave) || t.Descricao.ToLower().Contains(palavraChave))
            .ToList();

        if (tarefasEncontradas.Count == 0)
        {
            Console.WriteLine($"Nenhuma tarefa encontrada com a palavra-chave '{palavraChave}'.");
        }
        else
        {
            Console.WriteLine($"===== Tarefas Encontradas com a Palavra-Chave '{palavraChave}' =====");
            for (int i = 0; i < tarefasEncontradas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefasEncontradas[i].Titulo} - Vencimento: {tarefasEncontradas[i].DataVencimento.ToShortDateString()} - Concluída: {tarefasEncontradas[i].Concluida}");
            }
        }
    }

    public void ExibirEstatisticas()
    {
        int tarefasConcluidas = listaDeTarefas.Count(t => t.Concluida);
        int tarefasPendentes = listaDeTarefas.Count(t => !t.Concluida);

        Console.WriteLine($"Número de Tarefas Concluídas: {tarefasConcluidas}");
        Console.WriteLine($"Número de Tarefas Pendentes: {tarefasPendentes}");

        if (tarefasConcluidas > 0)
        {
            var tarefaMaisAntigaConcluida = listaDeTarefas.Where(t => t.Concluida).Min(t => t.DataVencimento);
            var tarefaMaisRecenteConcluida = listaDeTarefas.Where(t => t.Concluida).Max(t => t.DataVencimento);

            Console.WriteLine($"Tarefa Concluída mais Antiga: {tarefaMaisAntigaConcluida.ToShortDateString()}");
            Console.WriteLine($"Tarefa Concluída mais Recente: {tarefaMaisRecenteConcluida.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine("Não há tarefas concluídas para exibir estatísticas de datas.");
        }
    }
}

class Tarefa
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(string titulo, string descricao, DateTime dataVencimento)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataVencimento = dataVencimento;
        Concluida = false;
    }
}

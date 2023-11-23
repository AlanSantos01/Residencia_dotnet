#region tupla

    var pessoa1 = CriarTupla("Alice", 25);
    var pessoa2 = CriarTupla("Bob", 30);

    ExibirResultado(pessoa1);
    ExibirResultado(pessoa2);

    static (string Nome, int Idade) CriarTupla(string nome, int idade)
    {
        // Retorna uma tupla contendo o nome e a idade
        return (nome, idade);
    }

    static void ExibirResultado((string Nome, int Idade) pessoa)
    {
        // Exibe os resultados
        Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}");
    }
#endregion
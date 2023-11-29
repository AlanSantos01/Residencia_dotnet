using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static (string Codigo, string Nome, int Quantidade, double PrecoUnitario) CriarProduto(string codigo, string nome, int quantidade, double precoUnitario)
    {
        return (Codigo: codigo, Nome: nome, Quantidade: quantidade, PrecoUnitario: precoUnitario);
    }

    static void Main()
    {
        var estoque = new List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)>
        {
            CriarProduto("P001", "Produto A", 10, 19.99),
            CriarProduto("P002", "Produto B", 5, 15.0),
            CriarProduto("P003", "Produto C", 8, 30.0)
        };

        Console.WriteLine("Sistema de Gerenciamento de Estoque");

        while (true)
        {
            Console.WriteLine("\n1 - Mostrar Estoque");
            Console.WriteLine("2 - Adicionar Produto");
            Console.WriteLine("3 - Vender Produto");
            Console.WriteLine("4 - Buscar Produto por Código");
            Console.WriteLine("5 - Atualizar Quantidade em Estoque");
            Console.WriteLine("6 - Relatório: Produtos com Quantidade Abaixo do Limite");
            Console.WriteLine("7 - Relatório: Produtos com Valor entre Mínimo e Máximo");
            Console.WriteLine("8 - Relatório: Valor Total do Estoque e de Cada Produto");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MostrarEstoque(estoque);
                    break;

                case "2":
                    AdicionarProduto(estoque);
                    break;

                case "3":
                    VenderProduto(estoque);
                    break;

                case "4":
                    BuscarProdutoPorCodigo(estoque);
                    break;

                case "5":
                    AtualizarQuantidadeEmEstoque(estoque);
                    break;

                case "6":
                    RelatorioQuantidadeAbaixoDoLimite(estoque);
                    break;

                case "7":
                    RelatorioValorEntreMinMax(estoque);
                    break;

                case "8":
                    RelatorioValorTotalEstoque(estoque);
                    break;

                case "0":
                    Console.WriteLine("Saindo do sistema. Até mais!");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void MostrarEstoque(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.WriteLine("\nEstoque Atual:");

        foreach (var produto in estoque)
        {
            Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Quantidade: {produto.Quantidade} - Preço: {produto.PrecoUnitario:C}");
        }
    }

    static void AdicionarProduto(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nCódigo do produto: ");
        string codigo = Console.ReadLine();

        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade: ");
        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
        {
            Console.Write("Preço Unitário: ");
            if (double.TryParse(Console.ReadLine(), out double precoUnitario) && precoUnitario > 0)
            {
                AdicionarNovoProduto(estoque, codigo, nome, quantidade, precoUnitario);
                Console.WriteLine("Produto adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Preço inválido. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Quantidade inválida. Operação cancelada.");
        }
    }

    static void AdicionarNovoProduto(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque, string codigo, string nome, int quantidade, double precoUnitario)
    {
        estoque.Add(CriarProduto(codigo, nome, quantidade, precoUnitario));
    }

    static void VenderProduto(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nCódigo do produto para venda: ");
        string codigo = Console.ReadLine();

        var produto = estoque.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

        if (produto != default)
        {
            Console.Write("Quantidade para vender: ");
            if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0 && quantidade <= produto.Quantidade)
            {
                var index = estoque.IndexOf(produto);
                estoque[index] = CriarProduto(produto.Codigo, produto.Nome, produto.Quantidade - quantidade, produto.PrecoUnitario);

                double valorTotal = quantidade * produto.PrecoUnitario;
                Console.WriteLine($"Venda realizada com sucesso! Valor total: {valorTotal:C}");
            }
            else
            {
                Console.WriteLine("Quantidade inválida ou insuficiente. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque. Operação cancelada.");
        }
    }

    static void BuscarProdutoPorCodigo(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nDigite o código do produto: ");
        string codigo = Console.ReadLine();

        try
        {
            var produtoEncontrado = BuscarProduto(estoque, codigo);
            Console.WriteLine($"Produto encontrado: {produtoEncontrado.Nome} - Quantidade: {produtoEncontrado.Quantidade} - Preço: {produtoEncontrado.PrecoUnitario:C}");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static (string Codigo, string Nome, int Quantidade, double PrecoUnitario) BuscarProduto(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque, string codigo)
    {
        var produto = estoque.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

        if (produto != default)
        {
            return produto;
        }
        else
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado no estoque.");
        }
    }

    static void AtualizarQuantidadeEmEstoque(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nCódigo do produto para atualização: ");
        string codigo = Console.ReadLine();

        var produto = estoque.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

        if (produto != default)
        {
            Console.WriteLine($"Produto encontrado: {produto.Nome} - Quantidade atual: {produto.Quantidade}");

            Console.Write("Digite a quantidade a ser adicionada (caso positivo) ou removida (caso negativo): ");
            if (int.TryParse(Console.ReadLine(), out int quantidade))
            {
                AtualizarQuantidadeProduto(estoque, produto, quantidade);
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado no estoque. Operação cancelada.");
        }
    }

    static void AtualizarQuantidadeProduto(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque, (string Codigo, string Nome, int Quantidade, double PrecoUnitario) produto, int quantidade)
    {
        if (quantidade >= 0)
        {
            // Adiciona a quantidade ao estoque
            var index = estoque.IndexOf(produto);
            estoque[index] = CriarProduto(produto.Codigo, produto.Nome, produto.Quantidade + quantidade, produto.PrecoUnitario);

            Console.WriteLine($"Quantidade atualizada com sucesso! Nova quantidade: {estoque[index].Quantidade}");
        }
        else
        {
            // Verifica se há quantidade suficiente para remover
            if (Math.Abs(quantidade) <= produto.Quantidade)
            {
                // Remove a quantidade do estoque
                var index = estoque.IndexOf(produto);
                estoque[index] = CriarProduto(produto.Codigo, produto.Nome, produto.Quantidade + quantidade, produto.PrecoUnitario);

                Console.WriteLine($"Quantidade atualizada com sucesso! Nova quantidade: {estoque[index].Quantidade}");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente para remoção. Operação cancelada.");
            }
        }
    }

    static void RelatorioQuantidadeAbaixoDoLimite(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nInforme o limite de quantidade: ");
        if (int.TryParse(Console.ReadLine(), out int limite) && limite > 0)
        {
            var produtosAbaixoDoLimite = estoque.Where(p => p.Quantidade < limite);

            Console.WriteLine("\nProdutos com Quantidade Abaixo do Limite:");
            foreach (var produto in produtosAbaixoDoLimite)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Quantidade: {produto.Quantidade} - Preço: {produto.PrecoUnitario:C}");
            }
        }
        else
        {
            Console.WriteLine("Limite inválido. Operação cancelada.");
        }
    }

    static void RelatorioValorEntreMinMax(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        Console.Write("\nInforme o valor mínimo: ");
        if (double.TryParse(Console.ReadLine(), out double minimo))
        {
            Console.Write("Informe o valor máximo: ");
            if (double.TryParse(Console.ReadLine(), out double maximo) && maximo >= minimo)
            {
                var produtosNoIntervalo = estoque.Where(p => p.PrecoUnitario >= minimo && p.PrecoUnitario <= maximo);

                Console.WriteLine("\nProdutos com Valor entre Mínimo e Máximo:");
                foreach (var produto in produtosNoIntervalo)
                {
                    Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Quantidade: {produto.Quantidade} - Preço: {produto.PrecoUnitario:C}");
                }
            }
            else
            {
                Console.WriteLine("Valor máximo inválido. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Valor mínimo inválido. Operação cancelada.");
        }
    }

    static void RelatorioValorTotalEstoque(List<(string Codigo, string Nome, int Quantidade, double PrecoUnitario)> estoque)
    {
        double valorTotalEstoque = estoque.Sum(p => p.Quantidade * p.PrecoUnitario);

        Console.WriteLine($"\nValor Total do Estoque: {valorTotalEstoque:C}");

        Console.WriteLine("\nValor Total de Cada Produto:");
        foreach (var produto in estoque)
        {
            double valorTotalProduto = produto.Quantidade * produto.PrecoUnitario;
            Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Valor Total: {valorTotalProduto:C}");
        }
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message)
    {
    }
}

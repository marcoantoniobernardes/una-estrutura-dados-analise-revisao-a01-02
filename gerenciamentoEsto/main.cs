/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public long CodigoDeBarras { get; set; }
    public int QuantidadeDisponivel { get; set; }
    public decimal PrecoUnitario { get; set; }
    public DateTime DataDeValidade { get; set; }
}

class Program
{
    static List<Produto> estoque = new List<Produto>();

    static void Main()
    {
        while (true)// while swicht case para rodar o codigo a gosto do usuario
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Atualizar Produto");
            Console.WriteLine("3. Remover Produto");
            Console.WriteLine("4. Buscar Produto");
            Console.WriteLine("5. Calcular Valor Total do Estoque");
            Console.WriteLine("6. Gerar Relatório de Produtos Próximos ao Vencimento");
            Console.WriteLine("7. Sair");
            
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    AdicionarProduto();
                    break;
                case 2:
                    AtualizarProduto();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    BuscarProduto();
                    break;
                case 5:
                    CalcularValorTotalEstoque();
                    break;
                case 6:
                    GerarRelatorioVencimento();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
    // adiciona prnovo produto
    static void AdicionarProduto()
    {
        Produto produto = new Produto();

        Console.Write("Nome do Produto: ");// nome produto
        produto.Nome = Console.ReadLine();

        Console.Write("Código de Barras: ");// codigo barra tratamento
        if (long.TryParse(Console.ReadLine(), out long codigo))
        {
            Produto produtoPorCodigo = estoque.Find(p => p.CodigoDeBarras == codigo);
            if (produtoPorCodigo != null)
            {
                MostrarProduto(produtoPorCodigo);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Código de Barras inválido. Tente novamente.");
        }

        Console.Write("Quantidade Disponível: ");// quantidade tratamento
        if (int.TryParse(Console.ReadLine(), out int quantidade))
        {
            if (quantidade >= 0)
            {
                produto.QuantidadeDisponivel = quantidade;
            }
            else
            {
                Console.WriteLine("A quantidade não pode ser negativa. O produto não será adicionado.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida para quantidade. O produto não será adicionado.");
            return;
        }

        Console.Write("Preço Unitário: ");// preco mais tratamento
        string precoUnitarioInput = Console.ReadLine();
        if (decimal.TryParse(precoUnitarioInput, out decimal precoUnitario))
        {
            if (precoUnitario >= 0)
            {
                produto.PrecoUnitario = precoUnitario;
            }
            else
            {
                Console.WriteLine("O preço unitário não pode ser negativo. O produto não será adicionado.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Preço unitário inválido. Certifique-se de inserir um número válido. O produto não será adicionado.");
            return;
        }

        Console.Write("Data de Validade (DD/MM/AAAA): ");// data mais tratamento
        string dataValidadeInput = Console.ReadLine();
        if (DateTime.TryParseExact(dataValidadeInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataValidade))
        {
            if (dataValidade >= DateTime.Now)
            {
                produto.DataDeValidade = dataValidade;
            }
            else
            {
                Console.WriteLine("A data de validade não pode estar no passado. O produto não será adicionado.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Data de validade inválida. Use o formato DD/MM/AAAA. O produto não será adicionado.");
            return;
        }

        estoque.Add(produto);
    }

    // atualiza produto
    static void AtualizarProduto()
    {
        Console.Write("Código de Barras do Produto a ser atualizado: ");//codigo de barra
        if (long.TryParse(Console.ReadLine(), out long codigo))
        {
            Produto produtoPorCodigo = estoque.Find(p => p.CodigoDeBarras == codigo);
            if (produtoPorCodigo != null)
            {
                MostrarProduto(produtoPorCodigo);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Código de Barras inválido. Tente novamente.");
        }

        Produto produto = estoque.Find(p => p.CodigoDeBarras == codigo);
        if (produto != null)
        {
            Console.Write("Novo Nome: ");//nome
            produto.Nome = Console.ReadLine();

            Console.Write("Nova Quantidade Disponível: ");//Quantidade
            if (int.TryParse(Console.ReadLine(), out int quantidade))
        {
            if (quantidade >= 0)
            {
                produto.QuantidadeDisponivel = quantidade;
            }
            else
            {
                Console.WriteLine("A quantidade não pode ser negativa. O produto não será adicionado.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida para quantidade. O produto não será adicionado.");
            return;
        }

            Console.Write("Novo Preço Unitário: ");//preco
            string precoUnitarioInput = Console.ReadLine();
            if (decimal.TryParse(precoUnitarioInput, out decimal precoUnitario))
            {
                if (precoUnitario >= 0)
                {
                    produto.PrecoUnitario = precoUnitario;
                }
                else
                {
                    Console.WriteLine("O preço unitário não pode ser negativo. O produto não será adicionado.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Preço unitário inválido. Certifique-se de inserir um número válido. O produto não será adicionado.");
                return;
            }

            Console.Write("Nova Data de Validade (DD/MM/AAAA): ");//data
            string dataValidadeInput = Console.ReadLine();
            if (DateTime.TryParseExact(dataValidadeInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataValidade))
            {
                if (dataValidade >= DateTime.Now)
                {
                    produto.DataDeValidade = dataValidade;
                }
                else
                {
                    Console.WriteLine("A data de validade não pode estar no passado. O produto não será adicionado.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Data de validade inválida. Use o formato DD/MM/AAAA. O produto não será adicionado.");
                return;
            }

            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    
    // Remover Produto
    static void RemoverProduto()
    {
        Console.Write("Código de Barras do Produto a ser removido: ");
        long codigo = long.Parse(Console.ReadLine());

        Produto produto = estoque.Find(p => p.CodigoDeBarras == codigo);
        if (produto != null)
        {
            estoque.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    
    //buscar Produto por nome codigo ou data de validade
    static void BuscarProduto()
    {
        Console.WriteLine("Escolha uma opção de busca:");
        Console.WriteLine("1. Por Nome");
        Console.WriteLine("2. Por Código de Barras");
        Console.WriteLine("3. Por Data de Validade");
        
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                Console.Write("Nome do Produto: ");
                string nome = Console.ReadLine();
                List<Produto> produtosPorNome = estoque.FindAll(p => p.Nome.Contains(nome));
                MostrarProdutos(produtosPorNome);
                break;
            case 2:
                Console.Write("Código de Barras: ");
                long codigo = long.Parse(Console.ReadLine());
                Produto produtoPorCodigo = estoque.Find(p => p.CodigoDeBarras == codigo);
                if (produtoPorCodigo != null)
                {
                    MostrarProduto(produtoPorCodigo);
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
                break;
            case 3:
                Console.Write("Data de Validade (DD/MM/AAAA): ");
                DateTime dataValidade = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                List<Produto> produtosPorDataValidade = estoque.FindAll(p => p.DataDeValidade == dataValidade);
                MostrarProdutos(produtosPorDataValidade);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    //calcular estoque
    static void CalcularValorTotalEstoque()
    {
        decimal valorTotal = 0;
        foreach (var produto in estoque)
        {
            valorTotal += produto.QuantidadeDisponivel * produto.PrecoUnitario;
        }
        Console.WriteLine($"Valor Total do Estoque: R${valorTotal:F2}");
    }
     //gerar relatorio
    static void GerarRelatorioVencimento()
    {
        Console.Write("Data de Referência para Vencimento (DD/MM/AAAA): ");
        DateTime dataReferencia = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        List<Produto> produtosProximosAoVencimento = estoque.FindAll(p => p.DataDeValidade <= dataReferencia);
        MostrarProdutos(produtosProximosAoVencimento);
    }

    //mostra produto
    static void MostrarProduto(Produto produto)
    {
        Console.WriteLine($"Nome: {produto.Nome}");
        Console.WriteLine($"Código de Barras: {produto.CodigoDeBarras}");
        Console.WriteLine($"Quantidade Disponível: {produto.QuantidadeDisponivel}");
        Console.WriteLine($"Preço Unitário: R${produto.PrecoUnitario:F2}");
        Console.WriteLine($"Data de Validade: {produto.DataDeValidade:dd/MM/yyyy}");
    }
    // mostrar produto
    static void MostrarProdutos(List<Produto> produtos)
    {
        foreach (var produto in produtos)
        {
            MostrarProduto(produto);
            Console.WriteLine();
        }
    }
}
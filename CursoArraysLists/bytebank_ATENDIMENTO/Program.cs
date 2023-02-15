using System.Collections;
using bytebank.Exceptions;
using bytebank.Modelos.Conta;
using bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");



#region Desafio
/* void Desafio()
{
    List<string> nomesDosEscolhidos = new List<string>()
    {
        "Bruce Wayne",
        "Carlos Vilagran",
        "Richard Grayson",
        "Bob Kane",
        "Will Farrel",
        "Lois Lane",
        "General Welling",
        "Perla Letícia",
        "Uxas",
        "Diana Prince",
        "Elisabeth Romanova",
        "Anakin Wayne"
    };
    bool EncontraParametroNaLista<T>(List<T> lista,T parametro)
    {
        foreach (var item in lista)
        {
            if(item.Equals(parametro)) return true;
        }
        return false;
    }

    if(EncontraParametroNaLista<string>(nomesDosEscolhidos,"Anakin Wayne"))
    {
        System.Console.WriteLine("Nome encontrado!");
    }
    if(!EncontraParametroNaLista<string>(nomesDosEscolhidos,"Anakin"))
    {
        System.Console.WriteLine("Nome não encontrado!");
    }
    
    
}

Desafio(); */
#endregion

void AtendimentoCliente()
{
    List<ContaCorrente> listaContas = new List<ContaCorrente>()
    {
        new ContaCorrente(323,"5679787-A"){Saldo = 200, Titular = new Cliente(){Cpf="00011122232",Nome="Josiane",Profissao="Dev"}},
        new ContaCorrente(322,"5679787-B"){Saldo = 300, Titular = new Cliente(){Cpf="00021122232",Nome="Jaja",Profissao="Dev"}},
        new ContaCorrente(321,"5679787-C"){Saldo = 400, Titular = new Cliente(){Cpf="00031122232",Nome="sebastian",Profissao="Dev"}}
    };
    char opcao = '0';
    try
    {
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===       Atendimento       ===");
            Console.WriteLine("===1 - Cadastrar Conta      ===");
            Console.WriteLine("===2 - Listar Contas        ===");
            Console.WriteLine("===3 - Remover Conta        ===");
            Console.WriteLine("===4 - Ordenar Contas       ===");
            Console.WriteLine("===5 - Pesquisar Conta      ===");
            Console.WriteLine("===6 - Sair do Sistema      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (System.Exception ex)
            {
                
                throw new ByteBankException(ex.Message);
            }
            
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarConta();
                    break;
                case '3':
                    RemoverConta();
                    break;
                 case '4':
                    OrdenarConta();
                    break;
                case '5':
                    PesquisarConta();
                    break;
                case '6':
                    System.Console.WriteLine("Finalizando Sistema........");;
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
    }
    catch(ByteBankException byteBankException)
    {
        System.Console.WriteLine($"{byteBankException.Message}");
    }
    catch (System.Exception ex)
    {
        
        System.Console.WriteLine($"{ex.Message}");
    }

    void PesquisarConta()
    {
        System.Console.WriteLine("Se deseja pesquisar por número da conta digite  1  Se deseja pesquisar por cpf digite 2");
        char opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1' :
                System.Console.Write("Digite o número da conta");
                string numeroConta = Console.ReadLine();
                var conta = PesquisaNumeroConta(numeroConta);
                if(conta != null)
                {
                System.Console.WriteLine($"Conta encontrada");
                System.Console.WriteLine(conta.ToString());
                }
                Console.ReadKey();
                break;
            case '2' :
                System.Console.Write("Digite o número do cpf");
                string cpf = Console.ReadLine();
                //PesquisaNumeroCpf(cpf);
                break;
            default:
                Console.WriteLine("Opcao não implementada.");
                break;
        }

        ContaCorrente PesquisaNumeroConta(string numeroConta)
        {
            return listaContas
            .Where(conta => conta.Conta == numeroConta)
            .FirstOrDefault();
        }
    }

    void OrdenarConta()
    {
        listaContas.Sort();
        System.Console.WriteLine("Contas ordenadas");
        Console.ReadKey();
    }
    
     void CadastrarConta()
    {
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Infome nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Infome CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Infome Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    listaContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
    }
    void ListarConta()
    {
        if(listaContas.Count <= 0)
        {
            System.Console.WriteLine("Não há contas cadastradas");
            Console.ReadKey();
            return;
        }
        foreach (var conta in listaContas)
        {
            /* System.Console.WriteLine($"Conta: {conta.Conta}");
            System.Console.WriteLine($"Agência: {conta.Numero_agencia}");
            System.Console.WriteLine($"Nome Titular: {conta.Titular.Nome}"); */
            System.Console.WriteLine(conta.ToString());
            Console.ReadKey();
        }
    }
    void RemoverConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");
        Console.Write("Número da conta: ");
        string numeroConta = Console.ReadLine();

        ContaCorrente contaCorrente = null;

        foreach (var conta in listaContas)
        {
            if(conta.Conta.Equals(numeroConta))
            {
                 contaCorrente = conta;
            }
        }

        if(contaCorrente != null)
        {
             listaContas.Remove(contaCorrente);
             System.Console.WriteLine("Conta Removida com sucesso");
        }

        if(contaCorrente == null) System.Console.WriteLine("Conta Não Encotrada");
        
        Console.ReadKey();
        
    }
}



AtendimentoCliente();





#region ExemplosArrayC#
void testaArrayContaCorrente()
{
    ContaCorrente ContaMaiorSaldo;

    listaDeContasCorrentes listaDeContas = new listaDeContasCorrentes();
    ContaCorrente contaA = new ContaCorrente(487,"5679787-A",100);
    listaDeContas.Adicionar(contaA);
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-B",150));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-C",100));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-D",50));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-E", 10));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-F", 1000));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-G", 10000));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-H", 2000));
    ContaCorrente contaI = new ContaCorrente(487,"5679787-I", 150);
    listaDeContas.Adicionar( contaI );
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-J",200));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-L",300));
    listaDeContas.Adicionar( new ContaCorrente(487,"5679787-N",400));
    listaDeContas.ExibeLista();
    ContaMaiorSaldo = listaDeContas.MaiorSaldo();
    Console.WriteLine($"A conta de maior saldo é {ContaMaiorSaldo.Conta} com Saldo de {ContaMaiorSaldo.Saldo}");
    
    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        System.Console.WriteLine($" A Conta {conta.Conta} no indice {i}");
    }
}
#endregion

//testaArrayContaCorrente();


/* using bytebank.Modelos.Conta;





//void TestaBuscarPalavras()
{
    string[] palavras = new string[5];

    for (int i = 0; i < palavras.Length; i++)
    {
        System.Console.Write($"Digite {i+1}° Palavra : ");
        palavras[i] = Console.ReadLine();
    }

    System.Console.Write("Digite Palavra a Ser Buscada : ");
    string palavraProcurada = Console.ReadLine();

    foreach (var palavra in palavras)
    {
        if(palavra.Equals(palavraProcurada))
        {
            System.Console.WriteLine($"Palavra {palavra} Encontrada");
            return;
        }
    }
    System.Console.WriteLine("Palavra Não Encontrada");

}

void Idades()
{
    int indice =0;
    int acumulador = 0;
    int[] idades = new int[5];

    idades[0] = 10;
    idades[1] = 20;
    idades[2] = 30;
    idades[3] = 40;
    idades[4] = 50;

    foreach (var idade in idades)
    {
        System.Console.WriteLine($"Indice{indice} = {idade}");
        indice++;
        acumulador+= idade;
    }

    System.Console.WriteLine($"Média de Idade {acumulador/idades.Length}");
}

/* Array amostra = Array.CreateInstance(typeof(double),5);

amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(6.9,4); 

void testaMediana(Array array)
{
    if(array == null || array.Length == 0) return;

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho/2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
    (numerosOrdenados[meio] +  numerosOrdenados[meio -1])/2;
}

void testaArrayContaCorrente()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(487,"5679787-A"),
        new ContaCorrente(487,"5679787-B"),
        new ContaCorrente(487,"5679787-C")
    };

    foreach (ContaCorrente conta in listaDeContas)
    {
        System.Console.WriteLine($"Conta : {conta.Conta}");
    }
}
 */
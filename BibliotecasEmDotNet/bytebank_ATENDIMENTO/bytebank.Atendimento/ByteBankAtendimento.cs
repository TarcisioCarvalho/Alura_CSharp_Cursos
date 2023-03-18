using bytebank.Exceptions;
using bytebank.Modelos.Conta;
using Newtonsoft.Json;

namespace bytebank.Atendimento;

public class ByteBankAtendimento
{
    private List<ContaCorrente> listaContas = new List<ContaCorrente>()
        {
            new ContaCorrente(323){Saldo = 200, Titular = new Cliente(){Cpf="00011122232",Nome="Josiane",Profissao="Dev"}},
            new ContaCorrente(322){Saldo = 300, Titular = new Cliente(){Cpf="00021122232",Nome="Jaja",Profissao="Dev"}},
            new ContaCorrente(321){Saldo = 400, Titular = new Cliente(){Cpf="00031122232",Nome="sebastian",Profissao="Dev"}}
        };

    public void AtendimentoCliente()
    { 
        char opcao = '0';
        try
        {
            while (opcao != '7')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Exportar Contas      ===");
                Console.WriteLine("===7 - Sair do Sistema      ===");
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
                        ExportarContas();
                        break;
                    case '7':
                        System.Console.WriteLine("Finalizando Sistema........"); 
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
    }

    public void ExportarContas()
    {
      
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     EXPORTAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (listaContas.Count <= 0)
            {
                Console.WriteLine("... Não existe dados para exportação...");
                Console.ReadKey();
                return;
            }
            string Json = JsonConvert.SerializeObject(listaContas, Formatting.Indented);
        try
        {
            FileStream fs = new FileStream(@"c:\tmp\export\contas.json",FileMode.Create);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(Json);
            }
            Console.WriteLine(@"Arquivo Salvo Com Sucesso em c:\tmp\export\");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            throw new ByteBankException(e.Message);
            Console.ReadKey();
        }
        
    }

    public void PesquisarConta()
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
    
    public  void CadastrarConta()
    {
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia);
    System.Console.WriteLine($"Nova conta [CONTA] : {conta.Conta}");
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
    public void ListarConta()
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
    public void RemoverConta()
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
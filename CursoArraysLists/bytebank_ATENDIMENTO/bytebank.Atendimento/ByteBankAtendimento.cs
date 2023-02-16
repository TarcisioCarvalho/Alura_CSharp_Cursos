using bytebank.Exceptions;
using bytebank.Modelos.Conta;

namespace bytebank.Atendimento;

public class ByteBankAtendimento
{
     List<ContaCorrente> listaContas = new List<ContaCorrente>()
        {
            new ContaCorrente(323,"5679787-A"){Saldo = 200, Titular = new Cliente(){Cpf="00011122232",Nome="Josiane",Profissao="Dev"}},
            new ContaCorrente(322,"5679787-B"){Saldo = 300, Titular = new Cliente(){Cpf="00021122232",Nome="Jaja",Profissao="Dev"}},
            new ContaCorrente(321,"5679787-C"){Saldo = 400, Titular = new Cliente(){Cpf="00031122232",Nome="sebastian",Profissao="Dev"}}
        };

    public void AtendimentoCliente()
    {

    
       
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
}
using bytebank.Modelos.Conta;

namespace bytebank.Util;

public class listaDeContasCorrentes
{
    private ContaCorrente[] _itens= null;
    private int _proximaPosicao = 0;

    public listaDeContasCorrentes(int inicial = 5)
    {
        _itens = new ContaCorrente[inicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        verificaCapacidade(_proximaPosicao + 1);
        System.Console.WriteLine($"Adicionando Item na Próxima Posição {_proximaPosicao}");
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }

    private void verificaCapacidade(int tamanhoNecessario)
    {
        if(_itens.Length >= tamanhoNecessario) return;

        System.Console.WriteLine("Aumentando a capacidade do Array");

        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }

    public ContaCorrente MaiorSaldo()
    {
        for (int i = 0; i < _itens; i++)
        {
            
        }
    }
}
using bytebank.Modelos.Conta;

namespace bytebank.Util;

public class listaDeContasCorrentes
{
    private ContaCorrente[] _itens= null;
    private int _proximaPosicao = 0;

    public int Tamanho { get
    {
        return _itens.Length;
    } }

    public listaDeContasCorrentes(int inicial = 5)
    {
        _itens = new ContaCorrente[inicial];
    }

    public void Adicionar(ContaCorrente item)
    {
        verificaCapacidade(_proximaPosicao + 1);
        Console.WriteLine($"Adicionando Item na Próxima Posição {_proximaPosicao}");
        Console.WriteLine($"Conta Adicionada {item.Conta} com o saldo de {item.Saldo}");
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }

    private void verificaCapacidade(int tamanhoNecessario)
    {
        if(_itens.Length >= tamanhoNecessario) return;

        Console.WriteLine("Aumentando a capacidade do Array");

        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }

    public ContaCorrente MaiorSaldo()
    {
        int indiceMaiorSaldo = 0;

        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[indiceMaiorSaldo].Saldo < _itens[i].Saldo) indiceMaiorSaldo = i;

        }

        return _itens[indiceMaiorSaldo];
    }

    public void RemoverConta(ContaCorrente conta)
    {
        int indiceContaRemover = 0;
        for (int i = 0; i < _itens.Length; i++)
        {
            if(conta == _itens[i]) break;
            indiceContaRemover++;
        }

        ContaCorrente[] novoArray = new ContaCorrente[_itens.Length - 1];
        for (int i = 0; i < novoArray.Length; i++)
        {
            if(i == indiceContaRemover) break;
            novoArray[i] = _itens[i];
        }
        for (int i = indiceContaRemover; i < novoArray.Length; i++)
        {
            novoArray[i] = _itens[i+1];
        }
        System.Console.WriteLine($"Conta com número de {_itens[indiceContaRemover].Conta} Removida");
        _itens = novoArray;
        
    }

    public void ExibeLista()
    {
        foreach (ContaCorrente conta in _itens)
        {
            System.Console.WriteLine($"Conta de número: {conta.Conta} Agência: {conta.Numero_agencia} e Saldo: {conta.Saldo} ");
        }
    }

    public ContaCorrente RecuperaIndiceItem(int indice)
    {
        if(indice < 0 || indice > _itens.Length) throw new ArgumentException(nameof(indice));

        return _itens[indice];
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperaIndiceItem(indice);
        }
    }

    

}
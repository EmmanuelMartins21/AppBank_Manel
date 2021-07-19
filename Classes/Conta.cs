using System;

namespace AppBank
{
    public class Conta
    {
        // Metodos
        public bool Sacar(double valorSaque)
        {
            //Confirma se há saldo o suficiente
            if(this.Saldo - valorSaque < (this.Saldo*-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo na conta de {0} é de R$ {1}", this.Nome, this.Saldo);
            return true;

        }

        public bool Depositar(double valor)
        {
            this.Saldo += valor;
            Console.WriteLine("Saldo na conta de {0} é de R$ {1}", this.Nome, this.Saldo);
            return true;

        }

        public bool Transferir(double valor, Conta contaDestinatario)
        {
            if(this.Sacar(valor))
            {
                contaDestinatario.Depositar(valor);
            }
            return true;
        }

        //Metodo de sobrescrever outro
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de conta "+this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            return retorno;
        }
        public Conta()
        {
        }

        //Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }
        // Atributos
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

       
    }
}
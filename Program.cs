using System;
using System.Collections.Generic;

namespace AppBank
{
    
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                       Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por acessar nosso sistema!!!");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valora ser depositado na conta");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valora ser sacado da conta");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valora ser transferido para conta: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia,listaContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("Digite 1 para Conta Pessoa Fisica ou 2 para pessoa Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome:entradaNome);
                        
            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas: ");
            Console.WriteLine();

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Não há conta cadastrada");
                return;
            }

            for(int i =0; i<listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem vindo ao Bank Manel!!!"); 
            Console.WriteLine("*******************************************************MENU DE OPÇÕES******************************************************"); 

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta"); 
            Console.WriteLine("3- Transferir"); 
            Console.WriteLine("4- Sacar"); 
            Console.WriteLine("5- Depositar"); 
            Console.WriteLine("C- Limpar tela"); 
            Console.WriteLine("X- Sair"); 
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}

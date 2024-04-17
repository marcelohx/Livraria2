using Livraria2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ControlCompra
    {
        Compra model;
        private int opcao;
        public ControlCompra()
        {
            model = new Compra();
            opcao = 0;
        }
        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }//Fim do ModificarOpcao
        public void Menu()
        {
            Console.WriteLine("Menu - Compra" +
                              "\nEscolha uma das Opções: " +
                              "\n1. Efetuar Compra" +
                              "\n2. Consultar Compra");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }

        public void Operacao()
        {
            Menu();
            switch (ModificarOpcao)
            {
                case 1:
                    Console.WriteLine("Digite o codigo da compra: ");
                    long codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o CPF: ");
                    long CPF = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Informe o codigo do livro: ");
                    long titulo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Digite a quantidade que deseja comprar: ");
                    int qtde = Convert.ToInt32(Console.ReadLine());
                    model.EfetuarCompra(codigo, CPF, titulo, qtde);
                    break;
                case 2:
                    Console.WriteLine("Digite o codigo da compra: ");
                    codigo = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine(model.ConsultarCompra(codigo));
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }
        }
    }
}

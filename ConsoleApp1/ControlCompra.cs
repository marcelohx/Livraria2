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
                              "\n1. Cadastrar Compra" +
                              "\n2. Consultar Compra");
        }
    }
}

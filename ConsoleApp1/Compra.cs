using Livraria2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Livraria2
{
    class Compra
    {
        Livro model;
        //Encapsulamento
        private string nome;
        private long CPF;
        private long codigoCompra;
        private double precoCompra;
        private int quantidadeCompra;

        public Compra()
        {
            model = new Livro();
            ModificarNomeCompra = "";
            ModificarCPFCompra = 0;
            ModificarCodigoCompra = 0;
            ModificarPrecoCompra = 0;
            ModificarQuantidadeCompra = 0;
        }//Fim do construtor
        public string ModificarNomeCompra
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        public long ModificarCPFCompra
        {
            get { return this.codigoCompra; }
            set { this.codigoCompra = value; }
        }
        public long ModificarCodigoCompra
        {
            get { return this.codigoCompra; }
            set { this.codigoCompra = value; }
        }

        public double ModificarPrecoCompra
        {
            get { return this.precoCompra; }
            set { this.precoCompra = value; }
        }

        public int ModificarQuantidadeCompra
        {
            get { return this.quantidadeCompra; }
            set { this.quantidadeCompra = value; }
        }

        public void CadastrarCompra(string nome, long CPF, long codigoCompra, double precoCompra, int quantidadeCompra)
        {
            ModificarNomeCompra = nome;
            ModificarCPFCompra = CPF;
            ModificarCodigoCompra = codigoCompra;
            ModificarPrecoCompra = precoCompra;
            ModificarQuantidadeCompra = quantidadeCompra;
        }//Fim do metodo

        public string ConsultarCompra(long codigoCompra)
        {
            string consulta = "";
            if (ModificarCodigoCompra == codigoCompra)
            {
                consulta = "\nNome do Cliente: " + ModificarNomeCompra +
                           "\nCPF do Cliente: " + ModificarCPFCompra +
                           "\nPreço da Compra: " + ModificarPrecoCompra +
                           "\nQuantidade de livros comprados: " + ModificarQuantidadeCompra;
            }
            else
            {
                consulta = "O número do código está invalido!!";
            }
            return consulta;
        }//Fim do consultar

        public void CompraLivro()
        {
            double ValorTotal = 0;




        }
    }
}

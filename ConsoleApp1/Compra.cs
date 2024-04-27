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
        Pessoa pes;
        Livro liv;
        //Encapsulamento
        private long codigoCompra;
        private long CPF;
        private string nome;
        private long codigoLivro;
        private string tituloLivro;
        private double precoUnitario;
        private double precoTotal;
        private int quantidadeCompra;
        public Compra()
        {
            pes = new Pessoa();
            liv = new Livro();
            ModificarCodigoCompra = 0;
            ModificarCPFCompra = 0;
            ModificarNomeCompra = "";
            ModificarCodigoLivro = 0;
            ModificarTituloLivro = "";
            ModificarPrecoUnitario = 0;
            ModificarPrecoTotal = 0;
            ModificarQuantidadeCompra = 0;

        }//Fim do construtor
        public long ModificarCodigoCompra
        {
            get { return this.codigoCompra; }
            set { this.codigoCompra = value; }
        }
        public long ModificarCPFCompra
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }
        public string ModificarNomeCompra
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        public long ModificarCodigoLivro
        {
            get { return this.codigoLivro; }
            set { this.codigoLivro = value; }
        }
        public string ModificarTituloLivro
        {
            get { return this.tituloLivro; }
            set { this.tituloLivro = value; }
        }
        public double ModificarPrecoUnitario
        {
            get { return this.precoUnitario; }
            set { this.precoUnitario = value; }
        }
        public double ModificarPrecoTotal
        {
            get { return this.precoTotal; }
            set { this.precoTotal = value;}
        }
        public int ModificarQuantidadeCompra
        {
            get { return this.quantidadeCompra; }
            set { this.quantidadeCompra = value; }
        }
        public void EfetuarCompra(long CPF, long codigoLivro, long codigoCompra, int quantidadeCompra)
        {
            if (ConsultarQtde(codigoCompra) > quantidadeCompra)
            {
                if (CPF == pes.ModificarCPF)
                {
                    ModificarCodigoCompra = codigoCompra;
                    ModificarNomeCompra = pes.ModificarNome;
                    if (codigoLivro == liv.ModificarCodigo)
                    {
                        ModificarTituloLivro = liv.ModificarTitulo;
                        ModificarQuantidadeCompra = Convert.ToInt32(Console.ReadLine());
                        ModificarPrecoUnitario = liv.ModificarPreco;
                        ModificarPrecoTotal = ModificarQuantidadeCompra * ModificarPrecoUnitario;
                        ModificarQuantidadeCompra = quantidadeCompra;
                        RemoverQuantidade(codigoCompra);
                    }
                    else
                    {
                        Console.WriteLine("Erro! O codigo informado não existe!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Erro! CPF invalido, verifique os dados digitados!");
                }
            }
        }//Fim do metodo
        public string ConsultarCompra(long codigoCompra)
        {
            string consulta = "";
            if (ModificarCodigoCompra == codigoCompra)
            {
                consulta = "\nNome do Cliente: " + ModificarNomeCompra +
                           "\nCPF do Cliente: " + ModificarCPFCompra +
                           "\nPreço da Compra: " + ModificarPrecoTotal +
                           "\nQuantidade de livros comprados: " + ModificarQuantidadeCompra;
            }
            else
            {
                consulta = "O número do código está invalido!!";
            }
            return consulta;
        }//Fim do consultar
        public int ConsultarQtde(long codigoCompra)
        {
            return (liv.ConsultarQuantidade(codigoCompra));
        }

        public void RemoverQuantidade(long codigoCompra)
        {
            if(ModificarQuantidadeCompra > 0)
            {
                liv.AtualizarQuantidade(codigoCompra, ConsultarQtde(codigoCompra) - ModificarQuantidadeCompra);
            }
        }
    }
}

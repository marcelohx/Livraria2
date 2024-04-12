using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Livraria2
{
    class Livro
    {
        //Encapsulamento = deixar as variaveis privadas
        private long codigo;
        private string titulo;
        private string autor;
        private string editora;
        private string genero;
        private long ISBN;
        private string situacao;
        private int quantidade;
        private double preco;

        public Livro()
        {
            ModificarCodigo = 0;
            ModificarTitulo = "";
            ModificarAutor = "";
            ModificarEditora = "";
            ModificarGenero = "";
            ModificarISBN = 0;
            ModificarSituacao = "";
            ModificarQuantidade = 0;
            ModificarPreco = 0;
        }//Fim do Construtor

        //Gets e Sets
        public long ModificarCodigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
        public string ModificarTitulo
        {
            get { return titulo; }
            set { this.titulo = value; }
        }
        public string ModificarAutor
        {
            get { return autor; }
            set { this.autor = value; }
        }
        public string ModificarEditora
        {
            get { return this.editora; }
            set { this.editora = value; }
        }
        public string ModificarGenero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }
        public long ModificarISBN
        {
            get { return this.ISBN; }
            set { this.ISBN = value; }
        }
        public string ModificarSituacao
        {
            get { return this.situacao; }
            set { this.situacao = value; }
        }
        public int ModificarQuantidade
        {
            get { return this.quantidade; }
            set { this.quantidade = value; }
        }
        public double ModificarPreco
        {
            get { return this.preco; }
            set { this.preco = value; }
        }
        public void CadastrarLivro(long codigo, string titulo, string autor, string editora, string genero, long ISBN, int quantidade, double preco)
        {
            ModificarCodigo = codigo;
            ModificarTitulo = titulo;
            ModificarAutor = autor;
            ModificarEditora = editora;
            ModificarGenero = genero;
            ModificarISBN = ISBN;
            ModificarSituacao = "Ativo";
            ModificarQuantidade = quantidade;
            ModificarPreco = preco;
        }//Fim do metodo
        public string ConsultarLivro(long codigo)
        {
            string consulta = "";
            if (ModificarCodigo == codigo)
            {
                consulta = "\nTitulo: " + ModificarTitulo +
                           "\nAutor: " + ModificarAutor +
                           "\nEditora: " + ModificarEditora +
                           "\nGenero: " + ModificarGenero +
                           "\nISBN: " + ModificarISBN +
                           "\nSituação: " + ModificarSituacao +
                           "\nQuantidade: " + ModificarQuantidade +
                           "\nPreço: " + ModificarPreco;
            }
            else
            {
                consulta = "O codigo não é válido";
            }
            return consulta;
        }//Fim do metodo
        public void AtualizarTitulo(long codigo, string titulo)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarTitulo = titulo;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarAutor(long codigo, string autor)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarAutor = autor;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarEditora(long codigo, string editora)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarEditora = editora;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarGenero(long codigo, string genero)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarGenero = genero;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarISBN(long codigo, long ISBN)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarISBN = ISBN;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarSituacao(long codigo, string situacao)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarSituacao = situacao;
            }
        }//fim do metodo
        public void AtualizarQuantidade(long codigo, int quantidade)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarQuantidade = quantidade;
            }//Fim do if
        }//Fim do metodo
        public void AtualizarPreco(long codigo, double preco)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarPreco = preco;
            }//Fim do if
        }//Fim do metodo
        public void Excluir(long codigo)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarSituacao = "Inativo";
            }//Fim do if
        }//Fim do metodo
    }//Fim da classe
}//Fim do projeto

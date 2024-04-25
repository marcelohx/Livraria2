using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx;

namespace ConsoleApp1
{
    class DAOLivro
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public long[] codigo;
        public string[] titulo;
        public string[] autor;
        public string[] editora;
        public string[] genero;
        public long[] ISBN;
        public string[] situacao;
        public int[] quantidade;
        public double[] preco;
        public int i;
        public int contador;
        public string msg;
        public DAOLivro()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=livrariaTI20N;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Abrir a conexão
                Console.WriteLine("Conectado!");//Teste
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
                conexao.Close();//Fechar a conexão com o banco de dados
            }
        }//Fim do Construtor
        public void InserirLivro(long codigo, string titulo, string autor, string editora, string genero, long ISBN, string situacao, int quantidade, double preco)
        {
            try
            {
                dados = "('" + codigo + "','" + titulo + "','" + autor + "','" + editora + "','"
                        + genero + "','" + ISBN + "','" + situacao + "','" + quantidade + "','" + preco + "')";
                comando = $"Insert into pessoa values {dados}";
                //Engatilhar a inserçao do banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();//Ctrl + Enter
                                                              //Mostrar na tela 
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch(Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
            }
        }
    }//Fim da class
}//Fim do Projeto

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class DAOCompra
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public long[] codigoCompra;
        public long[] CPF;
        public string[] nome;
        public double[] precoUnitario;
        public double[] precoTotal;
        public int[] quantidadeCompra;
        public int i;
        public int contador;
        public string msg;
        //Construtor
        public DAOCompra()
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
        public void Inserir(long codigoCompra, long CPF, string nome, double precoUnitario, double precoTotal, int quantidadeCompra)
        {
            try
            {
                //Declarei as variaveis e preparei o comando
                dados = "('" + codigoCompra + "','" + CPF + "','" + nome + "','" + precoUnitario + "','"
                        + precoTotal + "','" + quantidadeCompra + "')";
                comando = $"Insert into pessoa values {dados}";
                //Engatilhar a inserçao do banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();//Ctrl + Enter
                                                              //Mostrar na tela 
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n" + erro);
            }
        }//Fim do metodo
    }
}

using System;
using System.Collections;
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
        public void PreencherVetor()
        {
            string query = "select * from compra";
            codigoCompra = new long[100];
            CPF = new long[100];
            nome = new string[150];
            precoUnitario = new double[100];
            precoTotal = new double[100];
            quantidadeCompra = new int[100];
            for(i = 0; i < 100; i++)
            {
                codigoCompra[i] = 0;
                CPF[i] = 0;
                nome[i] = "";
                precoUnitario[i] = 0;
                precoTotal[i] = 0;
                quantidadeCompra[i] = 0;
            }
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco de dados
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            while (leitura.Read())
            {
                codigoCompra[i] = Convert.ToInt64(leitura["codigoCompra"]);
                CPF[i] = Convert.ToInt64(leitura["CPF"] + "");
                nome[i] = leitura["nome"] + "";
                precoUnitario[i] = Convert.ToDouble(leitura["precoUnitario"] + "");
                precoTotal[i] = Convert.ToDouble(leitura["precoTotal"] + "");
                quantidadeCompra[i] = Convert.ToInt32(leitura["quantidadeCompra"] + "");
                i++;
                contador++;
            }//fim do while
            leitura.Close();//Fecha a conexao com o banco
        }//Fim do metodo
        public string ConsultarTudo()
        {
            PreencherVetor();//Preencher vetores
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += "\ncodigo da compra: " + codigoCompra[i] +
                       ", CPF: " + CPF[i] +
                       ", nome: " + nome[i] +
                       ", preco unitario: " + precoUnitario[i] +
                       ", precoTotal: " + precoTotal[i] +
                       ", quantidadeCompra: " + quantidadeCompra[i];
            }//Fim do for
            return msg;
        }//fim do metodo
        public string ConsultarIndividual(long codCompra)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (codigoCompra[i] == codCompra)
                {
                    msg += "\ncodigo da compra: " + codigoCompra[i] +
                      ", CPF: " + CPF[i] +
                      ", nome: " + nome[i] +
                      ", preco unitario: " + precoUnitario[i] +
                      ", precoTotal: " + precoTotal[i] +
                      ", quantidadeCompra: " + quantidadeCompra[i];
                    return msg;
                }//fim do if                
            }//fim do for
            return "Código não encontrado!";
        }//Fim do consultar indiv.
    }//Fim da classe
}//Fim do projeto

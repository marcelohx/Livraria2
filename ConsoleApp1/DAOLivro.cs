using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                comando = $"Insert into livro values {dados}";
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
        }//fim do metodo
        public void PreencherVetor()
        {
            string query = "select * from livro";//coletar os dados do banco
            //Instanciar
            codigo = new long[100];
            titulo = new string[150];
            autor = new string[150];
            editora = new string[150];
            genero = new string[100];
            ISBN = new long[100];
            situacao= new string[100];
            quantidade = new int[100];
            preco = new double[100];
            //preencher
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                autor[i] = "";
                editora[i] = "";
                genero[i] = "";
                ISBN[i] = 0;
                situacao[i] = "";
                quantidade[i] = 0;
                preco[i] = 0;
            }//fim do for
            //preparar comando do select
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco de dados
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt64(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + "";
                autor[i] = leitura["autor"] + "";
                editora[i] = leitura["editora"] + "";
                genero[i] = leitura["genero"] + "";
                ISBN[i] = Convert.ToInt64(leitura["ISBN"]);
                situacao[i] = leitura["situacao"] + "";
                quantidade[i] = Convert.ToInt32(leitura["quantidade"]);
                preco[i] = Convert.ToDouble(leitura["preco"]);
                i++;
                contador++;
            }//Fim do while
            leitura.Close();//fechar a conexão com o banco
        }//Fim do metodo
        public string ConsultarTodosLivros()
        {
            PreencherVetor();
            msg = "";
            for(i = 0; i < contador; i++)
            {
                msg += "\ncodigo: " + codigo[i] +
                       ", titulo: " + titulo[i] +
                       ", autor: " + autor[i] +
                       ", editora: " + editora[i] +
                       ", genero: " + genero[i] +
                       ", ISBN: " + ISBN[i] +
                       ", situacao: " + situacao[i] +
                       ", quantidade: " + quantidade[i] +
                       ", preco: " + preco[i];
            }//fim do for
            return msg;
        }//fim do metodo
        public string ConsultarLivroIndividual(long codigoLivro)
        {
            PreencherVetor();
            msg = "";
            for(i = 0; i < contador; i++)
            {
                if (codigo[i] == codigoLivro)
                {
                    msg += "\ncodigo: " + codigo[i] +
                      ", titulo: " + titulo[i] +
                      ", autor: " + autor[i] +
                      ", editora: " + editora[i] +
                      ", genero: " + genero[i] +
                      ", ISBN: " + ISBN[i] +
                      ", situacao: " + situacao[i] +
                      ", quantidade: " + quantidade[i] +
                      ", preco: " + preco[i];
                    return msg;
                }//fim do if
            }//Fim do for
            return "Código não encontrado!";
        }//Fim do metodo
        public string Atualizar(long codigoLivro, string campo, string novoDado)
        {
            try
            {
                string query = "update livro set " + campo + " = '" + novoDado + "' where codigo = '" + codigoLivro + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch (Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Atualizar
        public string Atualizar(long codigoLivro, string campo, long novoDado)
        {
            try
            {
                string query = "update livro set " + campo + " = '" + novoDado + "' where codigo = '" + codigoLivro + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch (Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Atualizar
        public string Atualizar(long codigoLivro, string campo, int novoDado)
        {
            try
            {
                string query = "update livro set " + campo + " = '" + novoDado + "' where codigo = '" + codigoLivro + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch (Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Atualizar
        public string Atualizar(long codigoLivro, string campo, double novoDado)
        {
            try
            {
                string query = "update livro set " + campo + " = '" + novoDado + "' where codigo = '" + codigoLivro + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch (Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Atualizar
        public string Excluir(long codigoLivro)
        {
            try
            {
                string query = "update livro set situacao = 'Inativo' where codigo = '" + codigoLivro + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch (Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Excluir
    }//Fim da class
}//Fim do Projeto

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
    class DAOPessoa
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public long[] CPF;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public DateTime[] dtNascimento;
        public string[] login;
        public string[] senha;
        public string[] situacao;
        public string[] posicao;
        public int i;
        public int contador;
        public string msg;
        //Construtor
        public DAOPessoa()
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
        public void Inserir(long CPF, string nome, string telefone, string endereco, DateTime dtNascimento, 
                            string login, string senha, string situacao, string posicao)
        {
            try
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dtNascimento.Year + "-" + dtNascimento.Month + "-" + dtNascimento.Day;
                //Declarei as variaveis e preparei o comando
                dados = "('" + CPF + "','" + nome + "','" + telefone + "','" + endereco + "','"
                        + parameter.Value + "','" + login + "','" + senha + "','" + situacao + "','" + posicao + "')";
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
        }//Fim do metodo
        public void PreencherVetor()
        {
            string query = "select * from pessoa";// coletar os dados do banco
            //Instanciar
            CPF = new long[100];
            nome = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            dtNascimento = new DateTime[100];
            login = new string[100];
            senha = new string[100];
            situacao = new string[100];
            posicao = new string[100];
            //preencher
            for(i = 0; i<100; i++)
            {
                CPF[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                dtNascimento[i] = new DateTime();
                login[i] = "";
                senha[i] = "";
                situacao[i] = "";
                posicao[i] = "";
            }//Fim do for
            //preparar comando do select
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura do banco de dados
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            while (leitura.Read())
            {
                CPF[i] = Convert.ToInt64(leitura["CPF"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                //Convertendo para o padrao dia/mes/ano
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = Convert.ToDateTime(leitura["dtNascimento"]).Day   + "/" +
                                  Convert.ToDateTime(leitura["dtNascimento"]).Month + "/" +
                                  Convert.ToDateTime(leitura["dtNascimento"]).Year;
                dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);

                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                situacao[i] = leitura["situacao"] + "";
                posicao[i] = leitura["posicao"] + "";
                i++;
                contador++;
            }//fim do while
            leitura.Close();//Fecha a conexao com o banco
        }//Fim do metodo
        public string ConsultarTudo()
        {
            PreencherVetor();//Preencher vetores
            msg = "";
            for(i = 0; i < contador; i++)
            {
                msg += "\nCPF: " + CPF[i] +
                       ", nome: " + nome[i] +
                       ", telefone: " + telefone[i] +
                       ", endereço: " + endereco[i] +
                       ", nascimento: " + dtNascimento[i] +
                       ", login: " + login[i] +
                       ", senha: " + senha[i] +
                       ", posição: " + posicao[i] +
                       ", situação: " + situacao[i];
            }//Fim do for
            return msg;
        }//fim do metodo
        public string ConsultarIndividual(long codCPF)
        {
            PreencherVetor();
            msg = "";
            for(i=0; i < contador; i++)
            {
                if (CPF[i] == codCPF)
                {
                    msg = "CPF: " + CPF[i] +
                          ", nome: " + nome[i] +
                          ", telefone: " + telefone[i] +
                          ", endereço: " + endereco[i] +
                          ", nascimento: " + dtNascimento[i] +
                          ", login: " + login[i] +
                          ", senha: " + senha[i] +
                          ", situação: " + situacao[i] +
                          ", cargo: " + posicao[i];
                    return msg;
                }//fim do if                
            }//fim do for
            return "Código não encontrado!";
        }//Fim do consultar indiv.
        public string Atualizar(long codCPF, string campo, string novoDado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + novoDado + "' where CPF = '" + codCPF + "'";
                //Executar comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha afetada!";
            }//fim do try
            catch(Exception ex)
            {
                return "Algo deu errado!\n\n\n" + ex;
            }//fim do catch
        }//Fim do Atualizar
        public string Atualizar(long codCPF, string campo, DateTime novoDado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + novoDado + "' where CPF = '" + codCPF + "'";
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
        public string Excluir(long codCPF)
        {
            try
            {
                string query = "update pessoa set situacao = 'Inativo' where CPF = '" + codCPF + "'";
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
    }//Fim da classe
}//FIm do projeto
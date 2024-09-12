using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Biblioteca de conexão do SQL
using MySql.Data;
using MySql.Data.MySqlClient;

//adicionar a biblioteca para visualizar os dados na DataGridView
using System.Data;

namespace exemplo_crud
{
    class colaborador: conexao
    {
        private string codigo;

        public void setCodigo(string codigo)
        {
            this.codigo = codigo;
        }
        public string getCodigo()
        {
            return this.codigo;
        }
        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getUsuario()
        {
            return this.usuario;
        }
        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public string getSenha()
        {
            return this.senha;
        }
        //criação do metodo iserir()
        public void inserir()
        {
            string query = "insert into login (usuario_colaborador , 	senha_colaborador )values('" + getUsuario()+"','"+getSenha()+"')";
            //abrir conexão, enviar ao banco de dados e fechar conexão
            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }

        }

        public void excluir()
        {
            string query = "delete from login where codigo_colaborador = '" + getCodigo() +"'";
            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }
        }

        //metodo para vizualizar os dadods

        public DataTable Consultar()
        {
            this.abrirconexao();
            string mSQL = "Select * from login";
            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            this.fecharconexao();
            
            //visualizar os dados partir da select
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

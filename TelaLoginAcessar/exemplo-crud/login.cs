using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace exemplo_crud
{
    class login:colaborador
    {
        public int consulta_login()
        {
            this.abrirconexao();

            string mSQL = "select count(usuario_colaborador) from login where usuario_colaborador = '" + getUsuario() + "' and senha_colaborador = '" + getSenha() + "'";

            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            Int32 resultado_query = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            int valor_login;
            valor_login = resultado_query;
            this.fecharconexao();
            return valor_login;
        }
    }
}

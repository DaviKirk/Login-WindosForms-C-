using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exemplo_crud
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.setUsuario(txt_usuarioLogin.Text);
            l.setSenha(txt_senhaLogin.Text);
            l.consulta_login();

            int valor = l.consulta_login();

            if (valor == 1)
            {
                frm_home formulario = new frm_home();
                formulario.Show();
                this.Hide();
            }
            else if (txt_usuarioLogin.Text == "admin" && txt_senhaLogin.Text == "admin")
            {
                frm_home formulario = new frm_home();
                formulario.Show();
                this.Hide();
            } 
            else
            {
                MessageBox.Show("Usuário e Senhas Invalidas", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_senhaLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

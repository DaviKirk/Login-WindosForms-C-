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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        colaborador c = new colaborador();

        public void exibiregistro(int i)
        {
            txt_id.Text = "" + dataGridView1[0, i].Value;
            txt_senha.Text = "" + dataGridView1[3, i].Value;
            txt_usuario.Text = "" + dataGridView1[1, i].Value;

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                c.setSenha(txt_senha.Text);
                c.setUsuario(txt_usuario.Text);
                //chamar o metodo inserir
                c.inserir();
            }
            finally
            {
                MessageBox.Show("informações gravadas com sucesso");
                dataGridView1.DataSource = c.Consultar();
                //alterar nomes das colunas da datagridview
                dataGridView1.Columns["usuario_colaborador"].HeaderText = "Usuario";
                dataGridView1.Columns["senha_colaborador"].HeaderText = "Senha";
                dataGridView1.Columns["codigo_colaborador"].HeaderText = "ID";

            }

        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = c.Consultar();
            //alterar nomes das colunas da datagridview
            dataGridView1.Columns["usuario_colaborador"].HeaderText = "Usuario";
            dataGridView1.Columns["senha_colaborador"].HeaderText = "Senha";
            dataGridView1.Columns["codigo_colaborador"].HeaderText = "ID";

        }

        private void btn_exluir_Click(object sender, EventArgs e)
        {
            try
            {
                c.setCodigo(txt_id.Text);
                c.excluir();
                dataGridView1.DataSource = c.Consultar();
            }
            finally
            {
                MessageBox.Show("informações excluídas com sucesso");
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_senha.Text = "";
            txt_usuario.Text = "";
            txt_id.Text = "";


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            exibiregistro(dataGridView1.CurrentRow.Index);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //abrir formulario
            frm_home formulario = new frm_home();
            formulario.Show();
            //esconder formulario splash
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //abrir formulario
            frm_login formulario = new frm_login();
            formulario.Show();
            //esconder formulario splash
            this.Hide();
        }
    }
}

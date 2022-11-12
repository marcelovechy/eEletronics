using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace eEletronics
{
    public partial class alterarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //MOSTRA O PRODUTO A SER ALTERADO
        protected void ddl_prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bd_loja_onlineConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@produto", ddl_prod.SelectedItem.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostrarProd";

                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                List<produtos> listaProdutos = new List<produtos>();

                while (dr.Read())
                {
                    produtos p = new produtos();

                    p.nome = dr["nome"].ToString();
                    p.preco = Convert.ToInt32(dr["preco"]);
                    p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["dadosBinarios"]);
                    //Response.ContentType = dr["contentType"].ToString();
                    //Response.BinaryWrite((byte[])dr["dadosBinarios"]);

                    listaProdutos.Add(p);
                }

                conn.Close();

                rpt_produtos.DataSource = listaProdutos;
                rpt_produtos.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        //ALTERA O PRODUTO PREVIAMENTE SELECIONADO
        protected void btn_alterarProduto_Click(object sender, EventArgs e)
        {
            try
            {

                Stream ficheiro = fu_nova.PostedFile.InputStream;
                int fichTamanho = fu_nova.PostedFile.ContentLength;
                string fichNome = tb_novo_nome.Text;
                string fichPreco = tb_novo_preco.Text;

                byte[] fichBinaryData = new byte[fichTamanho];
                ficheiro.Read(fichBinaryData, 0, fichTamanho);



                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bd_loja_onlineConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nome_antigo", ddl_prod.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@nome", fichNome);
                cmd.Parameters.AddWithValue("@preco", fichPreco);
                cmd.Parameters.AddWithValue("@arrayBytes", fichBinaryData);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "alterarFicheiro";

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();

                lb_mensagem.Visible = true;
                lb_mensagem.Text = "Sucesso!";

                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch (Exception ex)
            {

            }
        }

        public class produtos
        {
            public string nome { get; set; }
            public int preco { get; set; }
            public string foto { get; set; }
        }
    }
}

    }
}
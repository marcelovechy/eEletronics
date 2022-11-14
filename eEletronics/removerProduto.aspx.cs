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
    public partial class removerProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["perfil"] == null || Session["perfil"].ToString() != "Administrador")
            //{
            //    Response.Redirect("login.aspx");
            //}

            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@produto", ddl_produtos.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostra_produto";

                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                List<produtos> listaProdutos = new List<produtos>();

                while (dr.Read())
                {
                    produtos p = new produtos();

                    p.nome = dr["nome"].ToString();
                    p.preco = dr["preco"].ToString();
                    p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);


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

        protected void btn_apagarProduto_Click(object sender, EventArgs e)
        {
            try
            {

             



                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nome", ddl_produtos.SelectedItem.Text);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "apagar_produto";

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();

                lbl_mensagem.Visible = true;
                lbl_mensagem.Text = "Produto excluido com sucesso!";



            }
            catch (Exception ex)
            {

            }
        }

        public class produtos
        {
            public string nome { get; set; }
            public string preco { get; set; }
            public string foto { get; set; }
        }
    }

}
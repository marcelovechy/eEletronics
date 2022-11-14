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
    public partial class alterarUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();
               // Response.Write("Olaa");
                cmd.Parameters.AddWithValue("@nome", ddl_user.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostra_user";
               // Response.Write("Olaa1");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
               // Response.Write("Olaa2");
                List<users> listaUsers = new List<users>();
                //Response.Write("Olaa3");

                while (dr.Read())
                {
                   // Response.Write("Olaa4444");
                    users u = new users();
                   // Response.Write("Olaa555555");
                    u.nome = dr["nome"].ToString();
                    u.nome = dr["perfil"].ToString();
                    u.nome = dr["email"].ToString();
                    u.nome = dr["morada"].ToString();


                    //Response.Write("66666");
                    listaUsers.Add(u);
                }

                conn.Close();
               // Response.Write("Olaa5");
                rpt_user.DataSource = listaUsers;
                rpt_user.DataBind();

            }
            catch (Exception ex)
            {
                
            }

        }





        protected void btn_alterarUser_Click(object sender, EventArgs e)
        {
            try
            {



                string nNome = tb_novoNome.Text;
                string nPerfil = ddl_perfil.SelectedItem.Text;

                string nEmail = tb_novoEmail.Text;
                string nMorada = tb_novoMorada.Text;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nomeAntigo", ddl_user.Text);
                cmd.Parameters.AddWithValue("@nNome", nNome);
                cmd.Parameters.AddWithValue("@nPerfil", nPerfil);

                cmd.Parameters.AddWithValue("@nEmail", nEmail);
                cmd.Parameters.AddWithValue("@nMorada", nMorada);


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "alterar_user";

                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();

                lbl_mensagem.Visible = true;
                lbl_mensagem.Text = "Alterado com sucesso!";



            }
            catch (Exception ex)
            {

            }
        }

        public class users
        {
            public string nome { get; set; }
            public string perfil { get; set; }

            public string email { get; set; }
            public string morada { get; set; }
        }

   

    
    }
}

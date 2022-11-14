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
    public partial class lojaUserRevenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "preco_desconto";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
                p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();

        }


        public class produto
        {
            public string nome { get; set; }
            public string preco { get; set; }
            public string preco_desconto { get; set; }
            public string foto { get; set; }
        }


        protected void btn_pesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            string pesquisar = "%" + tb_pesquisa.Text + "%";

            myCommand.Parameters.AddWithValue("@pesquisar", pesquisar);


            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "pesquisar_produto";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
                p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();

        }

        protected void btn_nomeAsc_Click1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "nome_asc";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
                //p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();

        }

        protected void btn_nomeDes_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "nome_desc";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
                //p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();
        }

        protected void btn_precoAsc_Click1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "preco_asc";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
               // p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();
        }

        protected void btn_precoDesc_Click1(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "preco_desc";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader dr = myCommand.ExecuteReader();

            //lista para receber objetos produto
            List<produto> lst_eletronicos = new List<produto>();

            while (dr.Read())
            {
                produto p = new produto();

                p.nome = dr["nome"].ToString();
                p.preco = dr["preco"].ToString();
                //p.preco_desconto = dr["preco_desconto"].ToString();
                p.foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["foto"]);

                lst_eletronicos.Add(p);
            }

            myCon.Close();

            // o repeter alimenta a lista
            rpt_lojaProjeto.DataSource = lst_eletronicos;
            rpt_lojaProjeto.DataBind();
        }


    }
}
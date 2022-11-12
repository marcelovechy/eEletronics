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
    public partial class inserirProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_gravar_Click(object sender, EventArgs e)
        {
            Stream imgStream = FileUpload1.PostedFile.InputStream;
            int comprimento = FileUpload1.PostedFile.ContentLength;

            byte[] fotoBinario = new byte[comprimento];
            imgStream.Read(fotoBinario, 0, comprimento);



            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@preco", tb_preco.Text);
            myCommand.Parameters.AddWithValue("@foto", fotoBinario);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "inserir_produto";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();
            myCon.Close();

            lbl_mensagem.Visible = true;
        }
    }
}
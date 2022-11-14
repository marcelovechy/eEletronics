using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eEletronics
{
    public partial class backofficeAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddl_gerirEncomendas.Visible == true)
            {

                if (ddl_gerirEncomendas.SelectedItem.Text == "Inserir encomenda")
                {
                    Response.Redirect("inserirEncomenda.aspx");
                }
                else if (ddl_gerirEncomendas.SelectedItem.Text == "Alterar encomenda")
                {
                    Response.Redirect("alterarEncomenda.aspx");
                }
                else if (ddl_gerirEncomendas.SelectedItem.Text == "Remover encomenda")
                    Response.Redirect("removerEncomenda.aspx");

            }
            else if (ddl_gerirProdutos.Visible == true)
            {
                if (ddl_gerirProdutos.Text == "Inserir produto")
                {
                    Response.Redirect("inserirProduto.aspx");
                }
                else if (ddl_gerirProdutos.Text == "Alterar produto")
                {
                    Response.Redirect("alterarProduto.aspx");
                }
                else if (ddl_gerirProdutos.Text == "Remover produto")
                    Response.Redirect("removerProduto.aspx");
            }
            else if (ddl_gerirUsers.Visible == true)
            {
                if (ddl_gerirUsers.Text == "Inserir user")
                {
                    Response.Redirect("inserirUser.aspx");
                }
                else if (ddl_gerirUsers.Text == "Alterar user")
                {
                    Response.Redirect("alterarUser.aspx");
                }
                else if (ddl_gerirUsers.Text == "Remover user")
                    Response.Redirect("removerUser.aspx");
            }



        }

        protected void btn_gerirEncomendas_Click(object sender, EventArgs e)
        {
            ddl_gerirEncomendas.Visible = true;


        }

        protected void btn_gerirProdutos_Click(object sender, EventArgs e)
        {
            ddl_gerirProdutos.Visible = true;
        

        }
        protected void btn_gerirUsers_Click(object sender, EventArgs e)
        {
            ddl_gerirUsers.Visible = true;
    
        }

    }
}
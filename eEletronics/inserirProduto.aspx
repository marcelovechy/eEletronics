<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="inserirProduto.aspx.cs" Inherits="eEletronics.inserirProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

        <div id="customer_details" class="col2-set" text="center">
            <div class="col-1">
                <div class="woocommerce-billing-fields">

                    <h3>Insira o produto</h3>

                    <p id="billing_first_name_field" class="form-row form-row-first validate-required">
                        
                        <asp:TextBox ID="tb_nome" runat="server" class="" placeholder="Nome do produto" for="billing_first_name"></asp:TextBox>
                    </p>

                    <p id="billing_last_name_field" class="form-row form-row-last validate-required">
                        <asp:TextBox ID="tb_preco" runat="server" class="" placeholder="Preço do produto" for="billing_first_name"></asp:TextBox>
                    </p>
                    

                    <asp:FileUpload ID="FileUpload1" runat="server" placeholder="Carregue a imagem" Visible="True" />


                </div>

                        <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_gravar_Click" />
                <br />
             
                <asp:Label ID="lbl_mensagem" runat="server" Text="O produto foi inserido com sucesso" ForeColor="#009900" Visible="False"></asp:Label>
            </div>


        </div>
    </div>









</asp:Content>

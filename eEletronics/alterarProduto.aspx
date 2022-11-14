<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="alterarProduto.aspx.cs" Inherits="eEletronics.alterarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-md-6">
                <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                    <div id="customer_details" class="col2-set" text="center">
                        <div class="col-1">
                            <div class="woocommerce-billing-fields">
                                <h3>Selecione o produto:</h3>
                                <asp:DropDownList ID="ddl_produtos" ForeColor="Black" runat="server" DataSourceID="SqlDataSource1" DataTextField="nome" DataValueField="nome" AutoPostBack="true"></asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eEletronicsConnectionString %>" SelectCommand="SELECT nome FROM [produtosLoja]"></asp:SqlDataSource>

                            </div>
                        </div>

                        <asp:Repeater ID="rpt_produtos" runat="server">

                            <ItemTemplate>

                                <div class="col-md-6 col-sm-6">
                                    <div class="single-shop-product">
                                        <div class="product-upper">
                                            <img src="<%#Eval("foto")%>" alt="">
                                        </div>
                                        <h2><a href=""><%#Eval("nome")%></a></h2>
                                        <div class="product-carousel-price">
                                            <ins><%#Eval("preco")%>€</ins><%-- <del>$999.00</del>--%>
                                        </div>


                                    </div>
                                </div>


                            </ItemTemplate>

                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <div class="col-md-6">


                <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                    <div id="customer_details" class="col2-set" text="center">
                        <div class="col-1">
                            <div class="woocommerce-billing-fields">

                                <h3>Insira os novos dados:</h3>

                                <p id="billing_first_name_field" class="form-row form-row-first validate-required">

                                    <asp:TextBox ID="tb_novoNome" runat="server" class="" placeholder="Nome do produto" for="billing_first_name"></asp:TextBox>
                                </p>

                                <p id="billing_last_name_field" class="form-row form-row-last validate-required">
                                    <asp:TextBox ID="tb_novoPreco" runat="server" class="" placeholder="Preço do produto" for="billing_first_name"></asp:TextBox>
                                </p>


                                <asp:FileUpload ID="fUpload" runat="server" placeholder="Carregue a imagem" Visible="True" />


                            </div>

                            <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_alterarProduto_Click" />
                            <br />

                            <asp:Label ID="lbl_mensagem" runat="server"  ForeColor="#009900" Visible="False"></asp:Label>
                        </div>


                    </div>
                </div>
            </div>

        </div>
          <div class="col-md-12" height="10%">
              <p></p>
               <p></p>
          </div>
    </div>
</asp:Content>

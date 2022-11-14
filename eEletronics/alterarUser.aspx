<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="alterarUser.aspx.cs" Inherits="eEletronics.alterarUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-md-6">
                <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                    <div id="customer_details" class="col2-set" text="center">
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="col-1">
                            <div class="woocommerce-billing-fields">
                                <h3>Selecione o user:</h3>

                                <asp:DropDownList ID="ddl_user" runat="server" DataSourceID="SqlDataSource1" DataTextField="nomeUser" DataValueField="nomeUser" AutoPostBack="True"></asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eEletronicsConnectionString %>" SelectCommand="SELECT [nomeUser] FROM [utilizadores]"></asp:SqlDataSource>

                                <%--<asp:DropDownList ID="ddl_user" ForeColor="Black" runat="server" DataSourceID="SqlDataSource1" DataTextField="nome" DataValueField="nome" AutoPostBack="true"></asp:DropDownList>--%>

                                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eEletronicsConnectionString %>" SelectCommand="SELECT [nomeUser] FROM [utilizadores]"></asp:SqlDataSource>--%>
                            </div>
                        </div>

                        <asp:Repeater ID="rpt_user" runat="server">

                            <ItemTemplate>


                                <h2><a href=""><%#Eval("nome")%></a></h2>
                                <h2><a href=""><%#Eval("perfil")%></a></h2>

                                <h2><a href=""><%#Eval("email")%></a></h2>
                                <h2><a href=""><%#Eval("morada")%></a></h2>
                                <!-- <div class="col-md-6 col-sm-6">
                                    <div class="single-shop-product">
                                        <div class="product-upper">

                                            <h2></h2>
                                           <h2><a href=""><%#Eval("nome")%></a></h2>
                                            <h2><a href=""><%#Eval("perfil")%></a></h2>
                                        
                                            <h2><a href=""><%#Eval("email")%></a></h2>
                                            <h2><a href=""><%#Eval("morada")%></a></h2>

                                        </div>
                                    </div>
                                </div> -->


                            </ItemTemplate>

                        </asp:Repeater>
                        <br />
                        <br />
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
                                    <asp:TextBox ID="tb_novoNome" runat="server" class="" placeholder="Novo nome do user" for="billing_first_name"></asp:TextBox>


                                    <asp:DropDownList ID="ddl_perfil" runat="server" DataSourceID="SqlDataSource2" DataTextField="perfil" DataValueField="perfil"></asp:DropDownList>

                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eEletronicsConnectionString %>" SelectCommand="SELECT [perfil] FROM [perfis]"></asp:SqlDataSource>

                                    <%--<asp:DropDownList ID="ddl_perfil" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"></asp:DropDownList>--%>
                                    <asp:EntityDataSource ID="EntityDataSource1" runat="server">
                                    </asp:EntityDataSource>

                                    <asp:TextBox ID="tb_novoEmail" runat="server" class="" placeholder="email" for="billing_first_name"></asp:TextBox>
                                    <asp:TextBox ID="tb_novoMorada" runat="server" class="" placeholder="morada" for="billing_first_name"></asp:TextBox>
                            </div>

                            <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_alterarUser_Click" />
                            <br />

                            <asp:Label ID="lbl_mensagem" runat="server" ForeColor="#009900"></asp:Label>
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

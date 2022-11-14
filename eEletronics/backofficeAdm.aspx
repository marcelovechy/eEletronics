<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="backofficeAdm.aspx.cs" Inherits="eEletronics.backofficeAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Backoffice</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="promo-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">

                <div class="col-md-4 col-sm-6">
                    <div class="single-promo promo2">
                        <i class="fa fa-truck"></i>
                      <p>
                        <asp:Button ID="btn_gerirProdutos" runat="server" Text="Gerir Produtos" width="60%" Font-Size="16px" OnClick="btn_gerirProdutos_Click" />
                       </p>
                        <div class="single-sidebar">
                            <h2 class="sidebar-title">
                                <asp:DropDownList ID="ddl_gerirProdutos" runat="server" AutoPostBack="True" ForeColor="Black" Visible="False">
                                    <asp:ListItem>--------</asp:ListItem>
                                    <asp:ListItem>Inserir produto</asp:ListItem>
                                    <asp:ListItem>Alterar produto</asp:ListItem>
                                    <asp:ListItem>Remover produto</asp:ListItem>
                                </asp:DropDownList></h2>
                        </div>
                        <!--<a href="https://localhost:44319/gerirProdutos.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%">Gerir produtos</a>-->

                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="single-promo promo3">
                        <i class="fa fa-gift"></i>
                        <p>
                        <asp:Button ID="btn_gerirEncomendas" runat="server" Text="Gerir Encomendas" width="60%" Font-Size="16px" OnClick="btn_gerirEncomendas_Click" />
                       </p>

                        <div class="single-sidebar">
                            <h2 class="sidebar-title">
                                <asp:DropDownList ID="ddl_gerirEncomendas" runat="server" AutoPostBack="True" ForeColor="Black" Visible="False">
                                    <asp:ListItem>--------</asp:ListItem>
                                    <asp:ListItem>Inserir encomenda</asp:ListItem>
                                    <asp:ListItem>Alterar encomenda</asp:ListItem>
                                    <asp:ListItem>Remover encomenda</asp:ListItem>
                                </asp:DropDownList></h2>
                        </div>
<%--                        <a href="https://localhost:44319/gerirEncomendas.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top: 2%">Gerir encomendas</a>--%>

                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="single-promo promo4">
                        <i class="fa fa-users"></i>
                                               <p>
                        <asp:Button ID="btn_gerirUsers" runat="server" Text="Gerir Users" width="60%" Font-Size="16px" OnClick="btn_gerirUsers_Click" />
                       </p>

                        <div class="single-sidebar">
                            <h2 class="sidebar-title">
                                <asp:DropDownList ID="ddl_gerirUsers" runat="server" AutoPostBack="True" ForeColor="Black" Visible="False">
                                    <asp:ListItem>--------</asp:ListItem>
                                    <asp:ListItem>Inserir user</asp:ListItem>
                                    <asp:ListItem>Alterar user</asp:ListItem>
                                    <asp:ListItem>Remover user</asp:ListItem>
                                </asp:DropDownList></h2>
                        </div>
<%--                        <a href="https://localhost:44319/gerirUsers.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top: 2%">Gerir utilizadores</a>--%>

                    </div>
                </div>


                   


                </div>
            </div>
        </div>
    <!-- End promo area -->

     </div>
</asp:Content>

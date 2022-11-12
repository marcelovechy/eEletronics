<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="gerirProdutos.aspx.cs" Inherits="eEletronics.gerirProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="promo-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">

                <div class="col-md-12 col-sm-12">
                    <div class="single-promo promo4">
                        <p>Gerir produtos</p>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        
        <div class="row">
            <div class="col-md-4">
                <div class="single-sidebar">
                    <h2 class="sidebar-title">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>--------</asp:ListItem>
                            <asp:ListItem>Inserir produto</asp:ListItem>
                            <asp:ListItem>Alterar produto</asp:ListItem>
                            <asp:ListItem>Remover produto</asp:ListItem>
                        </asp:DropDownList></h2>
                </div>
            </div>
        </div>
    </div>





</asp:Content>

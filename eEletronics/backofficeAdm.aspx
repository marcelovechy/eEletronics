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
                        <p></p>
                        <a href="https://localhost:44319/gerirProdutos.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%">Gerir produtos</a>

                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="single-promo promo3">
                        <i class="fa fa-gift"></i>
                        <p></p>
                        <a href="https://localhost:44319/gerirEncomendas.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%">Gerir encomendas</a>

                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="single-promo promo4">
                        <i class="fa fa-users"></i>
                        <p></p>
                        <a href="https://localhost:44319/gerirUsers.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%">Gerir utilizadores</a>

                    </div>
                </div>
            </div>
        </div>
    </div> <!-- End promo area -->

</asp:Content>

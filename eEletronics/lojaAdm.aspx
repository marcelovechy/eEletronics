<%@ Page Title="" Language="C#" MasterPageFile="~/templateAdm.Master" AutoEventWireup="true" CodeBehind="lojaAdm.aspx.cs" Inherits="eEletronics.lojaAdm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Shop</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-4">

                    <div class="single-sidebar">
                        <asp:TextBox ID="tb_pesquisa" runat="server" placeholder="Pesquisar produtos" Width="50%"></asp:TextBox>

                        <asp:Button ID="btn_pesquisar" runat="server" Text="Pesquisar" OnClick="btn_pesquisar_Click" />
                        <div>
                            <asp:Button ID="btn_nomeAsc" runat="server" Text="Nome ascendente" OnClick="btn_nomeAsc_Click1" />
                        </div>
                        <div>
                            <asp:Button ID="btn_nomeDes" runat="server" Text="Nome descendente" OnClick="btn_nomeDes_Click" />
                        </div>
                        <div>
                            <asp:Button ID="btn_precoAsc" runat="server" Text="Preço ascendente" OnClick="btn_precoAsc_Click1" />
                        </div>
                        <div>
                            <asp:Button ID="btn_precoDesc" runat="server" Text="Preço descendente" OnClick="btn_precoDesc_Click1" />
                        </div>
                    </div>
                </div>


                <div class="col-md-8">

                    <asp:Repeater ID="rpt_lojaProjeto" runat="server">
                        <ItemTemplate>

                            <%--div do telefone--%>

                            <div class="col-md-3 col-sm-6">
                                <div class="single-shop-product">
                                    <div class="product-upper">
                                        <img src="<%#Eval("foto")%>" alt="">
                                    </div>
                                    <h2><a href=""><%#Eval("nome")%></a></h2>
                                    <div class="product-carousel-price">
                                        <ins><%#Eval("preco")%>€</ins><%-- <del>$999.00</del>--%>
                                    </div>

                                    <div class="product-option-shop">
                                        <a class="add_to_cart_button" data-quantity="1" data-product_sku="" data-product_id="70" rel="nofollow" href="/canvas/shop/?add-to-cart=70">Add to cart</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

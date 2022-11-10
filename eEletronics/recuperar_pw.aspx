<%@ Page Title="" Language="C#" MasterPageFile="~/templateProjeto.Master" AutoEventWireup="true" CodeBehind="recuperar_pw.aspx.cs" Inherits="eEletronics.recuperar_pw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="footer-top-area">
        <div class="zigzag-bottom"></div>
        <div class="container">

               <div class="col text-center " style="margin-bottom:10%">
      
                    <div class="footer-newsletter">
                        <br />
                          <br />
                        <h2 class="footer-wid-title " >Recupere a vossa palavra-passe</h2>
                      
                        <div class="newsletter-forme">
                            <asp:Label ID="lbl_email" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="tb_novaPasse" runat="server" type="text"  name="cf-name" placeholder=" Insira a nova Palavra-passe"  Width="350px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lbl_resultado" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btn_confirmar" runat="server" Text="Confirmar" OnClick="btn_confirmar_Click" />
                            
                            <br />
                            <br />
                            <asp:Label ID="lbl_registar" runat="server"></asp:Label>
                            
                            <br />                         
                        </div>

                    </div>
                </div>


</div>
         </div>
</asp:Content>

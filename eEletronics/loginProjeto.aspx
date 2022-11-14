<%@ Page Title="" Language="C#" MasterPageFile="~/templateProjeto.Master" AutoEventWireup="true" CodeBehind="loginProjeto.aspx.cs" Inherits="eEletronics.loginProjeto" %>
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
                        <h2 class="footer-wid-title " >Login</h2>
                      
                        <div class="newsletter-forme">
                            
                            <asp:TextBox ID="tb_user" runat="server" type="text"  name="cf-name" placeholder=" Utilizador"  Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_user"></asp:RequiredFieldValidator>
                            <br />                         
                        </div>

                         <div class="newsletter-forme">
                             <asp:TextBox ID="tb_pw" runat="server" type="text"  name="cf-name" placeholder=" Palavra-passe"  Width="350px" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_pw" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                             <br />
                             <br />
                             <asp:Label ID="lbl_mensagem" runat="server" Visible="True" ForeColor="#CC0000"></asp:Label>
                        </div>

                         <div class="newsletter-form">                           
                             <asp:Button ID="btn_entrar" runat="server" Text="Entrar" OnClick="btn_entrar_Click" />
                        </div>

                        <a href="https://localhost:44319/esqueceu_pw.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%"><u>Forgot password?</u></a>
                    </div>
                </div>


</div>
         </div>

</asp:Content>

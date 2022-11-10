<%@ Page Title="" Language="C#" MasterPageFile="~/templateProjeto.Master" AutoEventWireup="true" CodeBehind="esqueceu_pw.aspx.cs" Inherits="eEletronics.esqueceu_pw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Reset password</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="footer-top-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="col text-center " style="margin-bottom: 10%">

                <div class="footer-newsletter">
                    <br />
                    <br />
                    <h2 class="footer-wid-title ">Insira seu email para recuperar a palavra-passe</h2>

                    <div class="newsletter-forme">

                        <asp:TextBox ID="tb_email" runat="server" type="text" name="cf-name" placeholder=" Your email " Width="350px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_email"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Lime" ControlToValidate="tb_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                    </div>



                    <div class="newsletter-form">
                        <asp:Button ID="btn_recuperar" runat="server" Text="Enviar email" OnClick="btn_recuperar_Click" />
                        <br />
                        <asp:Label ID="lbl_mensagem" runat="server" Visible="True" ForeColor="#CC0000"></asp:Label>

                    </div>

                </div>
            </div>

        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/templateUserNormal.Master" AutoEventWireup="true" CodeBehind="alterarPassUserNormal.aspx.cs" Inherits="eEletronics.alterarPassUserNormal" %>
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
                        <h2 class="footer-wid-title " >Alterar pw</h2>
                      
                        <div class="newsletter-forme">
                            
                            <asp:TextBox ID="tb_antiga" runat="server" type="text"  name="cf-name" placeholder=" Pw antiga"  Width="350px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_antiga"></asp:RequiredFieldValidator>
                            <br /> 

                            <asp:TextBox ID="tb_nova" runat="server" type="text"  name="cf-name" placeholder=" Pw nova"  Width="350px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tb_nova"></asp:RequiredFieldValidator>
                            <br />                         
                        </div>

                         <div class="newsletter-forme">
                        
                             <br />
                             <asp:Label ID="lbl_mensagem" runat="server" Visible="True" ForeColor="#CC0000"></asp:Label>
                        </div>

                         <div class="newsletter-form">  
                             <asp:Button ID="btn_enviar" runat="server" Text="Alterar" OnClick="btn_enviar_Click" />
                             
                        </div>

                        <a href="https://localhost:44319/esqueceu_pw.aspx?id=" class="border-bottom border-secondary text-decoration-none text-secondary" style="margin-top:2%"><u>Forgot password?</u></a>
                    </div>
                </div>


</div>
         </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/templateProjeto.Master" AutoEventWireup="true" CodeBehind="registoProjeto.aspx.cs" Inherits="eEletronics.registoProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-8">


                    <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                        <div id="customer_details" class="col2-set">
                            <div class="col-1">
                                <div class="woocommerce-billing-fields">

                                    <h3>Billing Details</h3>


                                    <p id="billing_first_name_field" class="form-row form-row-first validate-required">
                                        <label class="" for="billing_first_name">Utilizador<abbr title="required" class="required">*</abbr></label>
                                        <asp:TextBox ID="tb_user" runat="server" class="input-text "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_user" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </p>

                                    <p id="billing_last_name_field" class="form-row form-row-last validate-required">
                                        <label class="" for="billing_last_name">Palavra-passe<abbr title="required" class="required">*</abbr></label>
                                        <asp:TextBox ID="tb_pw" runat="server" class="input-text "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_pw" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </p>

                                    <asp:Label ID="lbl_resultado" runat="server" Visible="True"></asp:Label>

                                    <p id="billing_address_1_field" class="form-row form-row-wide address-field validate-required">
                                        <label class="" for="billing_address_1"> Morada <abbr title="required" class="required">*</abbr></label>                                        
                                        <asp:TextBox ID="tb_morada" runat="server" class="input-text " Height="29px" TextMode="MultiLine" Width="170px"></asp:TextBox>
                                    </p>

                                    <p id="billing_email_field" class="form-row form-row-first validate-required validate-email">
                                        <label class="" for="billing_email">Email<abbr title="required" class="required">*</abbr></label>
                                        <asp:TextBox ID="tb_email" runat="server" class="input-text "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_email" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="*" ForeColor="#00CC00" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </p>
                                    <p>
                                        &nbsp;
                                    </p>
                                    <p>
                                       
                                        <asp:Button ID="btn_registar" runat="server" Text="Registar" OnClick="btn_registar_Click" />
                                    
                                    </p>
                                    <p>
                                        &nbsp;
                                    </p>                                       
                                    <p>
                                        <asp:Label ID="lbl_mensagem" runat="server" Visible="False" ForeColor="#99CC00"></asp:Label>

                                    </p>
                                    <p>
                                        &nbsp;
                                    </p>
                                    <p>
                                        &nbsp;
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

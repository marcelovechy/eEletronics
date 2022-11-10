using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace eEletronics
{
    public partial class registoProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_registar_Click(object sender, EventArgs e)
        {
            Regex maiusculas = new Regex("[A-Z]");
            Regex minusculas = new Regex("[a-z]");
            Regex numeros = new Regex("[0-9]");
            Regex especiais = new Regex("[^A-Za-z0-9]");
            Regex plica = new Regex("'");


            if (tb_pw.Text.Length < 6)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }

            else if (maiusculas.Matches(tb_pw.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;


            }
            else if (minusculas.Matches(tb_pw.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (numeros.Matches(tb_pw.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (especiais.Matches(tb_pw.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (plica.Matches(tb_pw.Text).Count > 0)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else
            {
                lbl_resultado.Text = "Pw forte";
                // método replace para substituir o texto
                //tb_morada.Text.Replace(" ", "");
                lbl_resultado.Visible = true;

                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@nome", tb_user.Text);
                myCommand.Parameters.AddWithValue("@password", EncryptString(tb_pw.Text));
                myCommand.Parameters.AddWithValue("@morada", tb_morada.Text);
                myCommand.Parameters.AddWithValue("@email", tb_email.Text);

                

                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno"; 
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(valor);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "registo_user";

                myCommand.Connection = myCon;
                myCon.Open();
                myCommand.ExecuteNonQuery();

                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
                myCon.Close();

                lbl_mensagem.Visible = true;

                if (respostaSP == 0)
                {
                    lbl_mensagem.Text = "User já existe. Tente outro!!";
                }
                else
                {
                    lbl_mensagem.Text = "User inserido com sucesso!!";
                    envia_email();
                }
            }

        }
        public static string EncryptString(string Message)
        {
            string Passphrase = "atec";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string

            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("\\", "III");
            return enc;
        }
        public void envia_email()
        {


            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            try
            {
                mail.From = new MailAddress("agatha.vechy.t0121524@edu.atec.pt");
                mail.To.Add(new MailAddress(tb_email.Text));
                mail.Subject = "Ativação de conta";
                mail.IsBodyHtml = true;
                mail.Body = "Para ativar sua conta clique <a href='https://localhost:44319/ativacao_conta.aspx?id=" + EncryptString(tb_user.Text) + "'>aqui</a>";

                servidor.Host = "smtp.office365.com";
                servidor.Port = 587;

                servidor.Credentials = new NetworkCredential
                    ("agatha.vechy.t0121524@edu.atec.pt", "Am190513@");

                servidor.EnableSsl = true;
                servidor.Send(mail);



            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
    }
}
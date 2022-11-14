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
    public partial class esqueceu_pw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            envia_email();
        }

        protected void btn_recuperar_Click(object sender, EventArgs e)
        {

        }
        public void envia_email()
        {


            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            try
            {
                mail.From = new MailAddress("");
                mail.To.Add(new MailAddress(tb_email.Text));
                mail.Subject = "Ativação de conta";
                mail.IsBodyHtml = true;
                mail.Body = "Para alterar a vossa palavra-passe clique <a href='https://localhost:44319/recuperar_pw.aspx?id=" + EncryptString(tb_email.Text) + "'>aqui</a>";

                servidor.Host = "smtp.office365.com";
                servidor.Port = 587;

                servidor.Credentials = new NetworkCredential
                    ("");

                servidor.EnableSsl = true;
                servidor.Send(mail);



                lbl_mensagem.Text = "Mensagem enviada com sucesso para o seu email";



            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
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
    }

}
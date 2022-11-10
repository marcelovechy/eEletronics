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
    public partial class recuperar_pw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = DecryptString(Request.QueryString["id"]);

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@email", email);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "email";

            myCommand.Connection = myCon;
            myCon.Open();

            SqlDataReader dr = myCommand.ExecuteReader();

            while (dr.Read())
            {
                lbl_email.Text = dr["email"].ToString();
            }



            myCon.Close();


            myCon.Close();
        }
        public static string DecryptString(string Message)
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

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]

            Message = Message.Replace("KKK", "+");
            Message = Message.Replace("JJJ", "/");
            Message = Message.Replace("III", "\\");

            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
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

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            Regex maiusculas = new Regex("[A-Z]");
            Regex minusculas = new Regex("[a-z]");
            Regex numeros = new Regex("[0-9]");
            Regex especiais = new Regex("[^A-Za-z0-9]");
            Regex plica = new Regex("'");


            if (tb_novaPasse.Text.Length < 6)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }

            else if (maiusculas.Matches(tb_novaPasse.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;


            }
            else if (minusculas.Matches(tb_novaPasse.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (numeros.Matches(tb_novaPasse.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (especiais.Matches(tb_novaPasse.Text).Count < 1)
            {
                lbl_resultado.Text = "Pw fraca";
                lbl_resultado.Visible = true;

            }
            else if (plica.Matches(tb_novaPasse.Text).Count > 0)
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

                    myCommand.Parameters.AddWithValue("@email", lbl_email.Text);
                    myCommand.Parameters.AddWithValue("@pw_nova", EncryptString(tb_novaPasse.Text));

                    SqlParameter valor = new SqlParameter();
                    valor.ParameterName = "@retorno";
                    valor.Direction = ParameterDirection.Output;
                    valor.SqlDbType = SqlDbType.Int;
                    myCommand.Parameters.Add(valor);


                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "recuperar_pw";

                    myCommand.Connection = myCon;
                    myCon.Open();
                    myCommand.ExecuteNonQuery();
                    int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                    myCon.Close();

                    if (respostaSP == 0)
                    {
                        lbl_registar.Visible = true;
                        lbl_registar.Text = "Erro.";
                    }
                    else if (respostaSP == 2)
                    {
                        lbl_registar.Visible = true;
                        lbl_registar.Text = "Palavra-Passe Nova não pode ser igual a Palavra-Passe Antiga.";
                    }
                    else if (respostaSP == 1)
                    {
                        lbl_registar.Visible = true;
                        lbl_registar.Text = "Palavra-Passe registada com Sucesso!!!";
                    }

                
            }
        }
    }
}
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

namespace eEletronics
{
    public partial class alterarPassAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@utilizador", Session["utilizador"]);

            myCommand.Parameters.AddWithValue("@pw_antiga", EncryptString(tb_antiga.Text));
            myCommand.Parameters.AddWithValue("@pw_nova", EncryptString(tb_nova.Text));

            //devolver se o utilizador foi inserido ou nao com 0 e 1
            //variavel de rertono para saber se pode entrar ou nao

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno"; // permiter de output
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(valor);



            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "alterar_pw";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            // o que for devolvido pra retorno converte em inteiro e guarda aqui
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
            // o que for devolvido pra retorno_perfil converte em string e guarda aqui

            myCon.Close();



            if (respostaSP == 0)
            {
                lbl_mensagem.Text = "Palavra passe errada !";
            }
            else
            {
                lbl_mensagem.Text = "Palavra Passe alterada com sucesso !";
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
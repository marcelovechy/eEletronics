using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eEletronics
{
    public partial class loginProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["eEletronicsConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Parameters.AddWithValue("@user", tb_user.Text);           
            myCommand.Parameters.AddWithValue("@password", EncryptString(tb_pw.Text));

            
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno"; // permiter de output
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(valor);

            
            SqlParameter valor2 = new SqlParameter();
            valor2.ParameterName = "@retorno_perfil"; 
            valor2.Direction = ParameterDirection.Output;
            valor2.SqlDbType = SqlDbType.VarChar;
            valor2.Size = 20;
            myCommand.Parameters.Add(valor2);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "login";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
           
            string perfil = myCommand.Parameters["@retorno_perfil"].Value.ToString();
            myCon.Close();



            if (respostaSP == 0)
            {
                lbl_mensagem.Text = "User ou password errados!!";
            }
            else if (respostaSP == 2)
            {
                lbl_mensagem.Text = "User inativo!";
            }

            else
            {
                Session["perfil"] = perfil; 
                Session["user"] = tb_user.Text;

                if (perfil == "Administrador")
                {
                    Response.Redirect("homeAdmin.aspx");
                }
                else if (perfil == "Revenda")
                {
                    Response.Redirect("homeUserNormal.aspx");
                }
                else
                {
                    Response.Redirect("homeUserRevenda.aspx");
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
    }
}
    


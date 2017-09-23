using Google.Authenticator;
using System;
using System.Configuration;

namespace _2FactAuthDotNet
{
    public partial class Validate : System.Web.UI.Page
    {
        /// <summary>
        /// Generate Key
        /// </summary>
        public string Key
        {
            get
            {
                string strQrKey = string.Empty;
                if (ConfigurationManager.AppSettings.Get("QRKey") != null)
                {
                    strQrKey = ConfigurationManager.AppSettings.Get("QRKey").ToString();
                }
                return strQrKey;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Verify();
        }
        /// <summary>
        /// Verify key
        /// </summary>
        public void Verify()
        {
            string user_enter = txtQR.Text;
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string strCurrentPin = tfa.GetCurrentPIN(Key + Session["user"].ToString());
            if (strCurrentPin.Equals(user_enter))
            {
                lblResponse.Text = "Success";
            }
            else
            {
                lblResponse.Text = "Failure current key used is "+ strCurrentPin;
            }
        }
    }
}
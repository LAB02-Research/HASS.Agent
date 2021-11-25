using Syncfusion.Windows.Forms;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Windows.Forms;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
namespace HASSAgent.Forms
{
    public partial class GetUserCredentials : MetroForm
    {
        internal string Username { get; } = Environment.UserName;
        internal SecureString Password { get; } = new SecureString();

        public GetUserCredentials()
        {
            InitializeComponent();
        }

        private void GetUserCredentials_Load(object sender, EventArgs e)
        {
            TbUsername.Text = Username;
            ActiveControl = TbPassword;
        }

        /// <summary>
        /// Check and store the entered values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // check values
            var username = TbUsername.Text.Trim();
            var password = TbPassword.Text.Trim();
            
            if (string.IsNullOrEmpty(username))
            {
                MessageBoxAdv.Show("Please enter a username.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbUsername;
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBoxAdv.Show("Please enter a password.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ActiveControl = TbPassword;
                return;
            }

            // clear our textbox
            TbPassword.Text = "*********";

            // process password
            foreach (var c in password) Password.AppendChar(c);
            Password.MakeReadOnly();

            // clear our string
            password = null;


            // done
            DialogResult = DialogResult.OK;
        }
    }
}
#pragma warning restore IDE0059 // Unnecessary assignment of a value

namespace HASSAgent.Controls.Onboarding
{
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            TbDeviceName.Text = Variables.AppSettings.DeviceName;
            ActiveControl = TbDeviceName;
        }

        internal bool Store()
        {
            Variables.AppSettings.DeviceName = TbDeviceName.Text;
            return true;
        }
    }
}

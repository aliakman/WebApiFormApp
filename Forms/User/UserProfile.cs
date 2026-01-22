using System.Windows.Forms;
using WebApiFormApp.Services;
using WebApiFormApp.Statics;

namespace WebApiFormApp.Forms.User
{
    public class UserProfile
    {
        private TextBox _txtId;
        private TextBox _txtFN;
        private TextBox _txtLN;
        private TextBox _txtUN;
        private TextBox _txtEmail;
        private TextBox _txtPw;
        private ComboBox _cmbRoles;

        public void SetProfile(TextBox txtID, TextBox txtFN, TextBox txtLN, TextBox txtUN, TextBox txtEmail, TextBox txtPw, ComboBox cmbRoles)
        {
            _txtId = txtID;
            _txtFN = txtFN;
            _txtLN = txtLN;
            _txtUN = txtUN;
            _txtEmail = txtEmail;
            _txtPw = txtPw;

            cmbRoles.Items.Clear();
            _cmbRoles = cmbRoles;

            SetInfos();
        }

        private void SetInfos()
        {

        }

    }
}

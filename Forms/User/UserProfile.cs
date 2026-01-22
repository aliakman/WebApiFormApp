using System.Windows.Forms;
using WebApiFormApp.Services;
using WebApiFormApp.Statics;

namespace WebApiFormApp.Forms.User
{
    public class UserProfile
    {
        private IApiService _apiService;

        private TextBox _txtId;
        private TextBox _txtFN;
        private TextBox _txtLN;
        private TextBox _txtUN;
        private TextBox _txtEmail;
        private TextBox _txtPw;
        private ComboBox _cmbRoles;

        public void SetProfile(IApiService apiService, TextBox txtID, TextBox txtFN, TextBox txtLN, TextBox txtUN, TextBox txtEmail, TextBox txtPw, ComboBox cmbRoles)
        {
            _apiService = apiService;

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
            //string id = "9f30e046-601e-41b4-933e-0282d8c3065d";
            //Info.SetID(Guid.Parse(id));
            //var user = _apiService.GetUserByIdAsync(Info.ID).Result;
            //_txtId.Text = user.Id.ToString();
            //_txtFN.Text = user.FirstName.ToString();
            //_txtLN.Text = user.LastName.ToString();
            //_txtUN.Text = user.UserName.ToString();
            //_txtEmail.Text = user.Email.ToString();
            //_txtPw.Text = string.Empty;
            //_cmbRoles.Items.AddRange(user.Roles.ToArray());
        }

    }
}

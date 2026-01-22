using WebApiFormApp.Forms.User;
using WebApiFormApp.Services;
//using WebApiFormApp.Models;
//using WebApiFormApp.Services;

namespace WebApiFormApp
{
    public partial class UserSettingsForm : Form
    {
        //protected readonly IApiService _apiService;
        private readonly AuthService _authService;
        private List<Panel> _panels = new();

        private UserProfile _userProfile  = new UserProfile();

        public UserSettingsForm(/*IApiService apiService,*/ AuthService authService)
        {
            InitializeComponent();
            //_apiService = apiService;
            //_userProfile.SetProfile(_apiService, txtIDProfile, txtFNProfile, txtLNProfile, txtUNProfile, txtEmailProfile, txtPwProfile, cmbRolesProfile);
            _authService = authService;
        }

        public virtual void UserSettingsForm_Load(object sender, EventArgs e)
        {
            _panels.Add(pnlProfile);
            _panels.Add(pnlUser);
            _panels.Add(pnlRole);
        }

        #region Forms Panel Buttons
        private void btnProfile_Click(object sender, EventArgs e)
        {
            SetPanels(pnlProfile);
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            SetPanels(pnlUser);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            SetPanels(pnlRole);
        }
        private void SetPanels(Panel activePanel)
        {
            activePanel.Visible = true;

            for (int i = 0; i < _panels.Count; i++)
            {
                if (_panels[i] == activePanel)
                    continue;
                _panels[i].Visible = false;
            }
        }
        #endregion

        private async void btnSaveChangeProfile_Click(object sender, EventArgs e)
        {
            UpdateUser(txtIDProfile.Text, txtFNProfile.Text, txtLNProfile.Text, txtUNProfile.Text);
        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            UpdateUser(txtIDUserUp.Text, txtFNUserUp.Text, txtLNUserUp.Text, txtUNUserUp.Text);
        }

        private async void UpdateUser(string Id = "", string FN = "", string LN = "", string UN = "")
        {
            //var updatedUser = new UserUpdateRequest(UserID: new Guid(Id), FirstName: FN, LastName: LN);

            //var user = await _apiService.GetUserByUsernameAsync(txtUNUserCreate.Text);
            //if (user is null)
            //{
            //    MessageBox.Show("Güncelleme sırasında bir hata oluştu.");
            //    return;
            //}

            //var success = await _apiService.UpdateUserAsync(UN, updatedUser);

            //if (success)
            //{
            //    MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
            //    bool rolesUpdated = await UpdateUserRole(user);
            //    if (!rolesUpdated)
            //        MessageBox.Show("Güncelleme başarılı ancak ilgili rol(ler) güncellenemedi.");
            //}
            //else
            //{
            //    MessageBox.Show("Güncelleme sırasında bir hata oluştu.");
            //}
        }

        private async void btnUserCreate_Click(object sender, EventArgs e)
        {
            //var newUser = new UserCreateRequest(
            //    FirstName: txtFNUserCreate.Text,
            //    LastName: txtLNUserCreate.Text,
            //    UserName: txtUNUserCreate.Text,
            //    Email: txtEmailUserCreate.Text.Trim(),
            //    Password: txtPwUserCreate.Text
            //);

            //var user = await _apiService.GetUserByUsernameAsync(txtUNUserCreate.Text);
            //if (user is null)
            //{
            //    MessageBox.Show("Kayıt sırasında bir hata oluştu.");
            //    return;
            //}

            //var success = await _apiService.RegisterAsync(newUser);

            //if (success)
            //{
            //    MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
            //    bool rolesAdded = await AddRoleToUser(user);
            //    if (!rolesAdded)
            //        MessageBox.Show("Kayıt başarılı ancak ilgili rol(ler) eklenemedi.");
            //}
            //else
            //{
            //    MessageBox.Show("Kayıt sırasında bir hata oluştu.");
            //}
        }

        //private async Task<bool> AddRoleToUser(UserDto user)
        //{
        //    var userRoles = await _apiService.GetUserRolesByIdAsync(new Guid(user.Id.ToString()));
        //    List<string> roleNames = new List<string>();

        //    for (int i = 0; i < userRoles.Count; i++)
        //        roleNames.Add(userRoles[i].Name.Value);

        //    int Selected = -1;
        //    int count = cmbRolesUserCreate.Items.Count;
        //    for (int i = 0; (i <= (count - 1)); i++)
        //    {
        //        cmbRolesUserCreate.SelectedIndex = i;
        //        if (roleNames.Contains((string)cmbRolesUserCreate.SelectedItem))
        //            continue;

        //        var roleAttendedSuccess = await _apiService.AddRoleToUserAsync(txtUNUserCreate.Text, (string)cmbRolesUserCreate.SelectedItem);
        //        Selected = i;
        //        if (!roleAttendedSuccess)
        //            return false;
        //    }
        //    return true;
        //}

        //private async Task<bool> UpdateUserRole(UserDto user)
        //{
        //    var userRoles = await _apiService.GetUserRolesByIdAsync(new Guid(user.Id.ToString()));
        //    List<string> roleNames = new List<string>();

        //    for (int i = 0; i < userRoles.Count; i++)
        //        roleNames.Add(userRoles[i].Name.Value);

        //    int Selected = -1;
        //    int count = cmbRolesUserUp.Items.Count;
        //    for (int i = 0; (i <= (count - 1)); i++)
        //    {
        //        cmbRolesUserUp.SelectedIndex = i;
        //        if (roleNames.Contains((string)cmbRolesUserUp.SelectedItem))
        //            continue;

        //        var roleProcessHandled = await _apiService.AddRoleToUserAsync(txtUNUserCreate.Text, (string)cmbRolesUserUp.SelectedItem);
        //        Selected = i;
        //        if (!roleProcessHandled)
        //            return false;
        //    }
        //    return true;
        //}

        private void btnRoleUpdate_Click(object sender, EventArgs e)
        {

        }

        public bool WantToLogout { get; private set; } = false;
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            bool success = await _authService.Logout();

            if (success)
            {
                WantToLogout = true;
                this.Close();
            }
        }
    }
}

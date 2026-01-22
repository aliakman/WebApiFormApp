using WebApiFormApp.Forms.User;
using WebApiFormApp.Services;

namespace WebApiFormApp
{
    public partial class UserSettingsForm : Form
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        private List<Panel> _panels = new();

        public UserSettingsForm(AuthService authService, UserService userService, RoleService roleService)
        {
            InitializeComponent();
            _authService = authService;
            _userService = userService;
            _roleService = roleService;
        }

        public virtual void UserSettingsForm_Load(object sender, EventArgs e)
        {
            _panels.Add(pnlProfile);
            _panels.Add(pnlUser);
            _panels.Add(pnlRole);
        }

        #region Forms Panel Buttons
        private async void btnProfile_Click(object sender, EventArgs e)
        {
            SetPanels(pnlProfile);

            var user = await _userService.GetMyProfile();

            if (user != null)
            {
                txtIDProfile.Text = user.Id.ToString();
                txtUNProfile.Text = user.Username;
                
                txtFNProfile.Text = user.FirstName;
                txtLNProfile.Text = user.LastName;
                
                txtEmailProfile.Text = user.Email;
                txtPwProfile.Text = "********";

                cmbRolesProfile.Items.Clear();
                for (int i = 0; i < user.Roles.Count; i++)
                    cmbRolesProfile.Items.Add(user.Roles[i].Name);
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı veya yetkiniz yok.");
            }
        }
        private async void btnUsers_Click(object sender, EventArgs e)
        {
            SetPanels(pnlUser);

            var users = await _userService.GetAllUsersAsync();

            if (users != null && users.Count > 0)
            {
                dgvUsers.DataSource = users;
            }
            else
            {
                MessageBox.Show("Kullanıcılar bulunamadı veya yetkiniz yok.");
            }
        }

        private async void btnRoles_Click(object sender, EventArgs e)
        {
            SetPanels(pnlRole);

            var roles = await _roleService.GetAllRolesAsync();

            if (roles != null && roles.Count > 0)
            {
                dgvRoles.DataSource = roles;
            }
            else
            {
                MessageBox.Show("Roller bulunamadı veya yetkiniz yok.");
            }

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

        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {

        }

        private async void btnUserCreate_Click(object sender, EventArgs e)
        {
            
        }
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

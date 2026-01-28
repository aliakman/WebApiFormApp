using WebApiFormApp.Models;
using WebApiFormApp.Services;

namespace WebApiFormApp
{
    public partial class LoginRegisterForm : Form
    {

        private readonly AuthService _authService;
        private readonly UserService _userService;

        public LoginRegisterForm(AuthService authService, UserService userService)
        {
            InitializeComponent();
            _authService = authService;
            _userService = userService;
        }

        private void SetPanels(bool isLoginActive)
        {
            pnlLogin.Visible = isLoginActive;
            pnlReg.Visible = !isLoginActive;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Lütfen alanları doldurun.");
                return;
            }

            var success = await _authService.LoginAsync(txtEmail.Text, txtPassword.Text);

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Giriş başarısız! Lütfen bilgilerinizi kontrol edin.");
            }
        }

        private void txtPassword_TextChange(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = string.IsNullOrEmpty(txtPassword.Text) ? '\0' : '*';
        }

        private void LoginRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnToReg_Click(object sender, EventArgs e)
        {
            SetPanels(false);
        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            SetPanels(true);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtRegLastName.Text) ||
                string.IsNullOrWhiteSpace(txtRegUserName.Text) ||
                string.IsNullOrWhiteSpace(txtRegEmail.Text) ||
                txtRegPw.Text.Length < 6)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve şifrenin en az 6 karakter olduğundan emin olun.");
                return;
            }

            var newUser = new UserDto();
            newUser.FirstName = txtRegFirstName.Text;
            newUser.LastName = txtRegLastName.Text;
            newUser.Username = txtRegUserName.Text;
            newUser.Email = txtRegEmail.Text.Trim();
            newUser.Password = txtRegPw.Text.Trim();

            var success = await _userService.CreateUserAsync(newUser);

            if (success)
            {
                MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
                SetPanels(true);
            }
            else
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu.");
            }
        }
    }
}

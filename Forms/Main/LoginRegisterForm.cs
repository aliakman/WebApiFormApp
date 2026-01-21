using WebApiFormApp.Models;
using WebApiFormApp.Services;
using WebApiFormApp.Statics;

namespace WebApiFormApp
{
    public partial class LoginRegisterForm : Form
    {

        private readonly IApiService _apiService;

        public LoginRegisterForm(IApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Lütfen alanları doldurun.");
                return;
            }

            // 2. API'ye giriş isteği gönder
            var success = await _apiService.LoginAsync(txtEmail.Text, txtPassword.Text);

            if (success)
            {
                var users = await _apiService.GetUsersAsync();
                foreach (var user in users)
                {
                    if (user.Email.ToString() == txtEmail.Text)
                    {
                        Info.SetID(new Guid(user.Id.ToString()));
                        break;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Giriş başarısız! Lütfen bilgilerinizi kontrol edin.");
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtRegLastName.Text) ||
                string.IsNullOrWhiteSpace(txtRegUserName.Text) ||
                string.IsNullOrWhiteSpace(txtRegEmail.Text) ||
                txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve şifrenin en az 6 karakter olduğundan emin olun.");
                return;
            }

            var newUser = new UserCreateRequest(
                FirstName: txtRegFirstName.Text,
                LastName: txtRegLastName.Text,
                UserName: txtRegUserName.Text,
                Email: txtEmail.Text.Trim(),
                Password: txtPassword.Text
            );

            var success = await _apiService.RegisterAsync(newUser);

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

        private void btnToReg_Click(object sender, EventArgs e)
        {
            SetPanels(false);
        }
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            SetPanels(true);
        }

        private void SetPanels(bool isLoginActive)
        {
            pnlLogin.Visible = isLoginActive;
            pnlReg.Visible = !isLoginActive;
        }
    }
}

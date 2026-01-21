using WebApiFormApp.Models;
using WebApiFormApp.Services;

namespace WebApiFormApp;

public partial class RegisterForm : Form
{
    private readonly IApiService _apiService;

    public RegisterForm(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void btnSubmit_Click(object sender, EventArgs e)
    {
        // Senin yazdığın validation (doğrulama) mantığını buraya taşıyoruz
        if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
            string.IsNullOrWhiteSpace(txtLastName.Text) ||
            string.IsNullOrWhiteSpace(txtUserName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            txtPassword.Text.Length < 6)
        {
            MessageBox.Show("Lütfen tüm alanları doldurun ve şifrenin en az 6 karakter olduğundan emin olun.");
            return;
        }

        var newUser = new UserCreateRequest(
            FirstName: txtFirstName.Text,
            LastName: txtLastName.Text,
            UserName: txtUserName.Text,
            Email: txtEmail.Text.Trim(),
            Password: txtPassword.Text
        );

        var success = await _apiService.RegisterAsync(newUser);

        if (success)
        {
            MessageBox.Show("Kayıt başarılı! Giriş ekranına yönlendiriliyorsunuz.");
            this.Close(); // Kayıt başarılıysa formu kapatıp login'e döner
        }
        else
        {
            MessageBox.Show("Kayıt sırasında bir hata oluştu.");
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.Close();
}
using Microsoft.Extensions.DependencyInjection;
using WebApiFormApp.Services;
using WebApiFormApp.Statics;

namespace WebApiFormApp;

public partial class LoginForm : Form
{
    private readonly IApiService _apiService;

    // Dependency Injection ile servisi alıyoruz
    public LoginForm(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        // 1. Önce kontrolleri yap
        if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            MessageBox.Show("Lütfen alanları doldurun.");
            return;
        }

        // 2. API'ye giriş isteği gönder
        var success = await _apiService.LoginAsync(txtEmail.Text, txtPassword.Text);

        if (success)
        {
            // --- İŞTE BURAYA YAZILIYOR ---
            this.DialogResult = DialogResult.OK; // Program.cs'e "geçebilirsin" mesajı gönderir
            this.Close();                         // Login formunu kapatır
        }
        else
        {
            // Başarısızsa formu kapatma, hata mesajı ver
            MessageBox.Show("Giriş başarısız! Lütfen bilgilerinizi kontrol edin.");
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        // RegisterForm'u DI üzerinden (Program.cs sayesinde) alıyoruz
        // Not: Program.cs'te RegisterForm'u servislere eklemeyi unutma!
        MessageBox.Show("Kayıt ol formu açılıyor...");
        var registerForm = Program.ServiceProvider.GetRequiredService<RegisterForm>();
        // Login formunu gizle ve register formunu aç
        this.Hide();
        registerForm.ShowDialog();
        this.Show(); // Register formu kapandığında login tekrar görünür
    }

    private void btnEnable(bool status)
    {
        btnLogin.Enabled = status;
    }
}
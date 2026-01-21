using Microsoft.VisualBasic;
using WebApiFormApp.Models;
using WebApiFormApp.Services;

namespace WebApiFormApp;

public partial class MainForm : Form
{
    private readonly IApiService _apiService;
    public bool WantToLogout { get; private set; } = false;

    public MainForm(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void MainForm_Load(object sender, EventArgs e) => await RefreshUserList();

    private async Task RefreshUserList()
    {
        dgvUsers.DataSource = null;
        dgvUsers.DataSource = await _apiService.GetUsersAsync();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        _apiService.Logout();
        WantToLogout = true;
        this.Close();
    }

    private async void btnUserDelete_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow?.DataBoundItem is UserDto user)
        {
            if (MessageBox.Show($"{user.UserName} silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _apiService.DeleteUserAsync(user.UserName.ToString())) await RefreshUserList();
            }
        }
    }

    private async void btnAddRoleToUser_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow?.DataBoundItem is UserDto user)
        {
            string role = Interaction.InputBox("Rol Adý:", "Rol Ekle");
            if (!string.IsNullOrEmpty(role) && await _apiService.AddRoleToUserAsync(user.UserName.ToString(), role))
                await RefreshUserList();
        }
    }

    private async void btnUserUpdate_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow?.DataBoundItem is UserDto user)
        {
            // Kullanýcýdan yeni bilgileri alýyoruz
            string newEmail = Interaction.InputBox("Yeni Email:", "Güncelle", user.Email.ToString());
            string newFirstName = Interaction.InputBox("Yeni Ad:", "Güncelle", user.FirstName.ToString());
            string newLastName = Interaction.InputBox("Yeni Soyad:", "Güncelle", user.LastName.ToString());

            if (!string.IsNullOrEmpty(newEmail))
            {
                // Request nesnesini oluþturuyoruz
                //var request = new UserUpdateRequest(newFirstName, newLastName, newEmail);

                // Ýki parametre gönderiyoruz: 1. UserName (URL için), 2. Request Body
                //var success = await _apiService.UpdateUserAsync(user.UserName, request);

                //if (success)
                //{
                //    MessageBox.Show("Kullanýcý baþarýyla güncellendi.");
                //    await RefreshUserList();
                //}
                //else
                //{
                //    MessageBox.Show("Güncelleme sýrasýnda bir hata oluþtu.");
                //}
            }
        }
    }
}
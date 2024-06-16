namespace cguambaS2.vistas;

public partial class Login : ContentPage
{
    string[] users = { "Carlos", "Ana", "Jose" };
    string[] passwords = { "carlos123", "ana123", "jose123" };

    public Login()
	{
		InitializeComponent();
	}


    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        string txtUsuario = this.txtUsuario.Text;
        string txtPassword = this.txtPassword.Text;

        if (users.Contains(txtUsuario))
        {
            int userIndex = Array.IndexOf(users, txtUsuario);

            if (passwords.Contains(txtPassword) && passwords[userIndex].Equals(txtPassword))
            {
                Navigation.PushAsync(new vPrincipal(txtUsuario));
            }
            else
            {
                DisplayAlert("Alerta", "Contraseña ingresada incorrecta", "OK");
            }

        }
        else
        {
            DisplayAlert("Alerta", "El usuario ingresado no está registrado", "OK");            
        }
    }

}
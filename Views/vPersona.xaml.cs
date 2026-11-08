using eClavijoA.Models;

namespace eClavijoA.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> personas = App._personRepo.GetAllPersonas();
        listaPersonas.ItemsSource = personas;

    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMensaje.Text = "";

        App._personRepo.AddNewPerson(txtNombre.Text);

        lblStatusMensaje.Text = App._personRepo.StatusMessage;

        txtNombre.Text = "";

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtIdEliminar.Text, out int id))
        {
            App._personRepo.DeletePerson(id);

            lblStatusMensaje.Text = App._personRepo.StatusMessage;

            listaPersonas.ItemsSource =
                App._personRepo.GetAllPersonas();
        }
        else
        {
            lblStatusMensaje.Text = "Ingrese un ID válido";
        }

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(txtIdActualizar.Text, out int id))
        {
            App._personRepo.UpdatePerson(
                id,
                txtNuevoNombre.Text);

            lblStatusMensaje.Text =
                App._personRepo.StatusMessage;

            listaPersonas.ItemsSource =
                App._personRepo.GetAllPersonas();

            txtIdActualizar.Text = "";
            txtNuevoNombre.Text = "";
        }
        else
        {
            lblStatusMensaje.Text =
                "Ingrese un ID válido";
        }

    }
}
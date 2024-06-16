namespace cguambaS2.vistas;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

	public vPrincipal(string user)
	{
		InitializeComponent();
        lblNombre.Text = $"Bienvenido {user}!";
    }

    private void BtnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            ValidarCampos();

            string estudiante = pkEstudiantes.SelectedItem?.ToString();
            double numSegP1 = ObtieneDoubleYValidaEntradaNumerica(txtNumSegP1);
            double numExamP1 = ObtieneDoubleYValidaEntradaNumerica(txtNumExamP1);
            double numSegP2 = ObtieneDoubleYValidaEntradaNumerica(txtNumSegP2);
            double numExamP2 = ObtieneDoubleYValidaEntradaNumerica(txtNumExamP2);
            string fechaRegistro = dpFecha.Date.ToShortDateString();        

            double notaParcial1 = CalculaProporcion(numSegP1, numExamP1);
            double notaParcial2 = CalculaProporcion(numSegP2, numExamP2);

            double final = notaParcial1 + notaParcial2;

            lblNotaParcial1.Text = $"Nota Parcial (1): {notaParcial1}";
            lblNotaParcial2.Text = $"Nota Parcial (2): {notaParcial2}";
            lblNotaFinal.Text = $"Nota Final: {final}";

            string estado = EvaluaEstado(final);

            string mensaje = $@"
                    Bienvenido
                    Este es el detalle del registro para el estudiante: {estudiante}
                    Nota Seguimiento 1: {numSegP1}
                    Nota Examen 1: {numExamP1}
                    Nota Parcial 1: {notaParcial1}
                    
                    Nota Seguimiento 2: {numSegP2}
                    Nota Examen 2: {numExamP2}
                    Nota Parcial 2: {notaParcial2}
                    
                    NOTA FINAL: {final}
                    Estado estudiante: {estado}
                    
                    Fecha del registro: {fechaRegistro}";

            DisplayAlert("MENSAJE DE BIENVENIDA", mensaje, "OK");
        } catch (Exception ex) {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private string EvaluaEstado(double final)
    {
        if (final >= 7)
        {
            return "APROBADO";
        }
        else if (final >= 5 && final < 7)
        {
            return "COMPLEMENTARIO";
        }
        else
        {
            return "REPROBADO";
        }

    }

    private double CalculaProporcion(double numSeg, double numExam)
    {
        return Math.Round( (numSeg*0.2) + (numExam*0.3) , 2);
    }

    private double ObtieneDoubleYValidaEntradaNumerica(Entry txtEntry)
    {
        if (string.IsNullOrWhiteSpace(txtEntry.Text))
        {
            txtEntry.Focus();
            throw new Exception("Campo es obligatorio");
        }
        double valor;
        try
        {
            valor = Convert.ToDouble(txtEntry.Text);            
        }
        catch (Exception ex)
        {
            txtEntry.Focus();
            throw new Exception($"Error con el campo numérico (Entero con decimales separado por coma), " +
                $"por favor corrija el valor y vuelva a intentar. {ex.Message}");
        }
        if (valor > 10)
        {
            txtEntry.Focus();
            throw new Exception("El valor no puede ser mayor a 10");
        }
        
        return valor;
    }

    private void ValidarCampos()
    {

        if (pkEstudiantes.SelectedItem == null || string.IsNullOrWhiteSpace(pkEstudiantes.SelectedItem.ToString()))
        {
            pkEstudiantes.Focus();
            throw new Exception("Por favor seleccione un estudiante.");
        }

    }
}
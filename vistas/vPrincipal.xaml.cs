namespace cguambaS2.vistas;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void BtnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            ValidarCampos();

            string estudiante = pkEstudiantes.SelectedItem.ToString();
            double numSegP1 = ObtieneDoubleYValidaEntradaNumerica(txtNumSegP1);
            double numExamP1 = ObtieneDoubleYValidaEntradaNumerica(txtNumExamP1);
            double numSegP2 = ObtieneDoubleYValidaEntradaNumerica(txtNumSegP2);
            double numExamP2 = ObtieneDoubleYValidaEntradaNumerica(txtNumExamP2);
            string fechaRegistro = dpFecha.Date.ToShortDateString();        

            double notaParcial1 = CalculaProporcion(numSegP1, numExamP1);
            double notaParcial2 = CalculaProporcion(numSegP2, numExamP2);

            double final = notaParcial1 + notaParcial2;

            lblNotaParcial1.Text = "Nota Parcial (1): " + notaParcial1.ToString();
            lblNotaParcial2.Text = "Nota Parcial (2): " + notaParcial2.ToString();
            lblNotaFinal.Text = "Nota Final: " + final.ToString();

            string estado = EvaluaEstado(final);

            DisplayAlert("MENSAJE DE BIENVENIDA",
                "Bienvenido " +
                "\nEste es el detalle del registro para el estudiante: " + estudiante+
                "\nNota Seguimiento 1:\t" + numSegP1+
                "\nNota Examen 1:\t\t" + numExamP1 +
                "\nNota Parcial 1:\t\t" + notaParcial1 +
                "\n\nNota Seguimiento 2:\t" + numSegP2+
                "\nNota Examen 2:\t\t" + numExamP2 +
                "\nNota Parcial 2:\t\t" + notaParcial2 +
                "\n\nNOTA FINAL 2:\t" + final +
                "\nEstado estudiante:\t\t" + estado+
                "\n\nFecha del registro:\t" + fechaRegistro, "OK");
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
        double valor;
        try
        {
            valor = Convert.ToDouble(txtEntry.Text);            
        }
        catch (Exception ex)
        {
            txtEntry.Focus();
            throw new Exception("Error con el campo númerico (Entero con decimales separado por coma), " +
                "por favor corrija el valor y vuelva a intentar. "+ex.Message.ToString());
        }
        if (valor > 10)
        {
            txtEntry.Focus();
            throw new Exception("El valor no puede ser mayor a 10");
        }
        if (string.IsNullOrWhiteSpace(txtEntry.Text))
        {
            txtEntry.Focus();
            throw new Exception("Campo es obligatorio");
        }
        return valor;
    }

    private void ValidarCampos()
    {

        try
        {
            if (string.IsNullOrWhiteSpace(pkEstudiantes.SelectedItem.ToString()))
            {
                pkEstudiantes.Focus();
                throw new Exception("Por favor elija un estudiante.");
            }
        }
        catch (Exception ex)
        {
            pkEstudiantes.Focus();
            throw new Exception("Por favor seleccione un estudiante." + ex.Message.ToString());
        }

    }
}
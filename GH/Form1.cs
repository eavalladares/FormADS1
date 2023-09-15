namespace Ventas
{
    //EDWIN ALEXANDER VALLADARES CASTRO 
    //#025123
    //MATERIA: Analisis y Diseño de Sistemas 
    //Ing. Jose Sanchez
    public partial class Form1 : Form
    {
        double precio = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToString("d");
            lblPrecio.Text = (0).ToString("c");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (cboProductos.SelectedIndex == -1)
                MessageBox.Show("Selecciona producto");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Ingresa cantidad");
            else if (cboTipo.SelectedIndex == -1)
                MessageBox.Show("Selecciona tipo de pago");
            else
            {
                string producto = cboProductos.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                string tipo = cboTipo.Text;
                string vendedor = cboVendedor.Text;
                string cliente = txtNombreCliente.Text;

                double subtotal = cantidad * precio;

                double descuento = 0, recargo = 0;
                if (tipo.Equals("Efectivo"))
                    descuento = subtotal * 0.05;
                else
                    recargo = subtotal * 0.1;
                double precioFinal = subtotal - descuento + recargo;


                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());

                fila.SubItems.Add(vendedor.ToString());
                fila.SubItems.Add(cliente.ToString());

                lvVenta.Items.Add(fila);
                button3_Click(sender, e);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;
            if (producto.Equals("Combo de 24 Tacos")) precio = 20.99;
            if (producto.Equals("Torta Mixta #1")) precio = 3.99;
            if (producto.Equals("Torta Mixta #2")) precio = 5.99;
            if (producto.Equals("Hielerazo")) precio = 22.00;
            if (producto.Equals("Sopa de Tortilla")) precio = 3.99;

            lblPrecio.Text = precio.ToString("c");
        }
    }
}
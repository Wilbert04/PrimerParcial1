using PrimerParcialAplicada.BLL;
using PrimerParcialAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimerParcialAplicada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdTextbox.Text = "0";
            DescripcionTextbox.Text = string.Empty;
            ExistenciaTextbox.Text = "0";
            CostoTextbox.Text = "0";
            ValorInTextbox.Text = "0";

        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = int.Parse(IdTextbox.Text);
            productos.Descripcion = DescripcionTextbox.Text;
            productos.Existencia = Decimal.Parse(ExistenciaTextbox.Text);
            productos.Costo = Convert.ToDecimal(CostoTextbox.Text);
            productos.ValorInventario = Convert.ToDecimal(ValorInTextbox.Text);
            return productos;
        }

        private void LlenaCampo(Productos productos)
        {
            IdTextbox.Text = Convert.ToString(productos.ProductoId);
            DescripcionTextbox.Text = productos.Descripcion;
            ExistenciaTextbox.Text = Convert.ToString(productos.Existencia);
            CostoTextbox.Text = Convert.ToString(productos.Costo);
            ValorInTextbox.Text = Convert.ToString(productos.ValorInventario);
        }

        private bool ExisteEnBaseDatos()
        {
            Productos productos = ProductosBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (productos != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if(DescripcionTextbox.Text == string.Empty)
            {
                DescripcionTextbox.Focus();
                paso = false;

            }

            if(Convert.ToDecimal(ExistenciaTextbox.Text) < 0)
            {
                MessageBox.Show("Este campo no puede estar vacio");
                ExistenciaTextbox.Focus();
                paso = false;
            }

            if(Convert.ToDecimal(CostoTextbox.Text) < 0)
            {
                MessageBox.Show("El campo no puede estar vacio");
                CostoTextbox.Focus();
                paso = false;
            }

            if(Convert.ToDecimal(ValorInTextbox.Text) < 0)
            {
                MessageBox.Show("El campode del ID no puede estar vacio");
                ValorInTextbox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton(object sender, RoutedEventArgs e)
        {
            Productos productos = new Productos();
            bool paso = false;

            if (!Validar())
                return;

            productos = LlenaClase();

            if(IdTextbox.Text == "0")
            {
                paso = ProductosBLL.Guardar(productos);
            }
            else
            {
                if (!ExisteEnBaseDatos())
                {
                    MessageBox.Show("No se puede modificar un persona que no exista", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                paso = ProductosBLL.Modificar(productos);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardó correctamente", "Exitos", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show(" No se pudo guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton(object sender, RoutedEventArgs e)
        {
            int ID;
            int.TryParse(IdTextbox.Text, out ID);

            Limpiar();

            if (ProductosBLL.Eliminar(ID))
            {
                MessageBox.Show("Eliminó correctamente", "exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void BuscarButton(object sender, RoutedEventArgs e)
        {
            int ID;
            Productos productos = new Productos();
            int.TryParse(IdTextbox.Text, out ID);

            Limpiar();

            productos = ProductosBLL.Buscar(ID);


            if (productos != null)
            {
                MessageBox.Show("Persona encontrada", "exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}

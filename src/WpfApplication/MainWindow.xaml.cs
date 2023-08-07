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
using DapperExtension;
using DapperExtension.DBContext.Models;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private DBInteraction dbInteraction;

        public MainWindow()
        {
            InitializeComponent();
            try {
                this.dbInteraction = new DBInteraction();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                return;
            }
            var newHardware = new Hardware {Name="Some Hardware", Shortcut="SM",
                Description="Some description", Ip=1230, MaterialNumber=5010, Products=null};

            try {
              this.dbInteraction.InsertHarware(newHardware);
            } catch (Exception e) {
              MessageBox.Show(e.Message);
            }

            MessageBox.Show(newHardware.Description);
            var products = this.dbInteraction.GetProducts();
            foreach(var product in products) {
              MessageBox.Show(product.Name);
            }
        }
    }
}

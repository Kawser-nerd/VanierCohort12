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
using System.Windows.Shapes;

namespace week2cls1Student
{
    /// <summary>
    /// Interaction logic for SecondWpf.xaml
    /// </summary>
    public partial class SecondWpf : Window
    {
        public SecondWpf()
        {
            InitializeComponent();
        }

        private void orderPl_Click(object sender, RoutedEventArgs e)
        {
            // this method is going to trigger when you click on the button
            Resturant resturant = new Resturant();

            resturant.tableNo = int.Parse(tableNo.Text);
            // textboxName.Text will return you the content or text
            // you put inside the textbox.. This will return string
            // type value all the time. So, we need to covert it
            // to the destination datatype
            resturant.orderNo = int.Parse(orderNo.Text);

            resturant.item = items.Text;

            // Radio Button
            if (Low.IsChecked == true)
            {
                resturant.spiceLevel = "Low";
            }
            else if(Medium.IsChecked == true)
            {
                resturant.spiceLevel = "Medium";
            }
            else if(High.IsChecked == true)
            {
                resturant.spiceLevel = "High";
            }

            // Combobox
            if(dineIn.IsChecked == true)
            {
                Take_Out.IsChecked = false;
                delivery.IsChecked = false;
                resturant.restrurantOption = "Dine in";
            }
            else if(Take_Out.IsChecked == true)
            {
                dineIn.IsChecked = false;
                delivery.IsChecked= false;
                resturant.restrurantOption = "Take Out";
            }
            else if(delivery.IsChecked == true)
            {
                dineIn.IsChecked = false;
                Take_Out.IsChecked= false;
                resturant.restrurantOption = "Delivery";
            }

            string orderFinal = "The server take order for the table no "
                + resturant.tableNo.ToString() + '\n' +
                " with the order number no " 
                + resturant.orderNo.ToString() + '\n' +
                " & the order item is " 
                + resturant.item.ToString() + '\n' +
                " Spice leve is " 
                + resturant.spiceLevel + '\n' +
                " & the develivary option is " 
                + resturant.restrurantOption;

            MessageBox.Show(orderFinal);

        }
    }
}

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

namespace PhotoStudio
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null)
                switch (tabControl.SelectedIndex)
                {
                    case 1:
                        addButton.Command = ((ApplicationViewModel)DataContext).AddOrderCommand;
                        removeButton.Command = ((ApplicationViewModel)DataContext).RemoveOrderCommand;
                        removeButton.CommandParameter = ((ApplicationViewModel)DataContext).SelectedOrder;
                        break;
                    case 2:
                        addButton.Command = ((ApplicationViewModel)DataContext).AddClientCommand;
                        removeButton.Command = ((ApplicationViewModel)DataContext).RemoveClientCommand;
                        removeButton.CommandParameter = ((ApplicationViewModel)DataContext).SelectedClient;
                        break;
                    case 3:
                        addButton.Command = ((ApplicationViewModel)DataContext).AddServiceCommand;
                        removeButton.Command = ((ApplicationViewModel)DataContext).RemoveServiceCommand;
                        removeButton.CommandParameter = ((ApplicationViewModel)DataContext).SelectedService;
                        break;
                }
        }
    }
}

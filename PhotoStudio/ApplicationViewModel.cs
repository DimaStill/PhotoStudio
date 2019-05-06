using PhotoStudio.Context;
using PhotoStudio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio
{
    class ApplicationViewModel 
    {
        Order selectedOrder;
        Client selectedClient;
        Service selectedService;

        PhotoStudioContext db;

        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Service> Services { get; set; } = new ObservableCollection<Service>();

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {

                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      db.SaveChanges();
                  }));
            }
        }

        private RelayCommand addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                
                return addOrderCommand ??
                  (addOrderCommand = new RelayCommand(obj =>
                  {
                      Order order = new Order();
                      order.Date = DateTime.Now;
                      Orders.Insert(Orders.Count, order);
                      db.Orders.Add(order);

                      db.SaveChanges();
                      SelectedOrder = order;                      
                  }));
            }
        }

        private RelayCommand addClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {

                return addClientCommand ??
                  (addClientCommand = new RelayCommand(obj =>
                  {
                      Client client = new Client();
                      Clients.Insert(Clients.Count, client);
                      db.Clients.Add(client);
                      SelectedClient = client;
                  }));
            }
        }

        private RelayCommand addServiceCommand;
        public RelayCommand AddServiceCommand
        {
            get
            {

                return addServiceCommand ??
                  (addServiceCommand = new RelayCommand(obj =>
                  {
                      Service service = new Service();
                      Services.Insert(Services.Count, service);
                      db.Services.Add(service);
                      SelectedService = service;
                  }));
            }
        }

        private RelayCommand removeOrderCommand;
        public RelayCommand RemoveOrderCommand
        {
            get
            {
                return removeOrderCommand ??
                  (removeOrderCommand = new RelayCommand(obj =>
                  {
                      Order order = obj as Order;
                      if (order != null)
                      {
                          Orders.Remove(order);
                          db.Orders.Remove(order);
                      }
                  },
                 (obj) => Orders.Count > 0));
            }
        }

        private RelayCommand removeClientCommand;
        public RelayCommand RemoveClientCommand
        {
            get
            {
                return removeClientCommand ??
                  (removeClientCommand = new RelayCommand(obj =>
                  {
                      Client client = obj as Client;
                      if (client != null)
                      {
                          Clients.Remove(client);
                          db.Clients.Remove(client);
                      }
                  },
                 (obj) => Clients.Count > 0));
            }
        }

        private RelayCommand removeServiceCommand;
        public RelayCommand RemoveServiceCommand
        {
            get
            {
                return removeServiceCommand ??
                  (removeServiceCommand = new RelayCommand(obj =>
                  {
                      Service service = obj as Service;
                      if (service != null)
                      {
                          Services.Remove(service);
                          db.Services.Remove(service);
                      }
                  },
                 (obj) => Services.Count > 0));
            }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {

                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {

                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public Service SelectedService
        {
            get { return selectedService; }
            set
            {

                selectedService = value;
                OnPropertyChanged("SelectedService");
            }
        }

        public ApplicationViewModel()
        {
            db = new PhotoStudioContext();

            db.Orders.Load();
            db.Clients.Load();
            db.Services.Load();

            db.SaveChanges();

            foreach (Order order in db.Orders.Local.ToList())
                Orders.Add(order);

            foreach (Client client in db.Clients.Local.ToList())
                Clients.Add(client);

            foreach (Service service in db.Services.Local.ToList())
                Services.Add(service);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.Model
{
    class Order : INotifyPropertyChanged
    {
        private int id;
        private int amountPeople;
        private int amountPhoto;
        private int price;

        private DateTime date;
        private Client client;
        private Service service;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public int AmountPeople
        {
            get { return amountPeople; }
            set
            {
                amountPeople = value;
                OnPropertyChanged("AmountPeople");
            }
        }
        public int AmountPhoto
        {
            get { return amountPhoto; }
            set
            {
                amountPhoto = value;
                OnPropertyChanged("AmountPhoto");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }
        public Service Service
        {
            get { return service; }
            set
            {
                service = value;
                OnPropertyChanged("Service");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

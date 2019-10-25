using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeTransportInfo.MyViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private InfoTrain infoTrain;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string nomPropriete = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        public MyViewModel(InfoTrain mod)
        {
            this.infoTrain = mod;
        }
        public string ligne
        {
            get { return this.infoTrain.ligne; }
            set
            {
                this.infoTrain.ligne = value;
                NotifyPropertyChanged("ville");
            }
        }

        public string voie
        {
            get { return this.infoTrain.voie; }
            set
            {
                this.infoTrain.voie = value;
                NotifyPropertyChanged("voie");
            }
        }

        public string direction
        {
            get { return this.infoTrain.direction; }
            set
            {
                this.infoTrain.direction = value;
                NotifyPropertyChanged("numeroLigne");
            }
        }

        public string info
        {
            get { return this.infoTrain.info; }
            set
            {
                this.infoTrain.info = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<InfoTrain> listeTrainSNCF;

        public ObservableCollection<InfoTrain> ListeTrainSNCF
        {
            get
            {
                return listeTrainSNCF;
            }

            set
            {
                if (value != listeTrainSNCF)
                {
                    listeTrainSNCF = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private InfoTrain trainSelectionnee;

        public InfoTrain TrainSelectionnee
        {
            get
            {
                return trainSelectionnee;
            }

            set
            {
                if (value != trainSelectionnee)
                {
                    trainSelectionnee = value;
                    NotifyPropertyChanged("trainSelectionnee");
                }
            }
        }

        public string b;

        public MyViewModel()
        {
            ListeTrainSNCF = new ObservableCollection<InfoTrain>();
            List<string> li = new List<string> { "Marseill", "Lyon", "Fosses" };

            foreach (var n in li)
            {
                this.b = n;
            }
            TrainSelectionnee = new InfoTrain()
            {
                direction = "Fosses",
                voie = "A",
                horaire = DateTime.Now.ToString("hh:mm"),
                ligne = "25",
                info = b

            };

            ListeTrainSNCF.Add(TrainSelectionnee);
        }
    }
    }

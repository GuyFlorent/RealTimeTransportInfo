using ActiveMq_Utils;
using Model;
using RealTimeTransportPublisher.Command;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RealTimeTransportPublisher.VueModelTrain
{
   public class VueModelTrain
    {
        ActivMQPublisher publisher;
        private string user = ConfigurationManager.AppSettings["ActiveMQ_user"];
        private string pwd = ConfigurationManager.AppSettings["ActiveMQ_pwd"];
        private string host = ConfigurationManager.AppSettings["ActiveMQ_host"];
        private string port = ConfigurationManager.AppSettings["ActiveMQ_port"];
        private string topic = ConfigurationManager.AppSettings["ActiveMQ_topic"];

        public event PropertyChangedEventHandler PropertyChanged;

        public VueModelTrain()
        {

            this.infoTrain = new InfoTrain();
            publisher = new ActivMQPublisher(user, pwd, host, port, topic);
            this._commandPublisher = new CommandPublisher(envoyer_message, peut_envoyer_message);
        }
        public bool peut_envoyer_message(object parameter)// provenant du Icommand
        {
            return (this.horaire != null && this.horaire.Trim() != ""); //condition du bool sur les horaiares
        }

        public void envoyer_message(object parameter)
        {
            string msg = SerialisationTool.serialiser((InfoTrain)parameter); //transformation du message en string serialisation
            publisher.sendMsg(msg);
        }
        public ICommand _commandPublisher { get; set; } //permet de mettre ca dans le 

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        InfoTrain _infotrain;


        public InfoTrain infoTrain
        {
            get
            {
                return this._infotrain;
            }
            set
            {
                this._infotrain = value;
                RaisePropertyChanged("infoTrain");
            }
        }
        public string ligne
        {
            get
            {
                return this.infoTrain.ligne;
            }
            set
            {
                this.infoTrain.ligne = value;
                RaisePropertyChanged("ligne");
            }
        }

        public string id_train
        {
            get
            {
                return this.infoTrain.id_train.ToString();
            }
            set
            {
                this.infoTrain.id_train = Int32.Parse(value);
                RaisePropertyChanged("id_train");
            }
        }


        public string horaire
        {
            get
            {
                return this.infoTrain.horaire;
            }
            set
            {
                this.infoTrain.horaire = value;
                RaisePropertyChanged("horaire");
            }
        }


        public string direction
        {
            get
            {
                return this.infoTrain.direction;
            }
            set
            {
                this.infoTrain.direction = value;
                RaisePropertyChanged("direction");
            }
        }

        public string voie
        {
            get
            {
                return this.infoTrain.voie;
            }
            set
            {
                this.infoTrain.voie = value;
                RaisePropertyChanged("voie");
            }
        }

        


        public string info
        {
            get
            {
                return this.infoTrain.info;
            }
            set
            {
                this.infoTrain.info = value;
                RaisePropertyChanged("info");
            }
        }
    }
}

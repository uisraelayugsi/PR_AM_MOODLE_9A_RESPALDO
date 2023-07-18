using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace PR_AM_MOODLE_9A
{
    public class Notificacion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisedPropertyChanged(String propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
        private int _Hora;
        public Notificacion(int hora)
        {
            this.Hora = hora;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.Hora--;
                if (Hora == 0)
                {
                    CrossLocalNotifications.Current.Show("Notificaciones", "Temporizador finalizado. Tiempo transcurrido:  " + hora);
                    return false;
                }
                else
                    return true;
            });


        }
        public int Hora
        {
            get { return this._Hora; }
            set { this._Hora = value; RaisedPropertyChanged("Hora"); }
        }
    }
}

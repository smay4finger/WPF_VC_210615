﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Personendatenbank
{
    public enum Gender { Männlich, Weiblich, Divers }

    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string vorname;
        public string Vorname { get => vorname; set { vorname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname))); } }

        private string nachname;
        public string Nachname { get => nachname; set { nachname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname))); } }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum { get => geburtsdatum; set { geburtsdatum = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geburtsdatum))); } }

        private bool verheiratet;
        public bool Verheiratet { get => verheiratet; set { verheiratet = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verheiratet))); } }

        private Color lieblingsfarbe;
        public Color Lieblingsfarbe { get => lieblingsfarbe; set { lieblingsfarbe = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe))); } }

        private Gender geschlecht;
        public Gender Geschlecht { get => geschlecht; set { geschlecht = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geschlecht))); } }

      public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
                        break;

                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
                        break;

                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;

                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                        break;
                }

                return String.Empty;
            }
        }


        public Person()
        {
            this.Vorname = String.Empty;
            this.Nachname = String.Empty;
            this.Lieblingsfarbe = new Color();
            this.Geburtsdatum = DateTime.Now;
        }
    }
}
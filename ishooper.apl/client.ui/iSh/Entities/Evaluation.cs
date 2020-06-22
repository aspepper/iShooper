using System;
using Xamarin.Forms;

namespace iSh.Entities
{
    public class Evaluation
    {

        public int Id { get; set; }
        public User UserProfile { get; set; }
        public ImageSource Commendation001 { get; set; } // Curtiu -- Elogio_Curtiu.png
        public ImageSource Commendation002 { get; set; } // Excelencia -- Elogio_Excelente.png
        public ImageSource Commendation003 { get; set; } // Pontualidade -- Elogio_Pontualidade.png
        public ImageSource Commendation004 { get; set; } // Rapidez, Presteza, êxito -- Elogio_Rapidez.png
        public string Comments { get; set; }

        public Evaluation()
        { }

    }
}

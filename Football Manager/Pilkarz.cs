using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public enum Pozycja { bramkarz, obronca, pomocnik, napastnik }

    public class Pilkarz
    {
        public Pozycja najlepszaPozycja { get; set; }
        public int klub { get; set; }
        public int id { get; private set; }
        public int nr { get; private set; }
        public string imieNazwisko { get; private set; }
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public int rokUrodzenia { get; private set; }
        public int wiek { get; private set; }

        public int umiejetnosci { get; private set; }
        public int umBramkarskie { get; private set; }
        public int defensywa { get; private set; }
        public int rozgrywanie { get; private set; }
        public int skutecznosc { get; private set; }
        public int kondycja { get; private set; }
        public int przywodztwo { get; private set; }

        public Pilkarz(
            int id,
            string imie,
            string nazwisko,
            int rokUrodzenia,
            int klub,
            int nr,
            int umiejetnosci,
            int umBramkarskie,
            int defensywa,
            int rozgrywanie,
            int skutecznosc,
            int kondycja,
            int przywodztwo
            )
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            imieNazwisko = imie + " " + nazwisko;
            this.rokUrodzenia = rokUrodzenia;
            wiek = 2015 - rokUrodzenia;
            this.klub = klub;
            this.nr = nr;

            this.umiejetnosci = umiejetnosci;
            this.umBramkarskie = umBramkarskie;
            this.defensywa = defensywa;
            this.rozgrywanie = rozgrywanie;
            this.skutecznosc = skutecznosc;
            this.kondycja = kondycja;
            this.przywodztwo = przywodztwo;
        }

        public void ustalNumer(int nr) { this.nr = nr; }
    }
}
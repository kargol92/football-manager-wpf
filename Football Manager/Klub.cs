using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public class Klub
    {
        public static Klub wybranaDruzyna { get; set; }
        public static Klub wybranyPrzeciwnik { get; set; }

        public static readonly string[] formacje = { "5-4-1", "5-3-2", "4-5-1", "4-4-2", "4-3-3", "3-5-2", "3-4-3" };
        public static readonly string[] ustawienia = { "bardzo defensywne", "defensywne", "neutralne", "ofensywne", "bardzo ofensywne" };
        public static readonly string[] poziomy = { "bardzo słaby", "słaby", "zwykły", "mocny", "bardzo mocny" };

        public string formacja { get; set; }
        public string ustawienie { get; set; }
        public string pressing { get; set; }
        public string agresja { get; set; }
        public int kapitan { get; set; }
        public int staleFragmentyGry { get; set; }

        public int iloscPilkarzy { get; set; }
        public Menedzer menedzer { get; set; }
        public Mecz[] mecze { get; private set; }
        public Pilkarz[] pilkarze { get; private set; }
        public Pilkarz[] jedenastka { get; private set; }
        public List<Pilkarz> bramkarze { get; private set; }
        public List<Pilkarz> obroncy { get; private set; }
        public List<Pilkarz> pomocnicy { get; private set; }
        public List<Pilkarz> napastnicy { get; private set; }

        public int id { get; private set; }
        public int lp { get; private set; }
        public string nazwa { get; private set; }
        public string nazwaKlubu { get; private set; }
        public string miasto { get; private set; }
        public string liga { get; private set; }
        // STATYSTYKI POZIOMÓW
        public int poziom { get; private set; }
        public int atak { get; private set; }
        public int pomoc { get; private set; }
        public int obrona { get; private set; }
        // STATYSTYKI LIGOWE
        public int miejsce { get; private set; }
        public int iloscMeczow { get; private set; }
        public int zwyciestwa { get; private set; }
        public int remisy { get; private set; }
        public int porazki { get; private set; }
        public int goleZdobyte { get; private set; }
        public int goleStracone { get; private set; }
        public int goleRoznica { get; private set; }
        public int punkty { get; private set; }

        public Klub(int id, string nazwaKlubu, string miasto) // DO GENEROWANIA KLUBÓW
        {
            this.id = id;
            this.nazwaKlubu = nazwaKlubu;
            this.miasto = miasto;
            nazwa = nazwaKlubu + " " + miasto;
        }

        public Klub( // DO WCZYTYWANIA KLUBÓW Z BAZY DANYCH
            int id,
            int lp,
            string nazwaKlubu,
            string miasto,
            string liga,

            string formacja,
            string ustawienie,
            string pressing,
            string agresja,
            int kapitan,
            int staleFragmentyGry,

            int miejsce,
            int iloscMeczow,
            int zwyciestwa,
            int remisy,
            int porazki,
            int goleZdobyte,
            int goleStracone,
            int goleRoznica,
            int punkty)
        {
            this.id = id;
            this.lp = lp;
            this.nazwaKlubu = nazwaKlubu;
            this.miasto = miasto;
            nazwa = nazwaKlubu + " " + miasto;
            this.liga = liga;

            this.formacja = formacja;
            this.ustawienie    = ustawienie;
            this.pressing      = pressing;
            this.agresja = agresja;
            this.kapitan    = kapitan;
            this.staleFragmentyGry = staleFragmentyGry;

            this.miejsce = miejsce;
            this.iloscMeczow = iloscMeczow;
            this.zwyciestwa = zwyciestwa;
            this.remisy = remisy;
            this.porazki = porazki;
            this.goleZdobyte = goleZdobyte;
            this.goleStracone = goleStracone;
            this.goleRoznica = goleRoznica;
            this.punkty = punkty;

            mecze = new Mecz[30];
            iloscPilkarzy = 0;
            pilkarze = new Pilkarz[20];
            jedenastka = new Pilkarz[11];
            bramkarze = new List<Pilkarz>();
            obroncy = new List<Pilkarz>();
            pomocnicy = new List<Pilkarz>();
            napastnicy = new List<Pilkarz>();
        }

        public void nadajNumery()
        {
            for (int i = 0; i < iloscPilkarzy; i++)
                pilkarze[i].ustalNumer(i + 1);
        }

        public void sortujPilkarzWedlugNumerow()
        {
            int n = iloscPilkarzy;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (pilkarze[i].nr > pilkarze[i + 1].nr)
                    {
                        Pilkarz tmp = pilkarze[i];
                        pilkarze[i] = pilkarze[i + 1];
                        pilkarze[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }

        public void uaktualnijWyjsciowa11()
        {
            Pilkarz[] tym = new Pilkarz[20];
            for (int i = 0; i < 20; i++)
                tym[i] = pilkarze[i];

            pilkarze = new Pilkarz[20];
            for (int i = 0; i < 20; i++)
                pilkarze[i] = tym[i];

            jedenastka = new Pilkarz[11];
            for (int i = 0; i < 11; i++)
                jedenastka[i] = pilkarze[i];
        }

        public void wczytaj(
            int poziom,
            int atak  ,
            int pomoc ,
            int obrona
            )
        {
            this.poziom = poziom;
            this.atak   = atak  ;
            this.pomoc  = pomoc ;
            this.obrona = obrona;
        }

        public void wyczyscStatystkiLigowe()
        {
            miejsce = 0;
            iloscMeczow = 0;
            zwyciestwa = 0;
            remisy = 0;
            porazki = 0;
            goleZdobyte = 0;
            goleStracone = 0;
            goleRoznica = 0;
            punkty = 0;
        }

        public void obliczPoziomy()
        {
            poziom = 0;
            atak = 0;
            pomoc = 0;
            obrona = 0;

            int iloscObroncow = (int)char.GetNumericValue(formacja[0]);
            int iloscPomocnikow = (int)char.GetNumericValue(formacja[2]);
            int iloscNapastnikow = (int)char.GetNumericValue(formacja[4]);

            // OBLICZANIE POZIOMU OBRONY
            int tym = 0;
            int tymPoziom = 0;
            int k = 1;
            int n = 1 + iloscObroncow;
            for (int i = k; i < n; i++)
            {
                if (i < iloscPilkarzy)
                    tym += pilkarze[i].defensywa;
            }
            tym += pilkarze[0].umBramkarskie;
            obrona = tym / (iloscObroncow + 1);
            tymPoziom += tym;

            // OBLICZANIE POZIOMU POMOCY
            k = 1 + iloscObroncow;
            n = 1 + iloscObroncow + iloscPomocnikow;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < iloscPilkarzy)
                    tym += pilkarze[i].rozgrywanie;
            }
            pomoc = tym / iloscPomocnikow;
            tymPoziom += tym;

            // OBLICZANIE POZIOMU ATAKU
            k = 1 + iloscObroncow + iloscPomocnikow;
            n = 1 + iloscObroncow + iloscPomocnikow + iloscNapastnikow;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < iloscPilkarzy)
                    tym += pilkarze[i].skutecznosc;
            }
            atak = tym / iloscNapastnikow;
            tymPoziom += tym;

            // OBLICZANIE POZIOMU DRUZYNY
            for (int i = 0; i < iloscPilkarzy; i++)
                tym += pilkarze[i].umiejetnosci;
            poziom = tym / iloscPilkarzy;
            //poziom = tymPoziom / 11;


            // OBLICZANIE POZIOMU KONDYCJI
            k = 1 + iloscObroncow;
            n = 1 + iloscObroncow + iloscPomocnikow;
            tym = 0;
            for (int i = k; i < n; i++)
            {
                if (i < iloscPilkarzy)
                    tym += pilkarze[i].kondycja;
            }
            int kondycjaPomocnikow = tym / iloscPomocnikow;

            if (pressing == "bardzo słaby")
                pomoc -= 3;
            if (pressing == "słaby")
                pomoc -= 1;
            if (pressing == "mocny")
            {
                if (kondycjaPomocnikow >  50) pomoc += 3;
                if (kondycjaPomocnikow <= 50) pomoc -= 3;
            }
            if (pressing == "bardzo mocny")
            {
                if (kondycjaPomocnikow >  70) pomoc += 5;
                if (kondycjaPomocnikow <= 70) pomoc -= 5;
            }



            if (ustawienie == "bardzo ofensywne")   { atak += 10; obrona -= 10; }
            if (ustawienie == "ofensywne")          { atak += 5; obrona -= 5; }
            if (ustawienie == "defensywne")         { atak -= 5; obrona += 5; }
            if (ustawienie == "bardzo defensywne")  { atak -= 10; obrona += 10; }

            if (agresja == "bardzo słaby")  obrona -= 5;
            if (agresja == "słaby")         obrona -= 2;
            if (agresja == "mocny")         obrona += 2;
            if (agresja == "bardzo mocny")  obrona += 5;

            if (pilkarze[kapitan].przywodztwo >=  0 && pilkarze[kapitan].przywodztwo < 10) pomoc -= 5;
            if (pilkarze[kapitan].przywodztwo >= 10 && pilkarze[kapitan].przywodztwo < 20) pomoc -= 4;
            if (pilkarze[kapitan].przywodztwo >= 20 && pilkarze[kapitan].przywodztwo < 30) pomoc -= 3;
            if (pilkarze[kapitan].przywodztwo >= 30 && pilkarze[kapitan].przywodztwo < 40) pomoc -= 2;
            if (pilkarze[kapitan].przywodztwo >= 40 && pilkarze[kapitan].przywodztwo < 50) pomoc -= 1;
            if (pilkarze[kapitan].przywodztwo >= 50 && pilkarze[kapitan].przywodztwo < 60) pomoc += 1;
            if (pilkarze[kapitan].przywodztwo >= 60 && pilkarze[kapitan].przywodztwo < 70) pomoc += 2;
            if (pilkarze[kapitan].przywodztwo >= 70 && pilkarze[kapitan].przywodztwo < 80) pomoc += 3;
            if (pilkarze[kapitan].przywodztwo >= 80 && pilkarze[kapitan].przywodztwo < 90) pomoc += 4;
            if (pilkarze[kapitan].przywodztwo >= 90 && pilkarze[kapitan].przywodztwo < 100) pomoc += 5;


            if (atak <= 1) atak = 1;
            if (pomoc <= 1) pomoc = 1;
            if (obrona <= 1) obrona = 1;
            if (atak > 99) atak = 99;
            if (pomoc > 99) pomoc = 99;
            if (obrona > 99) obrona = 99;
        }

        public void ustalMiejsce(int miejsce)
        {
            this.miejsce = miejsce;
        }

        public void uaktualnijStatystyki(Mecz mecz)
        {
            iloscMeczow++;
            if (this == mecz.gospodarz)
            {
                if (mecz.punktyGospodarz == 3) { punkty += 3; zwyciestwa++; }
                if (mecz.punktyGospodarz == 1) { punkty += 1; remisy++; }
                if (mecz.punktyGospodarz == 0) { punkty += 0; porazki++; }
                goleZdobyte += mecz.goleGospodarz;
                goleStracone += mecz.goleGosc;
                goleRoznica += (mecz.goleGospodarz - mecz.goleGosc);
            }
            else if (this == mecz.gosc)
            {
                if (mecz.punktyGosc == 3) { punkty += 3; zwyciestwa++; }
                if (mecz.punktyGosc == 1) { punkty += 1; remisy++; }
                if (mecz.punktyGosc == 0) { punkty += 0; porazki++; }
                goleZdobyte += mecz.goleGosc;
                goleStracone += mecz.goleGospodarz;
                goleRoznica += (mecz.goleGosc - mecz.goleGospodarz);
            }
        }
    }
}

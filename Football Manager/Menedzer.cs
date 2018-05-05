using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Football_Manager
{
    public class Menedzer
    {
        public Klub klub { get; set; }
        public int id { get; private set; }
        public string imieNazwisko { get; private set; }
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public int rokUrodzenia { get; private set; }
        public int klubId { get; private set; }

        public Menedzer(int id, string imie, string nazwisko, int rokUrodzenia, int klub, int umiejetnosci)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            imieNazwisko = imie + " " + nazwisko;
            this.rokUrodzenia = rokUrodzenia;
            this.klubId = klub;
            this.umiejetnosci = umiejetnosci;
        }

        public void ustalNajlepszySklad()
        {
            try
            {
                ustalNajlepszePozycjeDlaPilkarzy();
                obliczIluJestPilkarzyNaDanePozycje();
                sortuj();
                zbilansujPozycjePilkarzy();

                klub.pilkarze[0] = klub.bramkarze[0];
                klub.pilkarze[1] = klub.obroncy[0];
                klub.pilkarze[2] = klub.obroncy[1];
                klub.pilkarze[3] = klub.obroncy[2];
                klub.pilkarze[4] = klub.obroncy[3];
                klub.pilkarze[5] = klub.pomocnicy[0];
                klub.pilkarze[6] = klub.pomocnicy[1];
                klub.pilkarze[7] = klub.pomocnicy[2];
                klub.pilkarze[8] = klub.pomocnicy[3];
                klub.pilkarze[9] = klub.napastnicy[0];
                klub.pilkarze[10] = klub.napastnicy[1];

                int j = 11;
                for (int i = 1; i < klub.bramkarze.Count; i++)
                {
                    klub.pilkarze[j] = klub.bramkarze[i];
                    j++;
                }
                for (int i = 4; i < klub.obroncy.Count; i++)
                {
                    klub.pilkarze[j] = klub.obroncy[i];
                    j++;
                }
                for (int i = 4; i < klub.pomocnicy.Count; i++)
                {
                    klub.pilkarze[j] = klub.pomocnicy[i];
                    j++;
                }
                for (int i = 2; i < klub.napastnicy.Count; i++)
                {
                    klub.pilkarze[j] = klub.napastnicy[i];
                    j++;
                }
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
            }
        }

        void wyswietlWiadomosc(string wiadomosc)
        {
            MessageBox.Show(wiadomosc, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            //Console.WriteLine(wiadomosc);
        }





        int umiejetnosci;

        void obliczIluJestPilkarzyNaDanePozycje()
        {
            if (klub.bramkarze.Count == 0)
            {
                for (int i = 0; i < klub.iloscPilkarzy; i++)
                {
                    if (klub.pilkarze[i].najlepszaPozycja == Pozycja.bramkarz)
                        klub.bramkarze.Add(klub.pilkarze[i]);
                }

                for (int i = 0; i < klub.iloscPilkarzy; i++)
                {
                    if (klub.pilkarze[i].najlepszaPozycja == Pozycja.obronca)
                        klub.obroncy.Add(klub.pilkarze[i]);
                }
                for (int i = 0; i < klub.iloscPilkarzy; i++)
                {
                    if (klub.pilkarze[i].najlepszaPozycja == Pozycja.pomocnik)
                        klub.pomocnicy.Add(klub.pilkarze[i]);
                }
                for (int i = 0; i < klub.iloscPilkarzy; i++)
                {
                    if (klub.pilkarze[i].najlepszaPozycja == Pozycja.napastnik)
                        klub.napastnicy.Add(klub.pilkarze[i]);
                }
            }
        }

        void ustalNajlepszePozycjeDlaPilkarzy()
        {
            for (int i = 0; i < klub.iloscPilkarzy; i++)
            {
                if (klub.pilkarze[i].umBramkarskie > klub.pilkarze[i].skutecznosc)
                {
                    if (klub.pilkarze[i].umBramkarskie > klub.pilkarze[i].defensywa)
                    {
                        if (klub.pilkarze[i].umBramkarskie > klub.pilkarze[i].rozgrywanie)
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.bramkarz;
                        else
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.pomocnik;
                    }
                    else
                    {
                        if (klub.pilkarze[i].defensywa > klub.pilkarze[i].rozgrywanie)
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.obronca;
                        else
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.pomocnik;
                    }
                }
                else
                {
                    if (klub.pilkarze[i].skutecznosc > klub.pilkarze[i].defensywa)
                    {
                        if (klub.pilkarze[i].skutecznosc > klub.pilkarze[i].rozgrywanie)
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.napastnik;
                        else
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.pomocnik;
                    }
                    else
                    {
                        if (klub.pilkarze[i].defensywa > klub.pilkarze[i].rozgrywanie)
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.obronca;
                        else
                            klub.pilkarze[i].najlepszaPozycja = Pozycja.pomocnik;
                    }
                }
            }
        }

        void sortuj() // SORTOWANIE BABELKOWE PIŁKARZY ODWROTNE, ZEBY KOMPUTER NIE MIAL ZBYT DOBREGO SKLADU
        {
            int n = klub.bramkarze.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (klub.bramkarze[i].umBramkarskie > klub.bramkarze[i + 1].umBramkarskie)
                    {
                        Pilkarz tmp = klub.bramkarze[i];
                        klub.bramkarze[i] = klub.bramkarze[i + 1];
                        klub.bramkarze[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = klub.obroncy.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (klub.obroncy[i].defensywa > klub.obroncy[i + 1].defensywa)
                    {
                        Pilkarz tmp = klub.obroncy[i];
                        klub.obroncy[i] = klub.obroncy[i + 1];
                        klub.obroncy[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = klub.pomocnicy.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (klub.pomocnicy[i].rozgrywanie > klub.pomocnicy[i + 1].rozgrywanie)
                    {
                        Pilkarz tmp = klub.pomocnicy[i];
                        klub.pomocnicy[i] = klub.pomocnicy[i + 1];
                        klub.pomocnicy[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            n = klub.napastnicy.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (klub.napastnicy[i].skutecznosc > klub.napastnicy[i + 1].skutecznosc)
                    {
                        Pilkarz tmp = klub.napastnicy[i];
                        klub.napastnicy[i] = klub.napastnicy[i + 1];
                        klub.napastnicy[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }

        void zbilansujPozycjePilkarzy()
        {
            while (klub.obroncy.Count < 4)
            {
                if (klub.pomocnicy.Count > 4)
                {
                    int i = klub.pomocnicy.Count - 1;
                    klub.obroncy.Add(klub.pomocnicy[i]);
                    klub.pomocnicy.RemoveAt(i);
                }
                else if (klub.napastnicy.Count > 2)
                {
                    int i = klub.napastnicy.Count - 1;
                    klub.obroncy.Add(klub.napastnicy[i]);
                    klub.napastnicy.RemoveAt(i);
                }
            }
            while (klub.pomocnicy.Count < 4)
            {
                if (klub.obroncy.Count > 4)
                {
                    int i = klub.obroncy.Count - 1;
                    klub.pomocnicy.Add(klub.obroncy[i]);
                    klub.obroncy.RemoveAt(i);
                }
                else if (klub.napastnicy.Count > 2)
                {
                    int i = klub.napastnicy.Count - 1;
                    klub.pomocnicy.Add(klub.napastnicy[i]);
                    klub.napastnicy.RemoveAt(i);
                }
            }
            while (klub.napastnicy.Count < 2)
            {
                if (klub.obroncy.Count > 4)
                {
                    int i = klub.obroncy.Count - 1;
                    klub.napastnicy.Add(klub.obroncy[i]);
                    klub.obroncy.RemoveAt(i);
                }
                else if (klub.pomocnicy.Count > 4)
                {
                    int i = klub.pomocnicy.Count - 1;
                    klub.napastnicy.Add(klub.pomocnicy[i]);
                    klub.pomocnicy.RemoveAt(i);
                }
            }
        }


        //void sortuj1() // SORTOWANIE BABELKOWE PIŁKARZY UPROSZCZONE BEZ DRUGIEJ PETLI ORAZ Z WARUNKAMI, ZEBY KOMPUTER NIE MIAL ZBYT DOBREGO SKLADU
        //{
        //    obliczPoziomy();
        //    for (int i = 0; i < this.bramkarze.Count - 1; i++)
        //    {
        //        if (this.bramkarze[i].umBramkarskie < this.bramkarze[i + 1].umBramkarskie)
        //        {
        //            Pilkarz tmp = this.bramkarze[i];
        //            this.bramkarze[i] = this.bramkarze[i + 1];
        //            this.bramkarze[i + 1] = tmp;
        //        }
        //    }
        //    if (obrona <= 4)
        //    {
        //        for (int i = 0; i < this.obroncy.Count - 1; i++)
        //        {
        //            if (this.obroncy[i].defensywa < this.obroncy[i + 1].defensywa)
        //            {
        //                Pilkarz tmp = this.obroncy[i];
        //                this.obroncy[i] = this.obroncy[i + 1];
        //                this.obroncy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //    if (pomoc <= 4)
        //    {
        //        for (int i = 0; i < this.pomocnicy.Count - 1; i++)
        //        {
        //            if (this.pomocnicy[i].rozgrywanie < this.pomocnicy[i + 1].rozgrywanie)
        //            {
        //                Pilkarz tmp = this.pomocnicy[i];
        //                this.pomocnicy[i] = this.pomocnicy[i + 1];
        //                this.pomocnicy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //    if (atak <= 4)
        //    {
        //        for (int i = 0; i < this.napastnicy.Count - 1; i++)
        //        {
        //            if (this.napastnicy[i].skutecznosc < this.napastnicy[i + 1].skutecznosc)
        //            {
        //                Pilkarz tmp = this.napastnicy[i];
        //                this.napastnicy[i] = this.napastnicy[i + 1];
        //                this.napastnicy[i + 1] = tmp;
        //            }
        //        }
        //    }
        //}
        //void sortuj() // SORTOWANIE BABELKOWE PIŁKARZY NA POSZCZEGÓLNYCH POZYCJACH, ZEBY KOMPUTER MOGL USTALIC OPTYMALNY SKLAD
        //{
        //    int n = this.bramkarze.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.bramkarze[i].umBramkarskie < this.bramkarze[i + 1].umBramkarskie)
        //            {
        //                Pilkarz tmp = this.bramkarze[i];
        //                this.bramkarze[i] = this.bramkarze[i + 1];
        //                this.bramkarze[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.obroncy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.obroncy[i].defensywa < this.obroncy[i + 1].defensywa)
        //            {
        //                Pilkarz tmp = this.obroncy[i];
        //                this.obroncy[i] = this.obroncy[i + 1];
        //                this.obroncy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.pomocnicy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.pomocnicy[i].rozgrywanie < this.pomocnicy[i + 1].rozgrywanie)
        //            {
        //                Pilkarz tmp = this.pomocnicy[i];
        //                this.pomocnicy[i] = this.pomocnicy[i + 1];
        //                this.pomocnicy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);

        //    n = this.napastnicy.Count;
        //    do
        //    {
        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            if (this.napastnicy[i].skutecznosc < this.napastnicy[i + 1].skutecznosc)
        //            {
        //                Pilkarz tmp = this.napastnicy[i];
        //                this.napastnicy[i] = this.napastnicy[i + 1];
        //                this.napastnicy[i + 1] = tmp;
        //            }
        //        }
        //        n--;
        //    }
        //    while (n > 1);
        //}
    }
}

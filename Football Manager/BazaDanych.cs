using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace Football_Manager
{
    public class BazaDanych
    {
        public static BazaDanych instancja { get; set; }

        public int iloscKlubow { get; private set; }
        public int iloscPilkarzy { get; private set; }
        public Klub[] kluby { get; private set; }
        public Pilkarz[] pilkarze { get; private set; }
        public Menedzer[] menedzerowie { get; private set; }
        public Mecz[,] mecze { get; private set; }

        public BazaDanych()
        {
            try
            {
                polaczenie = new OleDbConnection();
                polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
                                                Data Source=dane\baza danych.accdb;";
                polaczenie.Open();

                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM Klub", polaczenie);
                iloscKlubow = (int)zapytanie.ExecuteScalar();
                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM Pilkarz", polaczenie);
                iloscPilkarzy = (int)zapytanie.ExecuteScalar();

                kluby = new Klub[iloscKlubow];
                menedzerowie = new Menedzer[iloscKlubow];
                pilkarze = new Pilkarz[iloscPilkarzy];

                polaczenie.Close();
            }
            catch (Exception e)
            {
                polaczenie.Close();
                wyswietlWiadomosc(e.Message);
                blad = true;
            }
            if (blad == false)
            {
                wczytajKluby();
                wczytajPilkarzy();
                wczytajMenedzerow();
                przypiszMenedzerowKlubom();
                przypiszPilkarzyKlubom();

                for (int i = 0; i < iloscKlubow; i++)
                {
                    kluby[i].sortujPilkarzWedlugNumerow();
                    kluby[i].obliczPoziomy();
                    kluby[i].uaktualnijWyjsciowa11();
                }
            }
        }

        public int zapiszGre(Liga liga)
        {
            try
            {
                polaczenie.Open();

                // ZAPIS STANU GRY
                zapytanie = new OleDbCommand("DELETE FROM StanGry", polaczenie);
                zapytanie.ExecuteNonQuery();
                string data = DateTime.Now.ToString();
                zapytanie = new OleDbCommand("INSERT INTO StanGry (DataZapisu, Klub, Sezon, Kolejka) " +
                    "values('" + data + "', '" + liga.druzynaGracza.id + "', '" + liga.sezon + "', '" + liga.nrKolejki + "')", polaczenie);
                zapytanie.ExecuteNonQuery();

                // ZAPIS KLUBÓW
                zapytanie = new OleDbCommand("DELETE FROM Klub", polaczenie);
                zapytanie.ExecuteNonQuery();
                for (int i = 0; i < iloscKlubow; i++)
                {
                    zapytanie = new OleDbCommand("INSERT INTO Klub (Id, NazwaKlubu, Miasto, Liga, " +
                        "Formacja, Ustawienie, Pressing, Agresja, Kapitan, StaleFragmenty, " +
                        "Miejsce, Mecze, Zwyciestwa, Remisy, Porazki, GoleZdobyte, GoleStracone, GoleRoznica, Punkty) " +
                        "values('" + kluby[i].id + "', '" + kluby[i].nazwaKlubu + "', '" + kluby[i].miasto + "', '" + kluby[i].liga +
                        "', '" + kluby[i].formacja + "', '" + kluby[i].ustawienie + "', '" + kluby[i].pressing + "', '" + kluby[i].agresja + "', '" + kluby[i].kapitan + "', '" + kluby[i].staleFragmentyGry +
                        "', '" + kluby[i].miejsce + "', '" + kluby[i].iloscMeczow + "', '" + kluby[i].zwyciestwa + "', '" + kluby[i].remisy + "', '" + kluby[i].porazki + "', '" + kluby[i].goleZdobyte + "', '" + kluby[i].goleStracone + "', '" + kluby[i].goleRoznica + "', '" + kluby[i].punkty +
                        "')", polaczenie);
                    zapytanie.ExecuteNonQuery();
                }

                // ZAPIS PIŁKARZY
                zapytanie = new OleDbCommand("DELETE FROM Pilkarz", polaczenie);
                zapytanie.ExecuteNonQuery();
                for (int i = 0; i < iloscPilkarzy; i++)
                {
                    zapytanie = new OleDbCommand("INSERT INTO Pilkarz (Id, Imie, Nazwisko, RokUrodzenia, Klub, Nr, " +
                        "Suma, UmBramkarskie, Defensywa, Rozgrywanie, Skutecznosc, Kondycja, Przywodztwo, Miejsce, Mecze, Gole) " +
                        "values('" + pilkarze[i].id + "', '" + pilkarze[i].imie + "', '" + pilkarze[i].nazwisko + "', '" + pilkarze[i].rokUrodzenia +
                        "', '" + pilkarze[i].klub + "', '" + pilkarze[i].nr + "', '" + pilkarze[i].umiejetnosci + "', '" + pilkarze[i].umBramkarskie + "', '" + pilkarze[i].defensywa + "', '" + pilkarze[i].rozgrywanie +
                        "', '" + pilkarze[i].skutecznosc + "', '" + pilkarze[i].kondycja + "', '" + pilkarze[i].przywodztwo + "', '" + 0 + "', '" + 0 + "', '" + 0 +
                        "')", polaczenie);
                    zapytanie.ExecuteNonQuery();
                }

                // ZAPIS MECZÓW
                zapytanie = new OleDbCommand("DELETE FROM Mecz", polaczenie);
                zapytanie.ExecuteNonQuery();
                int id = 0;
                for (int nrkolejki = 0; nrkolejki < liga.iloscKolejek; nrkolejki++)
                {
                    for (int nrMeczu = 0; nrMeczu < Kolejka.iloscMeczow; nrMeczu++)
                    {
                        Mecz mecz = liga.kolejki[nrkolejki].mecze[nrMeczu];
                        zapytanie = new OleDbCommand("INSERT INTO Mecz (Id, DataZapisu, Stan, Sezon, Kolejka, Gospodarz, GoleGospodarz, GoleGosc, Gosc) " +
                            "values('" + id + "', '" + data + "', '" + mecz.stanMeczu + "', '" + mecz.sezon + "', '" + mecz.kolejka + "', '" +
                            mecz.gospodarz.nazwa + "', '" + mecz.goleGospodarz + "', '" + mecz.goleGosc + "', '" + mecz.gosc.nazwa + "')", polaczenie);
                        zapytanie.ExecuteNonQuery();
                        id++;
                    }
                }

                polaczenie.Close();
            }
            catch (OleDbException e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
                return -1;
            }
            return 0;
        }

        public Liga wczytajGre()
        {
            Liga liga = null;

            try
            {
                polaczenie.Open();

                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM StanGry", polaczenie);
                int iloscRekordow = (int)zapytanie.ExecuteScalar();

                if (iloscRekordow == 0)
                {
                    liga = null;
                }
                if (iloscRekordow == 1)
                {
                    // WCZYTANIE STANU GRY
                    zapytanie = new OleDbCommand("SELECT * FROM StanGry", polaczenie);
                    adapter = new OleDbDataAdapter(zapytanie);
                    dane = new DataSet();
                    adapter.Fill(dane, "Dane");

                    int druzynaId = int.Parse(dane.Tables["Dane"].Rows[0]["Klub"].ToString());
                    string sezon1 = dane.Tables["Dane"].Rows[0]["Sezon"].ToString();
                    int kolejka1 = int.Parse(dane.Tables["Dane"].Rows[0]["Kolejka"].ToString());

                    Klub druzyna = null;
                    for (int k = 0; k < iloscKlubow; k++)
                    {
                        if (druzynaId == kluby[k].id)
                            druzyna = kluby[k];
                    }

                    Klub.wybranaDruzyna = druzyna;
                    liga = new Liga(iloscKlubow, kluby, druzyna, sezon1, kolejka1);

                    // WCZYTANIE MECZÓW
                    zapytanie = new OleDbCommand("SELECT * FROM Mecz", polaczenie);
                    adapter = new OleDbDataAdapter(zapytanie);
                    dane = new DataSet();
                    adapter.Fill(dane, "Dane");

                    int l = 0;

                    for (int i = 0; i < liga.iloscKolejek; i++)
                    {
                        for (int j = 0; j < Kolejka.iloscMeczow; j++)
                        {
                            string sezon = dane.Tables["Dane"].Rows[j + l]["Sezon"].ToString();
                            int kolejka = int.Parse(dane.Tables["Dane"].Rows[j + l]["Kolejka"].ToString());
                            string gospodarz = dane.Tables["Dane"].Rows[j + l]["Gospodarz"].ToString();
                            string gosc = dane.Tables["Dane"].Rows[j + l]["Gosc"].ToString();
                            string stanMeczu = dane.Tables["Dane"].Rows[j + l]["Stan"].ToString();
                            int goleGospodarz = int.Parse(dane.Tables["Dane"].Rows[j + l]["GoleGospodarz"].ToString());
                            int goleGosc = int.Parse(dane.Tables["Dane"].Rows[j + l]["GoleGosc"].ToString());
                            Klub Gospodarz = null;
                            Klub Gosc = null;

                            for (int k = 0; k < iloscKlubow; k++)
                            {
                                if (gospodarz == kluby[k].nazwa)
                                    Gospodarz = kluby[k];
                            }

                            for (int k = 0; k < iloscKlubow; k++)
                            {
                                if (gosc == kluby[k].nazwa)
                                    Gosc = kluby[k];
                            }

                            Mecz mecz = new Mecz(Gospodarz, Gosc, stanMeczu, goleGospodarz, goleGosc, sezon, kolejka);
                            liga.kolejki[i].mecze[j] = mecz;
                            if (druzyna == Gospodarz || druzyna == Gosc)
                                liga.druzynaGracza.mecze[i] = mecz;
                        }
                        l += 8;
                    }
                }

                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
            return liga;
        }


        bool blad;
        OleDbConnection polaczenie;
        OleDbCommand zapytanie;
        OleDbDataAdapter adapter;
        DataSet dane;

        void wczytajKluby()
        {
            try
            {
                polaczenie.Open();
                zapytanie = new OleDbCommand("SELECT * FROM Klub ORDER BY NazwaKlubu, Miasto", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Dane");

                for (int i = 0; i < iloscKlubow; i++)
                {
                    kluby[i] = new Klub(
                        int.Parse(dane.Tables["Dane"].Rows[i]["Id"].ToString()),
                        i + 1,
                        dane.Tables["Dane"].Rows[i]["NazwaKlubu"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Miasto"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Liga"].ToString(),

                        dane.Tables["Dane"].Rows[i]["Formacja"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Ustawienie"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Pressing"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Agresja"].ToString(),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Kapitan"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["StaleFragmenty"].ToString()),

                        int.Parse(dane.Tables["Dane"].Rows[i]["Miejsce"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Mecze"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Zwyciestwa"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Remisy"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Porazki"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["GoleZdobyte"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["GoleStracone"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["GoleRoznica"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Punkty"].ToString())
                        );
                }

                polaczenie.Close();
            }
            catch (OleDbException e)
            {
                polaczenie.Close();
                wyswietlWiadomosc(e.Message);
            }
        }

        void wczytajMenedzerow()
        {
            try
            {
                polaczenie.Open();
                zapytanie = new OleDbCommand("SELECT * FROM Menedzer ORDER BY Id", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Dane");

                for (int i = 0; i < iloscKlubow; i++)
                {
                    menedzerowie[i] = new Menedzer(
                        int.Parse(dane.Tables["Dane"].Rows[i]["Id"].ToString()),
                        dane.Tables["Dane"].Rows[i]["Imie"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Nazwisko"].ToString(),
                        int.Parse(dane.Tables["Dane"].Rows[i]["RokUrodzenia"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Klub"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Umiejetnosci"].ToString())
                        );
                }

                polaczenie.Close();
            }
            catch (OleDbException e)
            {
                polaczenie.Close();
                wyswietlWiadomosc(e.Message);
            }
        }

        void wczytajPilkarzy()
        {
            try
            {
                polaczenie.Open();

                zapytanie = new OleDbCommand("SELECT * FROM Pilkarz ORDER BY Id", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Dane");

                for (int i = 0; i < iloscPilkarzy; i++)
                {
                    pilkarze[i] = new Pilkarz(
                        int.Parse(dane.Tables["Dane"].Rows[i]["Id"].ToString()),
                        dane.Tables["Dane"].Rows[i]["Imie"].ToString(),
                        dane.Tables["Dane"].Rows[i]["Nazwisko"].ToString(),
                        int.Parse(dane.Tables["Dane"].Rows[i]["RokUrodzenia"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Klub"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Nr"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Suma"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["UmBramkarskie"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Defensywa"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Rozgrywanie"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Skutecznosc"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Kondycja"].ToString()),
                        int.Parse(dane.Tables["Dane"].Rows[i]["Przywodztwo"].ToString())
                    );
                }

                polaczenie.Close();
            }
            catch (OleDbException e)
            {
                polaczenie.Close();
                wyswietlWiadomosc(e.Message);
            }
        }

        void przypiszMenedzerowKlubom()
        {
            try
            {
                for (int j = 0; j < iloscKlubow; j++)
                {
                    for (int i = 0; i < iloscKlubow; i++)
                    {
                        if (menedzerowie[j].klubId == kluby[i].id)
                        {
                            kluby[i].menedzer = menedzerowie[j];
                            menedzerowie[j].klub = kluby[i];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
            }
        }

        void przypiszPilkarzyKlubom()
        {
            try
            {
                for (int j = 0; j < iloscPilkarzy; j++)
                {
                    for (int i = 0; i < iloscKlubow; i++)
                    {
                        if (pilkarze[j].klub == kluby[i].id)
                        {
                            kluby[i].pilkarze[kluby[i].iloscPilkarzy] = pilkarze[j];
                            kluby[i].iloscPilkarzy++;
                        }
                    }
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
    }
}
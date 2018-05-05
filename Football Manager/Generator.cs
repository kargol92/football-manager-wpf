using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace Football_Manager
{
    class Generator
    {
        public Generator()
        {
            try
            {
                polaczenie = new OleDbConnection();
                polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
                                                Data Source=dane\generator.accdb;";
                polaczenie.Open();
                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM Imie", polaczenie);
                iloscImion = (int)zapytanie.ExecuteScalar();
                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM Nazwisko", polaczenie);
                iloscNazwisk = (int)zapytanie.ExecuteScalar();
                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM NazwaKlubu", polaczenie);
                iloscNazwKlubow = (int)zapytanie.ExecuteScalar();
                zapytanie = new OleDbCommand("SELECT COUNT(*) FROM Miasto WHERE Popularnosc IN (1,2)", polaczenie);
                iloscMiast = (int)zapytanie.ExecuteScalar();
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
                generator = new Random();
                iloscKlubow = 16;
                iloscPilkarzy = iloscKlubow * 20;
                imiona = new string[iloscImion];
                nazwiska = new string[iloscNazwisk];
                nazwyKlubow = new string[iloscNazwKlubow];
                miasta = new string[iloscMiast];
                kluby = new Klub[iloscKlubow];
                menedzerowie = new Menedzer[iloscKlubow];
            }
        }

        public int generuj()
        {
            if (blad == false)
            {
                wczytajDane();
                wyczyscPoprzednieDane();
                generujKluby();
                generujMenedzerow();
                generujPilkarzy();
                return 0;
            }
            else
                return -1;
        }






        int iloscImion;
        int iloscNazwisk;
        int iloscPilkarzy;
        int iloscNazwKlubow;
        int iloscMiast;
        int iloscKlubow;
        string[] imiona;
        string[] nazwiska;
        string[] nazwyKlubow;
        string[] miasta;
        Klub[] kluby;
        Menedzer[] menedzerowie;

        bool blad;
        Random generator;
        OleDbConnection polaczenie;
        OleDbCommand zapytanie;
        OleDbDataAdapter adapter;
        DataSet dane;

        void wczytajDane()
        {
            try
            {
                polaczenie.Open();

                // WCZYTYWANIE IMION
                zapytanie = new OleDbCommand("SELECT Imie FROM Imie ORDER BY Imie", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Data");
                for (int i = 0; i < iloscImion; i++)
                    imiona[i] = dane.Tables["Data"].Rows[i]["Imie"].ToString();

                // WCZYTYWANIE NAZWISK
                zapytanie = new OleDbCommand("SELECT Nazwisko FROM Nazwisko ORDER BY Nazwisko", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Data");
                for (int i = 0; i < iloscNazwisk; i++)
                    nazwiska[i] = dane.Tables["Data"].Rows[i]["Nazwisko"].ToString();

                // WCZYTYWANIE MIAST
                zapytanie = new OleDbCommand("SELECT Miasto, Popularnosc FROM Miasto WHERE Popularnosc IN (1,2) ORDER BY Miasto", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Data");
                for (int i = 0; i < iloscMiast; i++)
                    miasta[i] = dane.Tables["Data"].Rows[i]["Miasto"].ToString();

                //WCZYTYWANIE NAZW KLUBOW
                zapytanie = new OleDbCommand("SELECT Nazwa FROM NazwaKlubu ORDER BY Nazwa", polaczenie);
                adapter = new OleDbDataAdapter(zapytanie);
                dane = new DataSet();
                adapter.Fill(dane, "Data");
                for (int i = 0; i < iloscNazwKlubow; i++)
                    nazwyKlubow[i] = dane.Tables["Data"].Rows[i]["Nazwa"].ToString();

                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
        }

        void wyczyscPoprzednieDane()
        {
            try
            {
                polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
                                                Data Source=dane\baza danych.accdb;";
                polaczenie.Open();
                zapytanie = new OleDbCommand("DELETE FROM Klub", polaczenie);
                zapytanie.ExecuteNonQuery();
                zapytanie = new OleDbCommand("DELETE FROM Mecz", polaczenie);
                zapytanie.ExecuteNonQuery();
                zapytanie = new OleDbCommand("DELETE FROM Menedzer", polaczenie);
                zapytanie.ExecuteNonQuery();
                zapytanie = new OleDbCommand("DELETE FROM Pilkarz", polaczenie);
                zapytanie.ExecuteNonQuery();
                zapytanie = new OleDbCommand("DELETE FROM StanGry", polaczenie);
                zapytanie.ExecuteNonQuery();
                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
        }

        void generujMenedzerow()
        {
            try
            {
                polaczenie.Open();
                for (int i = 0; i < iloscKlubow; i++)
                {
                    int id = i + 1;
                    string imie = imiona[generator.Next(0, iloscImion)];
                    string nazwisko = nazwiska[generator.Next(0, iloscNazwisk)];
                    int rokUrodzenia = generator.Next(1950, 1980);
                    int umiejetnosci = generator.Next(1, 100);
                    int klub = kluby[i].id;

                    zapytanie = new OleDbCommand("INSERT INTO Menedzer (Id, Imie, Nazwisko, RokUrodzenia, Klub, Umiejetnosci) " +
                        "values('" + id + "', '" + imie + "', '" + nazwisko + "', '" + rokUrodzenia + "', '" + klub + "', '" +
                        umiejetnosci + "')", polaczenie);
                    zapytanie.ExecuteNonQuery();
                }
                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
        }

        void generujPilkarzy()
        {
            try
            {
                polaczenie.Open();

                for (int i = 0; i < iloscPilkarzy; i++)
                {
                    int id = i + 1;
                    string imie = imiona[generator.Next(0, iloscImion)];
                    string nazwisko = nazwiska[generator.Next(0, iloscNazwisk)];
                    int rokUrodzenia = generator.Next(1980, 1997);
                    int umBramkarskie = generator.Next(1, 100);
                    int defensywa = generator.Next(1, 100);
                    int rozgrywanie = generator.Next(1, 100);
                    int skutecznosc = generator.Next(1, 100);
                    int kondycja = generator.Next(30, 90);
                    int przywodztwo = generator.Next(30, 90);
                    int miejsce = 0;
                    int mecze = 0;
                    int gole = 0;

                    int umiejetnosci = (defensywa + rozgrywanie + skutecznosc + umBramkarskie) / 4;

                    //int wartosc = (umBramkarskie + defensywa + rozgrywanie + skutecznosc + staleFragmenty + kondycja + przywodztwo) * 10000 / 7;

                    int klub = -1;
                    int nr = 0;

                    for (int j = 0; j < iloscKlubow; j++)
                    {
                        if (kluby[j].iloscPilkarzy < 20)
                        {
                            klub = kluby[j].id;
                            kluby[j].iloscPilkarzy++;
                            nr = kluby[j].iloscPilkarzy;
                            break;
                        }
                    }

                    zapytanie = new OleDbCommand("INSERT INTO Pilkarz (Id, Imie, Nazwisko, RokUrodzenia, Klub, Nr, " +
                        "Suma, UmBramkarskie, Defensywa, Rozgrywanie, Skutecznosc, Kondycja, Przywodztwo, Miejsce, Mecze, Gole) " +
                        "values('" + id + "', '" + imie + "', '" + nazwisko + "', '" + rokUrodzenia + "', '" + klub + "', '" + nr + "', '" +
                        umiejetnosci + "', '" + umBramkarskie + "', '" + defensywa + "', '" + rozgrywanie + "', '" + skutecznosc + "', '" +
                        kondycja + "', '" + przywodztwo + "', '" + miejsce + "', '" + mecze + "', '" + gole + "')", polaczenie);
                    zapytanie.ExecuteNonQuery();

                }
                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
        }

        void generujKluby()
        {
            try
            {
                polaczenie.Open();
                for (int i = 0; i < iloscKlubow; i++)
                {
                    int id = i + 1;
                    string nazwaKlubu = nazwyKlubow[generator.Next(0, iloscNazwKlubow)];
                    string miasto = miasta[generator.Next(0, iloscMiast)];
                    string liga = "1. liga";
                    string formacja = Klub.formacje[generator.Next(7)];
                    string ustawienie = Klub.ustawienia[generator.Next(5)];
                    string pressing = Klub.poziomy[generator.Next(5)];
                    string agresja = Klub.poziomy[generator.Next(5)];
                    int kapitan = generator.Next(0, 11);
                    int rzutyKarne = generator.Next(1, 11);
                    int staleFragmentyGry = generator.Next(1, 11);

                    kluby[i] = new Klub(id, nazwaKlubu, miasto);
                    zapytanie = new OleDbCommand("INSERT INTO Klub (Id, NazwaKlubu, Miasto, Liga, " +
                        "Formacja, Ustawienie, Pressing, Agresja, Kapitan, StaleFragmenty, " +
                        "Miejsce, Mecze, Zwyciestwa, Remisy, Porazki, GoleZdobyte, GoleStracone, GoleRoznica, Punkty) " +
                        "values('" + id + "', '" + nazwaKlubu + "', '" + miasto + "', '" + liga + "', '" +
                        formacja + "', '" + ustawienie + "', '" + pressing + "', '" + agresja + "', '" + kapitan + "', '" + staleFragmentyGry + "', '" +
                        0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "')", polaczenie);
                    zapytanie.ExecuteNonQuery();
                }
                polaczenie.Close();
            }
            catch (Exception e)
            {
                wyswietlWiadomosc(e.Message);
                polaczenie.Close();
            }
        }




        void wyswietlWiadomosc(string wiadomosc)
        {
            MessageBox.Show(wiadomosc, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            //Console.WriteLine(wiadomosc);
        }
    }
}

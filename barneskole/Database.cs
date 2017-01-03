using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace Barneskole
{
    //Database klassen
    class Database
    {
        //MySQL variabler
        private MySqlConnection connection;

        //Informasjon om mysql serveren
        const string server = "localhost";
        const string database = "nes";
        const string uid = "root";
        string password = Properties.Settings.Default.dbpassord;
        
        //Konstruktør
        public Database()
        {
            Initialize();
        }

        //Instansierer database klassen
        private void Initialize()
        {
            try
            {
                //Oppretter kontakt med databasen
                string connectionString;
                connectionString = "Data Source=" + server + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);

                //Sqlskript kommando for oppretting av databasen
                string opprettDatabase = File.ReadAllText(@"opprettDatabase.sql");
                MySqlCommand command = new MySqlCommand(opprettDatabase, connection);

                //Åpner kontakten med databasen og kjører mysql kommandoen
                connection.Open();
                command.CommandTimeout = 0;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw;
            }
        }

        //Åpner kontakten med databasen
        public bool OpenConnection()
        {
            try
            {
                connection.Close();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Kan ikke koble til MySQL serveren. Kontakt administrator!");
                        break;

                    case 1045:
                        throw new Exception("Feil MySQL brukernavn/passord, prøv igjen!");
                        break;
                }
                return false;
            }
        }

        //Lukker kontakten med databasen
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        //Innlogging
        public Bruker SjekkInnlogging(string brukernavn, string passord)
        {
            try
            {
                //SQL setning for å hente ut brukeren fra databasen
                string query = "SELECT brukerid, brukernavn, passord, fornavn, etternavn, bruker.brukertypeID, beskrivelse FROM bruker, brukertype where bruker.brukertypeID= brukertype.brukertypeID and brukernavn='" + brukernavn + "'";

                //Hvis det er kontakt med databasen
                if (this.OpenConnection() == true)
                {

                    //MySQL kommando
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    
                    //MySQL datareader for å kjøre kommandoen
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Mens sql blir utført
                    while (dataReader.Read())
                    {
                        //Hvis brukernavn og passord stemmer overens med brukeren 
                        if (dataReader.GetString("brukernavn") == brukernavn & dataReader.GetString("passord") == passord)
                        {
                            //Oppretter ny bruker for den som logger inn
                            string bID = dataReader.GetString("brukerid");
                            string bNavn = dataReader.GetString("brukernavn");
                            string pass = dataReader.GetString("passord");
                            string fornavn = dataReader.GetString("fornavn");
                            string etternavn = dataReader.GetString("etternavn");
                            string brukertype = dataReader.GetString("beskrivelse");
                            return new Bruker(bID, brukernavn, passord, fornavn, etternavn, brukertype);
                        }
                    }
                    //Lukker datareaderen
                    dataReader.Close();

                    //Lukker kontakten med databasen
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                return null;
        }

        #region Hent
        //Henter filer til valgt test
        public DataSet LastFiler(string testID)
        {
            try
            {
                string query = "SELECT FilID, Filnavn, Filtype, TestID from FIL where testID='" + testID + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter fag
        public DataSet LastFag()
        {
            try
            {
                string query = "SELECT distinct Fagnavn FROM test";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter alle elever
        public DataSet LastElever(string skoleår, string betegnelse)

        {
            try
            {
                string query = "SELECT elev.FNummer, Fornavn, Etternavn, Kjønn, Aktiv, Skoleår, Betegnelse from elev, elevklasse where elev.fnummer=elevklasse.fnummer and skoleår='" + skoleår + "' and betegnelse='" + betegnelse + "' order by aktiv desc, kjønn asc";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        
        //Henter aktive elever
        public DataSet LastEleverResultat(string skoleår, string betegnelse)
        {
            try
            {
                string query = "SELECT elev.FNummer, Fornavn, Etternavn, Kjønn, Aktiv, Skoleår, Betegnelse from elev, elevklasse where elev.fnummer=elevklasse.fnummer and skoleår='" + skoleår + "' and betegnelse='" + betegnelse + "' AND Aktiv= 1";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til valgt klasse
        public DataSet LastResultatKlasse(string år, string betegnelse)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, klasse.skoleår, klasse.betegnelse, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and klasse.betegnelse='" + betegnelse + "' and klasse.skoleår='" + år + "' order by elev.fornavn, Test.Fagnavn, Test.Testnavn, deltest.semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        
        //Henter resultater til deltest til valgt klasse
        public DataSet LastResultatDelTestKlasse(string deltestid, string skoleår, string betegnelse)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and Deltest.DeltestID='" + deltestid + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "'  order by Resultat.Dato desc, Elev.fornavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til test til valgt klasse
        public DataSet LastTestResultatKlasse(string testid, string skoleår, string betegnelse)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.Deltestnavn, Deltest.DeltestID, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and test.testid='" + testid + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "' order by Resultat.Dato desc, Elev.fornavn, Test.Fagnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til test til valgt elev
        public DataSet LastResultatTestElev(string testid, string fnummer)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and test.testid='" + testid + "' order by Resultat.Dato desc, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til test til valgt elev og klasse
        public DataSet LastResultatTestElevKlasse(string testid, string fnummer, string betegnelse, string skoleår)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn,  elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ",  Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and test.testid='" + testid + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "'  order by Resultat.Dato desc, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til valgt elev
        public DataSet LastResultatAlleElev(string fnummer)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' order by Resultat.Dato desc, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til elev til valgt klasse
        public DataSet LastResultatAlleElevKlasse(string fnummer, string betegnelse, string år)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and klasse.betegnelse='" + betegnelse + "' and klasse.skoleår='" + år + "' order by Resultat.Dato desc, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til elev til valgt deltest
        public DataSet LastResultatElevDeltest(string deltestid, string fnummer)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and Deltest.DeltestID='" + deltestid + "' order by Resultat.Dato desc, Elev.fornavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til elev til valgt deltest og klasse
        public DataSet LastResultatElevDeltestKlasse(string deltestid, string fnummer, string betegnelse, string skoleår)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and Deltest.DeltestID='" + deltestid + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "' order by Resultat.Dato desc, Elev.fornavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til fag til valgt elev ResultatFagElev
        public DataSet LastResultatFagElev(string fagnavn, string fnummer)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and Test.Fagnavn='" + fagnavn + "' order by Resultat.Dato desc, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til fag til valgt elev og klasse
        public DataSet LastResultatFagElevKlasse(string fagnavn, string fnummer, string betegnelse, string skoleår)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and elev.FNummer='" + fnummer + "' and Test.Fagnavn='" + fagnavn + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "' order by Resultat.Dato desc, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter resultater til fag til valgt klasse
        public DataSet LastResultatFagKlasse(string fagnavn, string skoleår, string betegnelse)
        {
            try
            {
                string query = "select elev.FNummer, elev.Fornavn, elev.Etternavn, Klasse.Betegnelse, Klasse.Skoleår, Test.fagnavn, Test.Testnavn, Deltest.DeltestID, Deltest.Deltestnavn, Deltest.Semester" +
                    ", Resultat.Poeng, concat(round((Resultat.Poeng/Deltest.Makspoeng*100)),'%') as Prosent, Deltest.Makspoeng, Deltest.Kritiskgrense, Resultat.Kommentar, Resultat.Dato, Bruker.Brukernavn from resultat, deltest, bruker, elev, klasse, test where resultat.DeltestID=deltest.DeltestID" +
                    " and resultat.FNummer=elev.FNummer and resultat.BrukerID=bruker.BrukerID and resultat.Betegnelse = klasse.Betegnelse and resultat.Skoleår=klasse.Skoleår" +
                    " and Deltest.testid = test.testid and test.fagnavn='" + fagnavn + "' and klasse.skoleår='" + skoleår + "' and klasse.betegnelse='" + betegnelse + "' order by Resultat.Dato desc, Elev.fornavn, Test.Fagnavn, Test.Testnavn, Deltest.Semester";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter brukere
        public DataSet LastBrukere()
        {
            try
            {
                string query = "SELECT Fornavn, Etternavn, Brukernavn, Passord, Beskrivelse FROM bruker, brukertype where bruker.brukertypeid=brukertype.BrukertypeID";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter klasser
        public DataSet LastKlasser()
        {
            try
            {
                string query = "SELECT Betegnelse, Skoleår FROM klasse Order by skoleår desc, betegnelse desc";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter klasse år
        public DataSet LastKlasseÅr()
        {
            try
            {
                string query = "SELECT distinct Skoleår, Betegnelse FROM klasse group by skoleår order by Skoleår desc";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter klasser betegnelse
        public DataSet LastKlasserBet(string Skoleår)
        {
            try
            {
                string query = "SELECT Betegnelse FROM klasse where skoleår='" + Skoleår + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter klasser til elev
        public DataSet LastElevKlasser(string FNummer)
        {
            try
            {
                string query = "SELECT Betegnelse, Skoleår FROM elevklasse WHERE FNummer='" + FNummer + "' order by skoleår";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter brukertyper
        public DataSet LastBrukertype()
        {
            try
            {
                string query = "SELECT * FROM brukertype";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter testens id
        public DataSet LastTestID(string testnavn)
        {
            try
            {
                string query = "SELECT TestID FROM test where test.testnavn= '" + testnavn + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter tester til valgt fag
        public DataSet LastTester(string fagnavn)
        {
            try
            {
                string query = "SELECT Testid, Testnavn, test.Fagnavn FROM test where fagnavn= '"+fagnavn+"' order by testnavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter tester til valgt klasse
        public DataSet LastTesterKlasse(string skoleår, string betegnelse)
        {
            try
            {
                string query = "SELECT * FROM test, klassetest where test.TestID=klassetest.TestID and skoleår='" + skoleår + "' and betegnelse='" + betegnelse + "'"; //, fag where test.fagnavn = fag.fagnavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter tester til valgt klasse og fag
        public DataSet LastTesterKlasseFag(string skoleår, string betegnelse, string fagnavn)
        {
            try
            {
                string query = "SELECT * FROM test, klassetest where test.TestID=klassetest.TestID and skoleår='" + skoleår + "' and betegnelse='" + betegnelse + "' and fagnavn='" + fagnavn + "'"; //, fag where test.fagnavn = fag.fagnavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Laster ned fil
        public void LastNedFil(string filID, string filnavn, string filtype)
        {
            try
            {
                //SQL skript for å finne filen
                string query = "SELECT Fil FROM Fil where filID='" + filID + "'";

                //MySQL kommando
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Streamer blobben til et file stream objekt og skriver blobben til en fil
                FileStream fs;                          
                BinaryWriter bw;                        

                //Blob variabler
                int bufferSize = 100;                   
                byte[] outbyte = new byte[bufferSize];  
                long retval;                            
                long startIndex = 0;                    

                //Åpner kontakt med databasen og leser data inn  data readeren
                if (this.OpenConnection() == true)
                {
                    MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    //Lagre fil dialog for å velge hvor man vil lagre filen
                    SaveFileDialog lagreFil = new SaveFileDialog();
                    string filUtenExt = Path.GetFileNameWithoutExtension(filnavn);
                    lagreFil.FileName = filUtenExt;
                    lagreFil.Filter = filtype + " |*" + filtype + "|All Files (*.*)|*.*";

                    //Mens datareaderen leser filen
                    while (myReader.Read())
                    {
                        //Hvis man trykker ok
                        if (lagreFil.ShowDialog() == DialogResult.OK)
                        {
                            //Lager en fil ti å holde på data
                            fs = new FileStream(lagreFil.FileName, FileMode.Create, FileAccess.Write);
                            bw = new BinaryWriter(fs);

                            //Resetter starting byte for den nye blobben
                            startIndex = 0;
                            //Leser bytes inn i outbyte[] tabellen og beholder antall bytes returnert
                            retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize);
                            //Forsetter å lese og skrive mens det fortsatt er bytes igjen
                            while (retval == bufferSize)
                            {
                                bw.Write(outbyte);
                                bw.Flush();

                                // Setter start index til slutten av siste buffer og fyller bufferen
                                startIndex += bufferSize;
                                retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize);
                            }

                            //Skriver gjenværende buffer
                            bw.Write(outbyte, 0, (int)retval - 1);
                            bw.Flush();

                            //Lukkter output filen
                            bw.Close();
                            fs.Close();
                        }
                    }

                    //Lukker readeren og lukker mysql kontakten
                    myReader.Close();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        //Henter deltester til test
        public DataSet LastDeltest(string testid)
        {
            try
            {
                string query = "SELECT Deltestid, Deltestnavn, Kritiskgrense, Makspoeng, Semester, Fagnavn FROM deltest, test where deltest.testid='" + testid + "' and deltest.testid = test.testid order by semester, deltestnavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter deltester til valgt test og semester
        public DataSet LastResDeltest(string testid, string semester)
        {
            try
            {
                string query = "SELECT * FROM deltest where testid='" + testid + "' and semester='" + semester + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter Deltest maks poeng
        public DataSet LastDeltestPoeng(string deltestid)
        {
            try
            {
                string query = "SELECT makspoeng FROM deltest where deltestid='" + deltestid + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        //Henter tester til klasse
        public DataSet LastKlasseTest(string klassebet, string klasseår)
        {
            try
            {
                string query = "SELECT klassetest.TestID, Testnavn, Fagnavn from klassetest, test where klassetest.testid=test.testid and betegnelse='" + klassebet + "' and skoleår='" + klasseår + "' order by testnavn";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
#endregion
        #region Slett
        //Sletter et resultat
        public void SlettResultat(string fnummer, string deltestid, string dato)
        {
            try
            {
                string query = "DELETE FROM resultat where FNummer='" + fnummer + "' and DeltestID='" + deltestid + "' AND Dato='" + dato + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Sletter en test
        public void SlettTester(string testid)
        {
            try
            {
                string query = "DELETE FROM test where Testid='" + testid + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke slette test fordi den er brukt et annet sted");
            }
        }

        //Sletter en deltest
        public void SlettDelTest(string Deltestid)
        {
            try
            {
                string query = "DELETE FROM Deltest where Deltestid='" + Deltestid + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke slette deltest fordi den er brukt et annet sted");
            }
        }

        //Sletter en test fra en klasse
        public void SlettMottakerTest(string betegnelse, string skoleår, string testID)
        {
            try
            {
                string query = "DELETE FROM klassetest WHERE Betegnelse='" + betegnelse + "' and TestID='" + testID + "' and Skoleår='" + skoleår + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke slette testen til klassen fordi den er brukt et annet sted");
            }
        }

        //Sletter en fil
        public void SlettFil(string filID)
        {
            try
            {
                string query = "DELETE FROM fil where filID='" + filID + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Sletter filer til en test
        public void SlettFiler(string testid)
        {
            try
            {
                string query = "DELETE FROM fil where testid='" + testid + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Slett en elev med tilhørende klasser og resultater
        public void SlettElever(string FNummer)
        {
            try
            {
                string query = "DELETE FROM elevklasse where FNummer='" + FNummer + "'";
                string query1 = "DELETE FROM resultat where FNummer='" + FNummer + "'";
                string query2 = "DELETE FROM elev WHERE FNummer='" + FNummer + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Slett Klasser
        public void SlettKlasser(string betegnelse, int skoleår)
        {
            try
            {
                //string query = "DELETE FROM klassetest where betegnelse = '" + betegnelse + "' and skoleår= '" + skoleår + "'";
                string query = "DELETE FROM klasse WHERE betegnelse='" + betegnelse + "' AND skoleår='" + skoleår + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke slette klasse fordi den er i brukt et annet sted");
            }
        }

        //Sletter alle tester fra en klasse
        public void SlettKlasseTester(string betegnelse, string skoleår)
        {
            try
            {
                string query = "DELETE FROM klassetest WHERE Betegnelse='" + betegnelse + "' and Skoleår='" + skoleår + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Slett Brukere
        public void SlettBruker(string brukernavn)
        {
            try
            {
                string query = "DELETE FROM bruker WHERE brukernavn='" + brukernavn + "'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Endre
        //Endre Resultat
        public void UpdateResultat(string gmlDeltestID, string FNummer, string dato, string Poeng, string Kommentar)
        {
            try
            {
                string query = "UPDATE Resultat SET Poeng='" + Poeng + "', Kommentar='" + Kommentar + "' WHERE FNummer='" + FNummer + "' AND DeltestID='" + gmlDeltestID + "' AND Dato='" + dato + "'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Endre Tester
        public void UpdateTester(string testid, string nyttestnavn, string fagnavn)
        {
            try
            {
                string query = "UPDATE Test SET Testnavn='" + nyttestnavn + "', FagNavn='" + fagnavn + "' WHERE Testid='" + testid + "'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Endre Deltester
        public void UpdateDelTest(string deltestid, string nyttdeltestnavn, string makspoeng, string kritiskgrense, string semester, string testid)
        {
            try
            {
                string query = "UPDATE Deltest SET Deltestnavn='" + nyttdeltestnavn + "', MaksPoeng='" + makspoeng + "', Kritiskgrense='" + kritiskgrense + "', Semester='" + semester + "', TestID='" + testid + "' WHERE DeltestID='" + deltestid + "'";
                string query1 = "UPDATE Resultat SET Poeng='" + makspoeng + "' WHERE DeltestID='" + deltestid + "' AND Poeng > '" + makspoeng + "'";
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlCommand cmd1 = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    cmd1.CommandText = query1;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    cmd1.Connection = connection;

                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Endre Elever
        public void UpdateElever(string FNummer, string Fornavn, string Etternavn, string kjønn, int aktiv)
        {
            try
            {
                string query = "UPDATE elev SET Fornavn='" + Fornavn + "', Etternavn='" + Etternavn + "', Aktiv='" + aktiv + "' WHERE FNummer='" + FNummer + "'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Endre Klasser
        public void UpdateKlasser(string betegnelse, string nybetegnelse, int skoleår)
        {
            try
            {
                string query = "UPDATE klasse SET betegnelse='" + nybetegnelse + "', skoleår='" + skoleår + "' WHERE betegnelse='" + betegnelse + "'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Endre Brukere
        public void UpdateBrukere(string brukernavn, string nyttbrukernavn, string passord, string fornavn, string etternavn, int type)
        {
            try
            {
                string query = "UPDATE bruker SET Brukernavn='" + nyttbrukernavn + "', passord='" + passord + "', fornavn='" + fornavn + "', etternavn='" + etternavn + "', brukertypeID='" + type + "' WHERE brukernavn='" + brukernavn + "'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Registrer
        //Registrer Resultat
        public void InsertResultat(string FNummer, string DeltestID, string Betegnelse, string Skoleår, string Poeng, string Kommentar, string BrukerID)
        {
            try
            {
                //string query = "Insert into test(Testnavn, Testdato, Fil, FagID)VALUES(@Testnavn, @Testdato, @Fil, @fagID)";
                string query = "Insert into resultat(FNummer, DeltestID, Betegnelse, Skoleår, Poeng, Kommentar, Dato, BrukerID)VALUES(@FNummer, @DeltestID, @Betegnelse, @Skoleår, @Poeng, @Kommentar, CURDATE(), @BrukerID)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@FNummer", FNummer);
                    cmd.Parameters.AddWithValue("@DeltestID", DeltestID);
                    cmd.Parameters.AddWithValue("@Betegnelse", Betegnelse);
                    cmd.Parameters.AddWithValue("@Skoleår", Skoleår);
                    cmd.Parameters.AddWithValue("@Poeng", Poeng);
                    cmd.Parameters.AddWithValue("@Kommentar", Kommentar);
                    cmd.Parameters.AddWithValue("@BrukerID", BrukerID);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke registrere resultat, finnes det allerede?");
            }
        }

        //Registrer Fil
        public void InsertFil(string filnavn, byte[] fil, string filtype, string testID)
        {
            try
            {
                //string query = "Insert into test(Testnavn, Testdato, Fil, FagID)VALUES(@Testnavn, @Testdato, @Fil, @fagID)";
                string query = "Insert into fil(Filnavn, Fil, Filtype, TestID)VALUES(@Filnavn, @Fil, @Filtype, @TestID)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Filnavn", filnavn);
                    cmd.Parameters.AddWithValue("@Fil", fil);
                    cmd.Parameters.AddWithValue("@Filtype", filtype);
                    cmd.Parameters.AddWithValue("@TestID", testID);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Registrer KlasseTest
        public void InsertKlasseTest(string betegnelse, string skoelår, string testid)
        {
            try
            {
                string query = "Insert into klassetest(Betegnelse, Skoleår, TestID)VALUES(@Betegnelse, @Skoleår, @TestID)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Betegnelse", betegnelse);
                    cmd.Parameters.AddWithValue("@Skoleår", skoelår);
                    cmd.Parameters.AddWithValue("@TestID", testid);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke registrere testen på klasse, er den allerede registrert?");
            }
        }
        //Registrer Tester
        public void InsertTester(string testnavn, string fagnavn)
        {
            try
            {
                //string query = "Insert into test(Testnavn, Testdato, Fil, FagID)VALUES(@Testnavn, @Testdato, @Fil, @fagID)";
                string query = "Insert into test(Testnavn, Fagnavn)VALUES(@Testnavn, @Fagnavn)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Testnavn", testnavn);
                    cmd.Parameters.AddWithValue("@Fagnavn", fagnavn);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Registrer Deltest
        public void InsertDeltest(string deltestnavn, string makspoeng, string kritiskgrense, string semester, string testID)
        {
            try
            {
                string query = "Insert into Deltest(Deltestnavn, MaksPoeng, Kritiskgrense, Semester, TestID)VALUES(@Deltestnavn, @MaksPoeng, @Kritiskgrense, @Semester, @TestID)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Deltestnavn", deltestnavn);
                    cmd.Parameters.AddWithValue("@MaksPoeng", makspoeng);
                    cmd.Parameters.AddWithValue("@Kritiskgrense", kritiskgrense);
                    cmd.Parameters.AddWithValue("@Semester", semester);
                    cmd.Parameters.AddWithValue("@TestID", testID);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Registrer Eleverklasse
        public void InsertEleverKlasse(string FNummer, string Betegnelse, int Skoleår)
        {
            try
            {
                string query = "Insert into elevklasse(FNummer, Betegnelse, Skoleår)VALUES(@FNummer, @Betegnelse, @Skoleår)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FNummer", FNummer);
                    cmd.Parameters.AddWithValue("@Betegnelse", Betegnelse);
                    cmd.Parameters.AddWithValue("@Skoleår", Skoleår);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke flytte eleven fordi den finnes i klassen fra før eller klassen ikke eksisterer!");
            }
        }

        //Registrer Elever
        public void InsertElever(string FNummer, string Fornavn, string Etternavn, string Kjønn, string Betegnelse, int Skoleår)
        {
            try
            {
                string query = "Insert into elev(FNummer, Fornavn, Etternavn, Kjønn, Aktiv)VALUES(@FNummer, @Fornavn, @Etternavn, @Kjønn, 1)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@FNummer", FNummer);
                    cmd.Parameters.AddWithValue("@Fornavn", Fornavn);
                    cmd.Parameters.AddWithValue("@Etternavn", Etternavn);
                    cmd.Parameters.AddWithValue("@Kjønn", Kjønn);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();

                }
                InsertEleverKlasse(FNummer, Betegnelse, Skoleår);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        //Registrer Klasser
        public void InsertKlasser(string betegnelse, int skoleår)
        {
            try
            {
                string query = "Insert into klasse(Betegnelse, Skoleår)VALUES(@Betegnelse, @Skoleår)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Betegnelse", betegnelse);
                    cmd.Parameters.AddWithValue("@Skoleår", skoleår);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Kan ikke registrere klassen, finnes den allerede?");
            }
        }

        //Registrer Bruker
        public void InsertBrukere(string brukernavn, string passord, string fornavn, string etternavn, int type)
        {
            try
            {
                string query = "Insert into bruker(Brukernavn, Passord, Fornavn, Etternavn, BrukertypeID)VALUES(@Brukernavn, @Passord, @Fornavn, @Etternavn, @BrukertypeID)";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Brukernavn", brukernavn);
                    cmd.Parameters.AddWithValue("@Passord", passord);
                    cmd.Parameters.AddWithValue("@Fornavn", fornavn);
                    cmd.Parameters.AddWithValue("@Etternavn", etternavn);
                    cmd.Parameters.AddWithValue("@BrukertypeID", type);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception)
            {
                throw new Exception("Bruker ikke registrert, brukernavn eksisterer allerede!");
            }
        }
        #endregion

        //Backup av databasen
        public void Backup()
        {
            try
            {
                //Tids variabler
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                string path = "";

                //Lagre fil diaglog for å velge hvor man skal lagre backup filen
                SaveFileDialog lagreBackup = new SaveFileDialog();
                lagreBackup.FileName = "MySqlBackup" + year + "-" + month + "-" + day +
                    "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                lagreBackup.Filter = ".sql" + " |*" + ".sql" + "|All Files (*.*)|*.*";
                lagreBackup.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //Hvis man trykker ok
                if (lagreBackup.ShowDialog() == DialogResult.OK)
                {
                    //Filbanen til filen
                    path = Path.GetFullPath(lagreBackup.FileName);

                    //Streamwriter for å skrive filen
                    StreamWriter file = new StreamWriter(path);

                    //Prosess info for mysqldump prosessen
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = @"C:\Program Files\MySQL\MySQL Server 5.6\bin\mysqldump.exe";

                    //Hvis mysqldump ikke blir funnet
                    if (!File.Exists(psi.FileName))
                    {
                        MessageBox.Show("Klarte ikke finne mysqldump programmet. Vennligst oppgi filbane til 'mysqldump.exe' programmet!");

                        //Åpne fil dialog for å finne mysql dump filen
                        OpenFileDialog åpneFil = new OpenFileDialog();
                        åpneFil.Title = "Finn mysqldump.exe";

                        //Hvis programfiler finnes
                        if (Directory.Exists(@"C:\Program Files"))
                        {
                            //Setter åpne fil dialogen til å starte der
                            åpneFil.InitialDirectory = @"C:\Program Files";
                        }

                        //Hvis man trykker ok
                        if (åpneFil.ShowDialog() == DialogResult.OK)
                        {
                            psi.FileName = åpneFil.FileName;
                        }
                    }

                    //MySQL dump prosess argumenter
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;

                    //Prosess som kjører mysqldump prosessen
                    Process process = Process.Start(psi);

                    //Utfører prosessen og lukker filen og prosesen når den er ferdig
                    string output;
                    output = process.StandardOutput.ReadToEnd();
                    file.WriteLine(output);
                    process.WaitForExit();
                    file.Close();
                    process.Close();
                }

                //Hvis man avbryter avbryt
                else
                {
                    MessageBox.Show("Avbrutt, ingen backup fil lagret");
                }
            }
            catch (Exception)
            {
                throw new Exception("Feil, klarte ikke gjennomføre backup!");
            }
        }

        //Gjennoppretting av databasen
        public void Restore()
        {
            try
            {
                string path = "";

                //Åpne fil dialog for å velge mysql backup filen
                OpenFileDialog åpneBackupfil = new OpenFileDialog();
                åpneBackupfil.Title = "Velg mysql backup fil";

                //Åpne fil dialog starter på skrivebordet
                åpneBackupfil.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //Hvis man trykker ok
                if (åpneBackupfil.ShowDialog() == DialogResult.OK)
                {
                    //Filbanen til filen man velger
                    path = Path.GetFullPath(åpneBackupfil.FileName);

                    //Leser filen med streamreader og lukker den
                    StreamReader file = new StreamReader(path);
                    string input = file.ReadToEnd();
                    file.Close();

                    //Prosess info for mysql prosessen
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = @"C:\Program Files\MySQL\MySQL Server 5.6\bin\mysql.exe";

                    //Hvis mysql ikke blir funnet
                    if (!File.Exists(psi.FileName))
                    {
                        MessageBox.Show("Klarte ikke finne mysql programmet. Vennligst oppgi filbane til 'mysql.exe' programmet!");

                        //Åpne fil dialog for å finne mysql.exe filen
                        OpenFileDialog åpneFil = new OpenFileDialog();
                        åpneFil.Title = "Finn mysql.exe";

                        //Hvis programfiler starter så settes åpne fil dialog til å starte der
                        if (Directory.Exists(@"C:\Program Files"))
                        {
                            åpneFil.InitialDirectory = @"C:\Program Files";
                        }

                        //Hvis man trykker ok så setter fibanen til den filen man velger
                        if (åpneFil.ShowDialog() == DialogResult.OK)
                        {
                            psi.FileName = åpneFil.FileName;
                        }
                    }

                    //Prosess argumenter
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardOutput = false;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;

                    //Kjører prosessen og lukker den når den er ferdig
                    Process process = Process.Start(psi);
                    process.StandardInput.WriteLine(input);
                    process.StandardInput.Close();
                    process.WaitForExit();
                    process.Close();
                }

                //Hvis man avbryter
                else
                {
                    MessageBox.Show("Ingen fil valgt, gjennoppretting ikke gjennomført!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Feil, klarte ikke gjennomføre gjennoppretting!");
            }
        }
    }
}
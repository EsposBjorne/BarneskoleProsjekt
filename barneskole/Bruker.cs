using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barneskole
{
    //Klasse for bruker som er innlogget
    public class Bruker
    {
        //Bruker variabler
        private string brukerid;
        private string brukernavn;
        private string passord;
        private string fornavn;
        private string etternavn;
        private string btype;

        //Konstruktør
        public Bruker(string brukerid, string brukernavn, string passord, string fornavn, string etternavn, string btype)
        {
            this.brukerid = brukerid;
            setBrukernavn(brukernavn);
            setPassord(passord);
            setFornavn(fornavn);
            setEtternavn(etternavn);
            setBrukertype(btype);
        }

        //Setter brukernavn
        public void setBrukernavn(string brukernavn)
        {
            this.brukernavn = brukernavn;
        }

        //Henter brukernavn
        public string getBrukernavn()
        {
            return brukernavn;
        }

        //Henter brukerid
        public string getBrukerID()
        {
            return brukerid;
        }

        //Setter passord
        public void setPassord(string passord)
        {
            this.passord = passord;
        }

        //Setter fornavn
        public void setFornavn(string fornavn)
        {
            this.fornavn = fornavn;
        }

        //Henter fornavn
        public string getFornavn()
        {
            return fornavn;
        }

        //Setter etternavn
        public void setEtternavn(string etternavn)
        {
            this.etternavn = etternavn;
        }

        //Henter etternavn
        public string getEtternavn()
        {
            return etternavn;
        }

        //Setter brukertype
        public void setBrukertype(string btype)
        {
            this.btype = btype;
        }

        //Henter brukertype
        public string getBrukertype()
        {
            return btype;
        }

        //Skriver ut informasjon om bruker
        public override string ToString()
        {
            return "ID " + brukerid + ", Brukernavn: " + brukernavn + ", Navn: " + fornavn + " " + etternavn + ", " + btype;
        }
    }
}


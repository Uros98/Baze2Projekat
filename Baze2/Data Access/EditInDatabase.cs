using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2.Data_Access
{
    public class EditInDatabase
    {

        public bool EditLokal(int id,string naziv,string grad,string ulica,int broj)
        {
            using(var db = new KladionicaModelContainer())
            {
                Lokal lokal= db.Lokals.Where(c => c.Id.Equals(id)).FirstOrDefault();

                try
                {
                    lokal.lokNaz = naziv;
                    lokal.lokGr = grad;
                    lokal.lokUl = ulica;
                    lokal.lokBr = broj;
                    db.Entry(lokal).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditBarmen(int id,string ime,string prezime,int lokalId,string brSektor)
        {


            using (var db = new KladionicaModelContainer())
            {
                Lokal l = db.Lokals.Where(c => c.Id.Equals(lokalId)).FirstOrDefault();
                if (l == null) return false;

                Barmen barmen = null;

                foreach(Radnik item in db.Radniks)
                {
                    if (item.Id.Equals(id))
                    {
                        if(item is Barmen)
                        {
                            barmen = (Barmen)item;
                            break;
                        }
                    }
                }
                try
                {
                    barmen.Id = id;
                    barmen.radIme = ime;
                    barmen.radPrz = prezime;
                    barmen.LokalId = lokalId;
                    barmen.barSektor = brSektor;
                    db.Entry(barmen).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public bool EditOperater(int id, string ime, string prezime, int lokalId, string oRacunar)
        {


            using (var db = new KladionicaModelContainer())
            {
                Lokal l = db.Lokals.Where(c => c.Id.Equals(lokalId)).FirstOrDefault();
                if (l == null) return false;

                Operater operater = null;

                foreach (Radnik item in db.Radniks)
                {
                    if (item.Id.Equals(id))
                    {
                        if (item is Operater)
                        {
                            operater = (Operater)item;
                            break;
                        }
                    }
                }
                try
                {
                    operater.Id = id;
                    operater.radIme = ime;
                    operater.radPrz = prezime;
                    operater.LokalId = lokalId;
                    operater.opRacunar = oRacunar;
                    db.Entry(operater).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool EditKorisnik(int id,string ime,string prezime)
        {
            using(var db = new KladionicaModelContainer())
            {
                Korisnik korisnik = db.Korisniks.Where(c => c.Id.Equals(id)).FirstOrDefault();

                try
                {
                    korisnik.kIme = ime;
                    korisnik.kPrz = prezime;
                    db.Entry(korisnik).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditTiket(int id,double kvota,double dobitak,int kId,int oId)
        {
            using (var db = new KladionicaModelContainer())
            {
                Tiket tiket = db.Tikets.Where(c => c.Id.Equals(id)).FirstOrDefault();

                try
                {
                    tiket.tKv = kvota;
                    tiket.tDob = dobitak;
                    db.Entry(tiket).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditPice(int id,string naziv)
        {
            using(var db = new KladionicaModelContainer())
            {
                Pice pice = db.Pices.Where(c => c.Id.Equals(id)).FirstOrDefault();

                try
                {
                    pice.piceNaz = naziv;
                    db.Entry(pice).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditDogadjaj(int id,double kvota,int tId)
        {
            using(var db = new KladionicaModelContainer())
            {
                Dogadjaj dogadjaj = db.Dogadjajs.Where(c => c.Id.Equals(id)).FirstOrDefault();
                Tiket tiket = db.Tikets.Where(c => c.Id.Equals(tId)).FirstOrDefault();

                if(tiket == null)
                {
                    return false;
                }

                try
                {
                    dogadjaj.Id = id;
                    dogadjaj.dogKv = kvota;
                    dogadjaj.Tiket = tiket;
                    db.Entry(dogadjaj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

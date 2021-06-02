using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2.Data_Access
{
    public class AddInDatabase
    {
        public int AddLokal(int id, string naziv, string grad, string ulica, int broj)
        {
            Lokal lokal;

            using (KladionicaModelContainer db = new KladionicaModelContainer())
            {
                try
                {
                    lokal = db.Lokals.Where(c => c.Id.Equals(id)).FirstOrDefault();
                    if (lokal != null)
                    {
                        return 2;
                    }
                    else
                    {
                        lokal = new Lokal
                        {
                            Id = id,
                            lokNaz = naziv,
                            lokGr = grad,
                            lokUl = ulica,
                            lokBr = broj,

                        };

                        db.Lokals.Add(lokal);
                        db.SaveChanges();

                        return 0;
                    }


                }
                catch
                {
                    return 1;
                }
            }

        }

        public int AddBarmen(int id, string ime, string prezime, int lokalId, string brSektor)
        {
            Barmen barmen;
            Radnik radnik;

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    Lokal lokal = db.Lokals.Where(c => c.Id.Equals(lokalId)).FirstOrDefault();
                    if (lokal == null)
                    {
                        return 3;
                    }

                    radnik = db.Radniks.Where(c => c.Id.Equals(id)).FirstOrDefault();
                    if (radnik != null)
                    {
                        return 2;
                    }
                    else
                    {

                        barmen = new Barmen
                        {
                            Id = id,
                            radIme = ime,
                            radPrz = prezime,
                            LokalId = lokalId,
                            barSektor = brSektor
                        };
                    }
                    db.Radniks.Add(barmen);
                    db.SaveChanges();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public int AddOperater(int id, string ime, string prezime, int lokalId, string oRacunar)
        {
            Operater operater;
            Radnik radnik;

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    Lokal lokal = db.Lokals.Where(c => c.Id.Equals(lokalId)).FirstOrDefault();
                    if (lokal == null)
                    {
                        return 3;
                    }

                    radnik = db.Radniks.Where(c => c.Id.Equals(id)).FirstOrDefault();
                    if (radnik != null)
                    {
                        return 2;
                    }
                    else
                    {

                        operater = new Operater
                        {
                            Id = id,
                            radIme = ime,
                            radPrz = prezime,
                            LokalId = lokalId,
                            opRacunar = oRacunar
                        };
                    }
                    db.Radniks.Add(operater);
                    db.SaveChanges();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public int AddKorisnik(int id, string ime, string prezime)
        {
            Korisnik korisnik;

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    korisnik = db.Korisniks.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    if (korisnik != null)
                    {
                        return 2;
                    }
                    else {
                        korisnik = new Korisnik
                        {
                            Id = id,
                            kIme = ime,
                            kPrz = prezime
                        };
                        db.Korisniks.Add(korisnik);
                        db.SaveChanges();
                        return 0;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        public int AddTiket(int id, double kvota, double dobitak, int kId, int oId)
        {
            Tiket tiket;

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    tiket = db.Tikets.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    if (tiket != null)
                    {
                        return 2;
                    }
                    else
                    {
                        int kontrolna = 0;
                        foreach (Radnik item in db.Radniks)
                        {
                            if (item.Id == oId)
                            {
                                if (item is Operater)
                                {
                                    kontrolna = 1;
                                    break;
                                }
                            }
                        }
                        if (kontrolna == 0)
                        {
                            return 3;
                        }

                        int kontrolna1 = 0;
                        foreach (Korisnik item in db.Korisniks)
                        {
                            if (item.Id == kId)
                            {
                                kontrolna1 = 1;
                                break;
                            }
                        }
                        if (kontrolna1 == 0)
                        {
                            return 4;
                        }

                        tiket = new Tiket
                        {
                            Id = id,
                            tKv = kvota,
                            tDob = dobitak,
                            KorisnikId = kId,
                            OperaterId = oId
                        };
                        db.Tikets.Add(tiket);
                        db.SaveChanges();
                        return 0;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        public int AddPice(int id, string naziv)
        {
            Pice pice;

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    pice = db.Pices.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    if (pice != null)
                    {
                        return 2;
                    }
                    else
                    {
                        pice = new Pice
                        {
                            Id = id,
                            piceNaz = naziv
                        };

                        db.Pices.Add(pice);
                        db.SaveChanges();
                        return 0;
                    }
                }
                catch
                {
                    return 1;
                }

            }

        }

        public int AddDogadjaj(int id, double kvota, int tId)
        {
            Dogadjaj dogadjaj;

            
                using (var db = new KladionicaModelContainer())
                {
                    try
                    {
                        dogadjaj = db.Dogadjajs.Where(c => c.Id.Equals(id)).FirstOrDefault();

                        
                            Tiket tiket = db.Tikets.Where(c => c.Id.Equals(tId)).FirstOrDefault();

                            if (tiket == null)
                            {
                                return 2;
                            }

                            dogadjaj = new Dogadjaj
                            {
                                Id = id,
                                dogKv = kvota,
                                Tiket = tiket
                            };

                            db.Dogadjajs.Add(dogadjaj);
                            db.SaveChanges();
                            return 0;
                        
                    }
                    catch
                    {
                        return 1;
                    }
                }

            }
        }
    }


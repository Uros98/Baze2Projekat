using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2.Data_Access
{
    public class DeleteFromDatabase
    {
        public int DeleteLokal(int id)
        {
            try
            {
                using (var db = new KladionicaModelContainer())
                {
                    Lokal lokal = db.Lokals.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    foreach (Radnik item in db.Radniks)
                    {
                        if (item.LokalId == id)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;

                            if (item is Operater)
                            {
                                foreach (Tiket item1 in db.Tikets)
                                {
                                    if (item1.OperaterId == item.Id)
                                    {
                                        db.Entry(item1).State = System.Data.Entity.EntityState.Deleted;
                                    }
                                }
                            } 
                        }

                    }

                

                    db.Lokals.Remove(lokal);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int DeleteBarmen(int id)
        {
            try
            {
                using (var db = new KladionicaModelContainer())
                {
                    Radnik radnik = db.Radniks.Where(c => c.Id.Equals(id)).FirstOrDefault();
                    db.Radniks.Remove(radnik);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int DeleteOperater(int id)
        {
            try
            {
                using(var db = new KladionicaModelContainer())
                {
                    Radnik radnik = db.Radniks.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    foreach(Tiket item in db.Tikets)
                    {
                        if(item.OperaterId == id)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }

                    db.Radniks.Remove(radnik);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int DeleteKorisnik(int id)
        {
            try
            {

                using(var db = new KladionicaModelContainer())
                {
                    foreach(Tiket item in db.Tikets)
                    {
                        if (item.KorisnikId.Equals(id))
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }                   

                    Korisnik korisnik = db.Korisniks.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    db.Korisniks.Remove(korisnik);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }

        }

        public int DeleteTiket(int id)
        {
            try
            {
                using(var db = new KladionicaModelContainer())
                {
                    Tiket tiket = db.Tikets.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    foreach(Dogadjaj item in db.Dogadjajs)
                    {
                        if(item.Tiket.Id == id)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }

                    db.Tikets.Remove(tiket);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int DeletePice(int id)
        {
            try
            {
                using(var db = new KladionicaModelContainer())
                {
                    Pice pice = db.Pices.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    db.Pices.Remove(pice);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int DeleteDogadjaj(int id)
        {
            try
            {
                using(var db = new KladionicaModelContainer())
                {
                    Dogadjaj dogadjaj = db.Dogadjajs.Where(c => c.Id.Equals(id)).FirstOrDefault();

                    db.Dogadjajs.Remove(dogadjaj);
                    db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

    }
}

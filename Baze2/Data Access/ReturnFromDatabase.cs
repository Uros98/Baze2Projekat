using Baze2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2.Data_Access
{
    public class ReturnFromDatabase
    {
        public List<Lokal> GetLokale()
        {
            List<Lokal> izlaz = new List<Lokal>();

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach (Lokal item in db.Lokals)
                    {
                        izlaz.Add(item);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        public List<Radnik> GetRadnike()
        {
            List<Radnik> izlaz = new List<Radnik>();

            using(var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach (Radnik item in db.Radniks)
                    {
                        izlaz.Add(item);
                    }
                }
                catch
                {
                    return null;
                }

                }
                return izlaz;
            }

        public List<Barmen> GetBarmene()
        {
            List<Barmen> izlaz = new List<Barmen>();

            using(var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach(Radnik item in db.Radniks)
                    {
                        if (item is Barmen)
                        {
                            izlaz.Add((Barmen)item);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        public List<Operater> GetOperatere()
        {
            List<Operater> izlaz = new List<Operater>();

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach (Radnik item in db.Radniks)
                    {
                        if (item is Operater)
                        {
                            izlaz.Add((Operater)item);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        public List<Korisnik> GetKorisnike()
        {
            List<Korisnik> izlaz = new List<Korisnik>();

            using(var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach(Korisnik item in db.Korisniks)
                    {
                        izlaz.Add(item);
                    }

                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        public List<Tiket> GetTikete()
        {
            List<Tiket> izlaz = new List<Tiket>();

            using(var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach(Tiket item in db.Tikets)
                    {
                        izlaz.Add(item);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        public List<Pice> GetPica()
        {
            List<Pice> izlaz = new List<Pice>();

            using(var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach(Pice item in db.Pices)
                    {
                        izlaz.Add(item);
                    }
                }
                catch
                {
                    return null;
                }
            }
            return izlaz;
        }

        //public List<Dogadjaj> GetDogadjaje()
        //{
        //    List<Dogadjaj> izlaz = new List<Dogadjaj>();

        //    using(var db = new KladionicaModelContainer())
        //    {
        //        try
        //        {
        //            foreach(Dogadjaj item in db.Dogadjajs)
        //            {
        //                izlaz.Add(item);
        //            }
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    return izlaz;
        //}


        public List<DogadjajModel> GetDogadjaje()
        {
            List<Dogadjaj> izlaz = new List<Dogadjaj>();

            using (var db = new KladionicaModelContainer())
            {
                try
                {
                    foreach (Dogadjaj item in db.Dogadjajs)
                    {
                        izlaz.Add(item);
                    }
                }
                catch
                {
                    return null;
                }


                List<DogadjajModel> lista = new List<DogadjajModel>();
                DogadjajModel temp;

                foreach (Dogadjaj item in izlaz)
                {
                    temp = new DogadjajModel(item.Id, item.dogKv, item.Tiket.Id);
                    lista.Add(temp);
                }


                return lista;
            }
            
        }



    }
}
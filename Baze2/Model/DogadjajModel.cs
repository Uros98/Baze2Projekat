using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze2.Model
{
    public class DogadjajModel
    {
        public int Id { get; set; }
        public double dogKv { get; set; }
        public int tId { get; set; }

        public DogadjajModel(int id,double kv,int tid)
        {
            Id = id;
            dogKv = kv;
            tId = tid;
        }
    }
}

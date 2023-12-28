﻿using KALORI.DATA.Entities;
using Kalori_DAL.Context;
using Kalori_DAL.ilk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalori.Service.Concrete
{
    public class KullaniciOgunService
    {
        public KullaniciOgun GetKullaniciOgunWithOgunYemekleri(int kullaniciOgunId)
        {
            KullaniciOgunDAL kullaniciOgunDAL = new KullaniciOgunDAL();
            return kullaniciOgunDAL.GetKullaniciOgunWithOgunYemekleri(kullaniciOgunId);

        }
        public void Create(KullaniciOgun kullaniciOgun)
        {
            KullaniciOgunDAL kullaniciOgunDAL = new KullaniciOgunDAL();
            kullaniciOgunDAL.Create(kullaniciOgun);
        }

        public List<KullaniciOgun> GetAll()
        {
            KullaniciOgunDAL kullaniciOgunDAL = new KullaniciOgunDAL();
            return kullaniciOgunDAL.GetAll();
        }

        public List<KullaniciOgun> GetAllWhere(Expression<Func<KullaniciOgun, bool>> expression)
        {
            KullaniciOgunDAL kullaniciOgunDAL = new KullaniciOgunDAL();
            return kullaniciOgunDAL.GetAllWhere(expression);
        }


        public void Update(KullaniciOgun kullaniciOgun)
        {
            KullaniciOgunDAL kullaniciOgunDAL = new KullaniciOgunDAL();
            kullaniciOgunDAL.Update(kullaniciOgun);
        }
        
    }
}
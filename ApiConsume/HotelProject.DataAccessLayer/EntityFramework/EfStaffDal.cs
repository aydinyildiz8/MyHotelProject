﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetLastFourStaff()
        {
            using var context = new Context();
            var value = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
            return value;

        }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staffs.Count();
            return value;
        }
    }
}

using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Models;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int AppUserCount()
        {
            var context = new Context();
            var value = context.Users.Count();
            return value;
        }

        public List<ResultAppUserViewModel> UserListWithWorkLocation()
        {
            var context = new Context();
            var values = context.Users.Include(x => x.workLocation).Select(y => new ResultAppUserViewModel
            {
                ImageUrl = y.ImageUrl,
                Name = y.Name,
                UserName = y.UserName,
                Surname = y.Surname,
                Email = y.Email,
                WorkLocationName = y.workLocation.WorkLocationName,
                WorkLocationCity = y.workLocation.WorkLocationCity
            }).ToList();

            return values;
        }
    }
}

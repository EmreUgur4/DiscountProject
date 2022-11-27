using DiscountProject.Business.Interfaces;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;

        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}

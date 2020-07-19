using Aula2AspManha.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2AspManha.DAL
{

       public class AddressDAO
    {

        private readonly Context DbContext;

        public AddressDAO(Context _dbContext)
        {
            DbContext = _dbContext;
        }

        public List<Address> ListAddress()
        {
            return DbContext.Enderecos.ToList();
        }

        public bool SaveAddress(Address newAddress)
        {
            if (newAddress.Cep != null)
            {
                DbContext.Enderecos.Add(newAddress);
                DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

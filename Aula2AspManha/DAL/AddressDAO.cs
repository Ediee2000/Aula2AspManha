using Aula2AspManha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Ediee Pinheiro

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

        public List<Address> GetAddress(string Cep)
        {
            Cep = Cep.Substring(0, 5) + "-" + Cep.Substring(5, 3);
            return DbContext.Enderecos.Where(b => b.Cep == Cep).ToList<Address>();
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

        public Address ModifyAddress(Address ModifAdd)
        {
            Address Temp = DbContext.Enderecos.Single(b => b.Id == ModifAdd.Id);
            Temp.Cep = ModifAdd.Cep;
            Temp.Logradouro = ModifAdd.Logradouro;
            Temp.Bairro = ModifAdd.Bairro;
            Temp.Localidade = ModifAdd.Localidade;
            Temp.Uf = ModifAdd.Uf;
            Temp.Unidade = ModifAdd.Unidade;
            Temp.Ibge = ModifAdd.Ibge;
            Temp.Gia = ModifAdd.Gia;
            Temp.Complemento = ModifAdd.Complemento;

            DbContext.SaveChanges();

            return Temp;
        }

        public bool DeleteAddress(int id)
        {
            try
            {
                Address Temp = DbContext.Enderecos.Single(b => b.Id == id);
                DbContext.Enderecos.Remove(Temp);
                DbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

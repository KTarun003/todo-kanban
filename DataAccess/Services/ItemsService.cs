using DataAccess.Data;
using DataAccess.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ItemsService
    {
        private readonly AppDbContext appDbContext;

        public ItemsService()
        {
            appDbContext= new AppDbContext();
        }

        public List<Item> GetItems(int listId)
        {
            try
            {
                return appDbContext.ItemRepo.FindAsync(x => x.ListId == listId).Result.ToList();
            }
            catch (Exception)
            {
                return new List<Item>();
            }
        }

        public void Save(Item item)
        {
            if (item == null) return;
            try
            {
                
                if (string.IsNullOrEmpty(item.Id))
                {
                    appDbContext.ItemRepo.InsertOne(item);
                }
                else
                {
                    var res = appDbContext.ItemRepo.ReplaceOne(x => x.Id.Equals(item.Id),item);
                }
            }
            catch (Exception)
            {
                return;
            }           
        }

        public void Save(List<Item> items)
        {
            if (items == null) return;
            try
            {
               foreach(var item in items)
               {
                    appDbContext.ItemRepo.ReplaceOne(x => x.Id.Equals(item.Id), item);
               }                 
            }
            catch (Exception)
            {
                return;
            }
        }


        public void Delete(Item item)
        {
            if (item == null) return;
            try
            {
                var res = appDbContext.ItemRepo.DeleteOne(x => x.Id.Equals(item.Id));                
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApplication1.Models
{
    public class UrlRepository : IItemRepository
    {
        private List<Item> _urls;

        public UrlRepository()
        { 
            ItemManager mana = new ItemManager();
            _urls = mana.getListUrl();
        }

        public IQueryable<Item> GetAll()
        {
            return _urls.AsQueryable();
        }


        public Item Add(Item url)
        {
            _urls.Add(url);
            return url;
        }
    }
}
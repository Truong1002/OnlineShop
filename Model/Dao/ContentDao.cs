using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public Content GetById(long id)
        {
            return db.Contents.Find(id);
        }

        public long Create(Content content)
        {
            //Xử lí alias
            if (!string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.ToUnsignString(content.Name);
            }
            db.Contents.Add(content);
            db.SaveChanges();
            //Xử lý tag
            if(!string.IsNullOrEmpty(content.Tags))
            {
                string[] tags = content.Tags.Split(',');
                foreach(var tag in tags)
                {

                }
            }
            return content.ID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupIsabellaData
{
    class Item
    {
        string color;
        string size;
        string article;

        public Item(string color, string size, string article)
        {
            this.color = color;
            this.size = size;
            this.article = article;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return color;
        }

        public void setSize(string size)
        {
            this.size = size;
        }

        public string getSize()
        {
            return size;
        }

        public void setArticle(string article)
        {
            this.article = article;
        }

        public string getArticle()
        {
            return article;
        }
    }
}

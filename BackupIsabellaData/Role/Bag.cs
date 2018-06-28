using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupIsabellaData
{
    class Bag
    {
        private int bag_id;
        private DateTime date;
        private int qty;
        private int bagNo;
        private bool issued;
        private int place_id;
        private Department dept;

        private Item[] items;

        public Bag(int bag_id)
        {
            this.bag_id = bag_id;
        }

        public Bag(DateTime date, int qty, Department dept, int bagNo)
        {
            this.date = date;
            this.qty = qty;
            this.bagNo = bagNo;
            this.issued = false;
            this.place_id = 0;
            this.dept = dept;
            items = new Item[qty];
        }

        public bool addItem(int index, string color, string size, string article)
        {
            if (index >= 0 && index < qty)
            {
                if (items[index] == null)
                {
                    items[index] = new Item(color, size, article);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void setBag_id(int bag_id)
        {
            this.bag_id = bag_id;
        }

        public int getBag_id()
        {
            return bag_id;
        }

        public void setBagNo(int bagNo)
        {
            this.bagNo = bagNo;
        }

        public int getBagNo()
        {
            return bagNo;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public DateTime getDate()
        {
            return date;
        }

        public void setQty(int qty)
        {
            this.qty = qty;
        }

        public int getQty()
        {
            return qty;
        }

        public int getPlace_id()
        {
            return place_id;
        }

        public void setDept(Department dept)
        {
            this.dept = dept;
        }

        public Department getDept()
        {
            return dept;
        }

        public Item[] getItems()
        {
            return items;
        }

        public void issue(int place_id)
        {
            issued = true;
            this.place_id = place_id;
        }

        public bool isIssued()
        {
            return issued;
        }
    }
}

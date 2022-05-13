using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HProtest_BLL.ClassView
{
    public class Products
    {
        public  int ID;
        public  string Name;
        public  string Video;
        public  string Desp;
        public  int Visited;
        public  DateTime InserDate;
        public  string Count;
        public  string Point;
        public  bool Luxe;
        public  string AboutProduct;
        public  bool Size;
        public  string MainPic;
        public  long Price;
        public ProductType ProductType=new ProductType();

    }

    public class ProductType
    {
        public int ID;
        public string type;
        public int ParentID;
    }
   
}

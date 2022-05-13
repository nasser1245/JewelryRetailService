using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HProtest_BLL.AccessLevel
{
    public  class AccessLevel
    {
        public bool ProductAgent { get; set; }
        public bool NewsAgent { get; set; }
        public bool SellAgent { get; set; }
        public bool UserAgent { get; set; }
        public bool AdvertiseAgent { get; set; }
        public bool LibraryAgent { get; set; }
        public bool SupportAgent { get; set; }
        public bool ManagerAgent { get; set; }

        public AccessLevel()
        {
            this.LibraryAgent = this.AdvertiseAgent = this.NewsAgent = this.ProductAgent
                = this.SellAgent =ManagerAgent= false;

            
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PoliticsAndWarAPIAccess.Caching
{
    public class CacheModel
    {
        public virtual int _id { get; set; }
        private DateTime? _createdDate { get; set; }
        public DateTime CreatedDate
        {
            get
            {
                if (_createdDate == null)
                {
                    _createdDate = DateTime.Now;
                }
                return _createdDate.Value;
            }
            set
            {
                this._createdDate = value;
            }
        }
    }
}

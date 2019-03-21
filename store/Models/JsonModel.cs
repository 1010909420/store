using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class JsonModel
    {
        public JsonModel(bool success, String message, Object data, String code = null)
        {
            this.success = success;
            this.message = message;
            this.data = data;

            this.code = code;
        }

        public bool success
        {
            get;
            set;
        }

        public String code
        {
            get;
            set;
        }

        public String message
        {
            get;
            set;
        }

        public Object data
        {
            get;
            set;
        }
    }
}

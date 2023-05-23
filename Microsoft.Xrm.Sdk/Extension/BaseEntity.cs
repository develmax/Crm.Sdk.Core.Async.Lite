using Newtonsoft.Json;
using System;

namespace Microsoft.Xrm.Sdk.Extension
{
    public class BaseEntity
    {
        [JsonIgnore]
        protected int index = -1;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public virtual string Preview{ get; set; }

        public virtual Guid Id { get; set; }
    }
}

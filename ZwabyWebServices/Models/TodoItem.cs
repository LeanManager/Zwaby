using System;

namespace ZwabyWebServices.Models
{
    public class TodoItem
    {
		// The database generates the Id when a TodoItem is created.

		public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsComplete
        {
            get;
            set;
        }
    }
}

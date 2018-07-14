using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasker.Web.DataAccess.Repository
{
    public class BaseRepository
    {
        protected readonly TaskerDbContext Context;

        public BaseRepository(TaskerDbContext context)
        {
            this.Context = context;
        }
    }
}

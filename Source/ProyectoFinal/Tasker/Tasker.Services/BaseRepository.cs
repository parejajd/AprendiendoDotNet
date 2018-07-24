using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.DataAccess;

namespace Tasker.Services
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

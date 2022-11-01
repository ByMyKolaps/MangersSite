using System;
using System.Collections.Generic;
using System.Text;

namespace MangersDAL.Repos
{
    public abstract class Repo
    {
        protected MangersContext _context;

        protected Repo(MangersContext context)
        {
            _context = context;
        }
        protected Repo()
        {
            _context = (MangersContext)Services.CollectionServices.GetService(typeof(MangersContext));
        }
    }
}

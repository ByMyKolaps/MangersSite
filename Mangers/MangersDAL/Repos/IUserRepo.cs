using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangersDAL
{
    public interface IUserRepo
    {
        public User GetUser(string name);
    }
}

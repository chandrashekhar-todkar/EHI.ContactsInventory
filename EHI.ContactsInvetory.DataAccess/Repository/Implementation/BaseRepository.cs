using System;
using System.Collections.Generic;
using System.Text;

namespace EHI.ContactsInvetory.DataAccess.Repository
{
    public class BaseRepository
    {
        protected ContactContext _dbContext = null;

        public BaseRepository(ContactContext dbModel)
        {
            _dbContext = dbModel;
        }
    }
}

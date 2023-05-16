using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
     class DBContext
    {
        private static StroymasterEntities _context;

        public static StroymasterEntities GetContex()
        {
            if(_context == null) 
            {
                _context = new StroymasterEntities();
            }
            return _context;    
        }
    }
}

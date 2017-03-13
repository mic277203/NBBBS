using NBBBS.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NBBBS.Service
{
    public class SysUserService : ISysUserService
    {
        private readonly NBBBSContext _context;

        public SysUserService(NBBBSContext context)
        {
            _context = context;
        }
        public List<SysUser> List()
        {
            return _context.SysUsers.ToList();

        }
        public void Add(SysUser model)
        {
            _context.SysUsers.Add(model);
            _context.SaveChanges();
        }
    }
}

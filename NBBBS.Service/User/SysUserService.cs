using NBBBS.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NBBBS.Service.User
{
    public class SysUserService : ISysUserService
    {
        private NBBBSContext _context;
        public SysUserService(NBBBSContext content)
        {
            this._context = content;
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

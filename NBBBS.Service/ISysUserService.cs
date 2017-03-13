using NBBBS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBBBS.Service
{
    public interface ISysUserService
    {
        List<SysUser> List();
        void Add(SysUser model);
    }
}

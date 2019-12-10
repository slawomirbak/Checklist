using Checklist.DataLogic.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic
{
    public class DefaultContext: IdentityDbContext<IdentityUser>
    {
        public DefaultContext(DbContextOptions <DefaultContext> options): base(options)
        {
        }
    }
}

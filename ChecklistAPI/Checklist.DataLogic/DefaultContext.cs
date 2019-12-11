using Checklist.DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic
{
    public class DefaultContext: DbContext
    {
        public DefaultContext(DbContextOptions <DefaultContext> options): base(options)
        {
        }
    }
}

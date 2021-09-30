using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventdotNetFrameWork.Models
{
    public class mContext:IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CorsoCF.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Azienda> Aziende { get; set; }
        public DbSet<Impiegato> Impiegati { get; set; }

        // costruttore che fa uso di una connessione già 
        // specificata in web.config
        public DatabaseContext() : 
            base("DefaultConnection") { }

    }
}
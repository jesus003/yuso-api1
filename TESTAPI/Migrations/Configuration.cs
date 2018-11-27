namespace TESTAPI.Migrations
{
    using TESTAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TESTAPI.Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SampleEF6.Models.EFContext";
        }

        protected override void Seed(TESTAPI.Models.EFContext context)
        {
            context.Eventos.AddOrUpdate(
              p => p.descripcion,
             new Evento { id = "4b8fe720-916a-42ed-a6d7-0616cc72c52c", user = "0", fecha = "2017-01-01", personas = 10, categoria = "Fiesta Niños", descripcion = "Evento 1" },
               new Evento { id = "4b8fe720-916a-42ed-a6d7-0616cc72c52c", user = "0", fecha = "2017-01-01", personas = 10, categoria = "Fiesta Niños", descripcion = "Evento 1" },
             new Evento { id = "4b8fe720-916a-42ed-a6d7-0616cc72c52c", user = "0", fecha = "2017-01-01", personas = 10, categoria = "Fiesta Niños", descripcion = "Evento 1" }
            );
        }
    }
}
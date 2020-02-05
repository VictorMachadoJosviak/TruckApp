using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckApp.Domain.Entities;

namespace TruckApp.Infra.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext db)
        {
            if (!db.Models.Any())
            {
                db.Models.Add(new Model
                {
                    Name = "FH"
                });

                db.Models.Add(new Model
                {
                    Name = "FM"
                });
            }

            db.SaveChanges();
        }
    }
}

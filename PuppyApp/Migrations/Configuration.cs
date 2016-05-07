namespace PuppyApp.Migrations {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<PuppyServiceContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PuppyServiceContext context) {
            //  This method will be called after migrating to the latest version.

            context.UserProfiles.AddOrUpdate(
                new UserProfile { Id = 101, Name = "Rodrigo Vigil", Leaves = new Location(-27, -55) },
                new UserProfile { Id = 102, Name = "Luis Caranik", Leaves = new Location(-28, -55) },
                new UserProfile { Id = 103, Name = "Alberto Pinto", Leaves = new Location(-29, -55) }
                );


            Pet[] pets = new Pet[] {
                new Pet { Id = 201, Name = "Mascot 1", Specie = "Dog", Modified = DateTime.Now, OwnerId = 101 },
                new Pet { Id = 202, Name = "Mascot 2", Specie = "Cat", Modified = DateTime.Now, OwnerId = 102 },
                new Pet { Id = 203, Name = "Mascot 3", Specie = "Spider", Modified = DateTime.Now, OwnerId = 103 }
            };
            context.Pets.AddOrUpdate(pets);

            context.Deseases.AddOrUpdate(
                new Desease { Id = 401, Title = "Illness 1", Description = "Illness Description 1" },
                new Desease { Id = 402, Title = "Illness 2", Description = "Illness Description 2" }
                );

            context.HistoryPoints.AddOrUpdate(
                new HistoryPoint {
                    Id = 301,
                    Title = "Death",
                    When = DateTime.Now.AddYears(-3),
                    Location = new Location(-27.369633084667676, -55.893845558166504),
                    PetId = 201,
                    IllnessId = 401
                },
                new HistoryPoint {
                    Id = 301,
                    Title = "Death",
                    When = DateTime.Now.AddYears(-3),
                    Location = new Location(-27.369594973296245, -55.886893272399895),
                    PetId = 202,
                    IllnessId = 402
                }
                );
        }
    }
}

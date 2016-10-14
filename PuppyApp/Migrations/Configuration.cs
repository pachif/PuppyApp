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
            UserProfile profile1, profile2;
            context.UserProfiles.AddOrUpdate(
                profile1=new UserProfile { Id = 101, Name = "Rodrigo Vigil", Leaves = new Location(-27, -55) },
                profile2=new UserProfile { Id = 102, Name = "Luis Caranik", Leaves = new Location(-28, -55) });

            Models.Owner owner1, owner2;
            context.Owners.AddOrUpdate(
                owner1 = new Models.Owner { Id = 501, FullName = "Perez, Carlos", IDCard = "25565489" },
                owner2 = new Models.Owner { Id = 502, FullName = "Gonzales, Juan", IDCard = "11256998" },
                new Models.Owner { Id = 503, FullName = "Pinto, Alberto", IDCard = "11256498" }
                );

            Pet pet1, pet2, pet3;
            Pet[] pets = new Pet[] {
                pet1=new Pet { Id = 201, Name = "Mascot 1", Specie = "Dog", BirthDate = DateTime.Now.AddDays(-4), Modified = DateTime.Now, Owner = owner1 },
                pet2=new Pet { Id = 202, Name = "Mascot 2", Specie = "Cat", BirthDate = DateTime.Now.AddDays(-9), Modified = DateTime.Now, Owner = owner2 },
                pet3=new Pet { Id = 203, Name = "Mascot 3", Specie = "Spider", BirthDate = DateTime.Now.AddDays(-3), Modified = DateTime.Now, OwnerId = 503 }};
            context.Pets.AddOrUpdate(pets);

            Desease des1, des2;
            context.Deseases.AddOrUpdate(
                des1=new Desease { Id = 401, Title = "Illness 1", Description = "Illness Description 1" },
                des2=new Desease { Id = 402, Title = "Illness 2", Description = "Illness Description 2" }
                );

            context.HistoryPoints.AddOrUpdate(
                new HistoryPoint {
                    Id = 301,
                    Title = "Death",
                    When = DateTime.Now.AddYears(-3),
                    Location = new Location(-27.369633084667676, -55.893845558166504),
                    Mascot = pet1,
                    Illness = des1,
                    Modified = DateTime.Now
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

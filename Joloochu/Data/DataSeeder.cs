using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joloochu.Data
{
    public class DataSeeder
    {
        public static void SeedData(JoloochuContext context)
        {

            if (!context.Regions.Any())
            {
                context.Regions.Add(new Region() { id = 1, NameRus = "Чуй" });
                context.Regions.Add(new Region() { id = 2, NameRus = "Ош" });
                context.Regions.Add(new Region() { id = 3, NameRus = "Нарын" });
                context.Regions.Add(new Region() { id = 4, NameRus = "Ысык-Кол" });
                context.Regions.Add(new Region() { id = 5, NameRus = "Талас" });
                context.Regions.Add(new Region() { id = 6, NameRus = "Баткен" });
                context.Regions.Add(new Region() { id = 7, NameRus = "Жалал-Абад" });
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                context.Cities.Add(new City() { NameRus = "Бишкек", regionId = 1 });
                context.Cities.Add(new City() { NameRus = "Ош", regionId = 2 });
                context.SaveChanges();
            }

            if (!context.Districts.Any())
            {
                context.Districts.Add(new District() { id = 1, NameRus = "Кемин", regionId = 1 });
                context.Districts.Add(new District() { id = 2, NameRus = "Алай", regionId = 2 });
                context.SaveChanges();
            }

            if (!context.Villages.Any())
            {
                context.Villages.Add(new Village() { NameRus = "Сары-Озон", districtId = 1 });
                context.Villages.Add(new Village() { NameRus = "Сары-Таш", districtId = 2 });
                context.SaveChanges();
            }
        }
    }
} 

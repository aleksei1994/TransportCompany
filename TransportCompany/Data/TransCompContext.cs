using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TransportCompany.Models.CodeFirst;

namespace TransportCompany.Data
{
    public class TransCompContext : DbContext
    {
        public TransCompContext(DbContextOptions<TransCompContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<TariffPlan> TariffPlans { get; set; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasOne(p => p.Operator).WithMany(b => b.TripsOperator).HasForeignKey(p => p.OperatorId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trip>().HasOne(p => p.Driver).WithMany(b => b.TripsDriver).HasForeignKey(p => p.DriverId).OnDelete(DeleteBehavior.Restrict);

            int count = 1000;

            Staff[] staffs = GenerateTempValueDB.GetStaffs(count);
            Position[] positions = GenerateTempValueDB.GetPositions(count);

            modelBuilder.Entity<Position>().HasData(positions);
            modelBuilder.Entity<Staff>().HasData(staffs);
            modelBuilder.Entity<CarModel>().HasData(GenerateTempValueDB.GetCarModels(count));
            modelBuilder.Entity<Car>().HasData(GenerateTempValueDB.GetCars(count));
            modelBuilder.Entity<TariffPlan>().HasData(GenerateTempValueDB.TariffPlans(count));
            modelBuilder.Entity<Trip>().HasData(GenerateTempValueDB.GetTrips(count, staffs, positions));
        }
    }

    class GenerateTempValueDB
    {
        public static Position[] GetPositions(int count)
        {
            string[] jobTitle = { "Водитель", "Оператор", "Менеджер" };
            string[] responsibilities = { "Выполнять обязанности", "Внимательность", "Аккуратность" };
            string[] requirements = { "Выполнять обязанности", "Внимательность", "Аккуратность" };

            Position[] positions = new Position[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                positions[i] = new Position
                {
                    Id = i + 1,
                    JobTitle = jobTitle[rand.Next(0, jobTitle.Length)],
                    Salary = rand.Next(1, 10000) * 2,
                    Responsibilities = responsibilities[rand.Next(0, responsibilities.Length)],
                    Requirements = requirements[rand.Next(0, requirements.Length)]
                };
            }

            return positions;
        }

        public static Staff[] GetStaffs(int count)
        {
            string[] fioStaff = { "Велицкий А.В.", "Воробьев А.В.", "Михальченко П.В.", "Петров Г.В.", "Нильченко М.Ю.", "Бурунов П.В." };
            string[] address = { "Гомель", "Минск", "Могилев", "Брянск" };
            string[] passport = { "есть" };

            Staff[] staffs = new Staff[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                staffs[i] = new Staff
                {
                    Id = i + 1,
                    FioStaff = fioStaff[rand.Next(0, fioStaff.Length)],
                    Age = rand.Next(18, 65),
                    Gender = "Мужской",
                    Address = address[rand.Next(0, address.Length)],
                    Telephone = rand.Next(37525000, 37544999).ToString() + rand.Next(0001, 9999).ToString(),
                    Passport = passport[rand.Next(0, passport.Length)],
                    PositionId = rand.Next(1, count)
                };
            }

            return staffs;
        }

        public static CarModel[] GetCarModels(int count)
        {
            string[] nameModel = { "БМВ", "Мерседес", "Феррари", "Порш", "Киа" };
            string[] specifications = { "есть" };
            string[] specificity = { "есть" };

            CarModel[] carModels = new CarModel[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                carModels[i] = new CarModel
                {
                    Id = i + 1,
                    NameModel = nameModel[rand.Next(0, nameModel.Length)],
                    Specifications = specifications[rand.Next(0, specifications.Length)],
                    CostModel = rand.Next(0, 10000) * rand.Next(1, 100),
                    Specificity = specificity[rand.Next(0, specificity.Length)]
                };
            }

            return carModels;
        }

        public static Car[] GetCars(int count)
        {
            string[] regNumber = { "A", "B", "C" };
            string[] bodyNumber = { "1234" };
            string[] engineNumber = { "1234" };

            Car[] cars = new Car[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int year = rand.Next(1995, 2021);
                int month = rand.Next(1, 13);

                int yearLast = rand.Next(1995, 2021);
                int monthLast = rand.Next(1, 13);

                cars[i] = new Car
                {
                    Id = i + 1,
                    RegistrationNumber = rand.Next(1, 10).ToString() + regNumber[rand.Next(0, regNumber.Length)],
                    BodyNumber = bodyNumber[rand.Next(0, bodyNumber.Length)],
                    EngineNumber = engineNumber[rand.Next(0, engineNumber.Length)],
                    YearCreation = new DateTime(year, month, rand.Next(1, DateTime.DaysInMonth(year, month))),
                    Mileage = rand.Next(100, 150000),
                    LastMaintenanceDate = new DateTime(yearLast, monthLast, rand.Next(1, DateTime.DaysInMonth(yearLast, monthLast))),
                    CarModelId = rand.Next(1, count)
                };
            }

            return cars;
        }

        public static TariffPlan[] TariffPlans(int count)
        {
            string[] titlePlan = { "Грузовой", "Легковой" };
            string[] description = { "Большой тонаж", "Мелкий тонаж" };

            TariffPlan[] tariffPlans = new TariffPlan[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                tariffPlans[i] = new TariffPlan
                {
                    Id = i + 1,
                    TitlePlan = titlePlan[rand.Next(0, titlePlan.Length)],
                    Description = description[rand.Next(0, description.Length)],
                    CostPlan = rand.Next(100, 100000) + rand.NextDouble()
                };
            }

            return tariffPlans;
        }

        public static Trip[] GetTrips(int count, Staff[] staffs, Position[] positions)
        {
            string[] deparrturePoint = { "Минск", "Гомель", "Брянск", "Чернигов", "Бобруйск", "Литва" };
            string[] destinationPoint = { "Новозыбков", "Пинск", "Вислочи", "Кривой рог", "Москва", "Владивосток" };

            Trip[] trips = new Trip[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int year = rand.Next(2019, 2021);
                int mont = rand.Next(1, 12);

                List<Staff> driver = FinStaffs(staffs, positions, "Водитель");
                int driverCount = driver.Count - 1;
                List<Staff> opertor = FinStaffs(staffs, positions, "Оператор");
                int opertorCount = opertor.Count - 1;

                trips[i] = new Trip
                {
                    Id = i + 1,
                    DateTimeTrip = new DateTime(year, mont, DateTime.DaysInMonth(year, mont), rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60)),
                    Telephone = rand.Next(37525000, 37544999).ToString() + rand.Next(0001, 9999).ToString(),
                    DeparturePoint = deparrturePoint[rand.Next(0, deparrturePoint.Length)],
                    DestinationPoint = destinationPoint[rand.Next(0, destinationPoint.Length)],
                    TariffPlanId = rand.Next(1, count),
                    CarId = rand.Next(1, count),
                    DriverId = driver[rand.Next(1, driverCount)].Id,
                    OperatorId = opertor[rand.Next(1, opertorCount)].Id,
                };
            }

            return trips;
        }

        public static List<Staff> FinStaffs(Staff[] staffs, Position[] positions, string contains)
        {
            List<Staff> masStaffs = new List<Staff>();

            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i].JobTitle.Contains(contains))
                {
                    for (int j = 0; j < staffs.Length; j++)
                    {
                        if (positions[i].Id == staffs[j].PositionId)
                        {
                            masStaffs.Add(staffs[j]);
                        }
                    }
                }
            }

            return masStaffs;
        }
    }
}
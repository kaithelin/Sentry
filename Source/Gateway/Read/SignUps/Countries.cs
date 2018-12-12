using System.Collections.Generic;
using System.Linq;
using Concepts.SignUps;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.SignUps
{

    public class AllCountries : IQueryFor<Read.SignUps.Country>
    {
        private readonly List<Country> _countries = new List<Country>();


        public AllCountries()
        {

            _countries.Add(new Country { Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33", Name = "Land 1" });

            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Finland",
                Code = "FIN"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "France",
                Code = "FRA"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Germany",
                Code = "DEU"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Hong Kong",
                Code = "HKG"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Italy",
                Code = "ITA"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Norway",
                Code = "NOR"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "Singapore ",
                Code = "SGP"
            });
            _countries.Add(new Country
            {
                Id = "9cfe4ab3-15f0-49de-9ef0-6a07df1b0d33",
                Name = "United States of America",
                Code = "USA"
            });
        }


        public IQueryable<Country> Query => _countries.AsQueryable();
    }

    public class Country : IReadModel
    {
        public CountryId Id { get; set; }
        public CountryName Name { get; set; }
        public string Code { get; set; }

    }
}
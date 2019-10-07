using System.Collections.Generic;
using System.IO;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.AppService.Impl
{
    public class KaffekopService : IKaffekopService
    {
        private readonly IKaffekopRepository _KaffekopRepository;

        public KaffekopService(IKaffekopRepository KaffeKopRepository)
        {
            _KaffekopRepository = KaffeKopRepository;
        }   
        public CoffeeCup NewCup(string name, Color color, double volume, Material material, string description, double price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("please insert name!");
            }

            if (string.IsNullOrEmpty(color.ToString()))
            {
                throw new InvalidDataException("please insert valid colour!");
            }

            if (string.IsNullOrEmpty(volume.ToString()))
            {
                throw new InvalidDataException("please give correct measurements!");
            }

            if (string.IsNullOrEmpty(material.ToString()))
            {
                throw new InvalidDataException("insert valid material!");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new InvalidDataException("please add a description!");
            }

            if (string.IsNullOrEmpty(price.ToString()))
            {
                throw new InvalidDataException("please add a price!");
            }

            var cup = new CoffeeCup()
            {
                Name= name,
                Color = color,
                Volume = volume,
                Material = material,
                Description = description,
                Price = price

            };
            return cup;
        }

        public CoffeeCup CreateCoffeeCup(CoffeeCup createCup)
        {
            return _KaffekopRepository.CreateCoffeeCup(createCup);
        }

        public List<CoffeeCup> GetAllCups()
        {
            return _KaffekopRepository.GetAllCoffeeCups();
        }

        public CoffeeCup UpdateCoffeeCup(CoffeeCup updated)
        {
            return _KaffekopRepository.UpdateCoffeeCup(updated);

        }

        public CoffeeCup GetCoffeeCupById(int id)
        {
            return _KaffekopRepository.GetCoffeeCupById(id);
        }

        public CoffeeCup DeleteCoffeeCup(int id)
        {
            return _KaffekopRepository.DeleteCoffeeCup(id);
        }
    }
}
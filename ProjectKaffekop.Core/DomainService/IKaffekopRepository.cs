﻿using System.Collections.Generic;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.DomainService
{
    public interface IKaffekopRepository
    {
        //Creates a Coffee Cup
        CoffeeCup CreateCoffeeCup(CoffeeCup createCup);

        //Reads all Coffee Cups
        CoffeeCup GetCoffeeCupById(int id);
        List<CoffeeCup> GetAllCoffeeCups();
        
        //Updates Coffee Cups
        CoffeeCup UpdateCoffeeCup(CoffeeCup updated);

        //Deletes Coffee Cups
        CoffeeCup DeleteCoffeeCup(int id);
    }
}
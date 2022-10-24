using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalFactory
{
    IAnimal Create(AnimalRequirement requirements);
}

public class CanSwimFactory : IAnimalFactory
{
    public IAnimal Create(AnimalRequirement requirements)
    {
        if (requirements.hasLeg)
        {
            if (requirements.Edible)
            {
                return new Duck();
            }
            else
            {
                return new Alligator();
            }
        }
        else
        {
            if (requirements.Edible)
            {
                return new Fish();
            }
            else
            {
                return new Shark();
            }

        }
    }
}

public class EdibleFactory : IAnimalFactory
{
    public IAnimal Create(AnimalRequirement requirements)
    {
        if (requirements.hasLeg)
        {
            return new Chicken();
        }
        else
        {
            return new Snake();
        }
    }
}

public class HasLegFactory : IAnimalFactory {
    public IAnimal Create(AnimalRequirement requirements)
    {
        return new Cat();
    }
}

public class ElseFactory : IAnimalFactory
{
    public IAnimal Create(AnimalRequirement requirements)
    {
        return new earthworm();
    }
}

public abstract class AbstractAnimalFactory
{
    public abstract IAnimal Create();
}

public class AnimalFactory : AbstractAnimalFactory
{
    private readonly IAnimalFactory _factory;
    private readonly AnimalRequirement _requirements;

    public AnimalFactory(AnimalRequirement requirements)
    {
        if (requirements.CanSwim)
            _factory = (IAnimalFactory)new CanSwimFactory();
        else if (!requirements.CanSwim && requirements.Edible)
            _factory = (IAnimalFactory)new EdibleFactory();
        else if (requirements.hasLeg)
            _factory = (IAnimalFactory)new HasLegFactory();
        else
            _factory = (IAnimalFactory)new ElseFactory();
        _requirements = requirements;
    }

    public override IAnimal Create()
    {
        return _factory.Create(_requirements);
    }

}
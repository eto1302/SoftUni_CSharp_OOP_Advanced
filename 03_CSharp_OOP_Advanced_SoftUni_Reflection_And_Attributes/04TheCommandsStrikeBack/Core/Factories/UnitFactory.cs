using TheCommandsStrikeBack.Models.Units;

namespace TheCommandsStrikeBack.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            switch (unitType)
            {
                case ("Swordsman"):
                {
                    return new Swordsman();

                }
                case ("Archer"):
                {
                    return new Archer();

                }
                case ("Pikeman"):
                {
                    return new Pikeman();

                }
                case ("Gunner"):
                {
                    return new Gunner();

                }
                case ("Horseman"):
                {
                    return new Horseman();

                }

            }
            return default(IUnit);
        }
    }
}

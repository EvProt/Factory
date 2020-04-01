using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {

        abstract class AbsFactory    
        {
            public abstract General CreateGeneral();
            public abstract Captain CreateCaptain();
            public abstract Soldier CreateSoldier();
        }

        class Orc: AbsFactory
        {
            public override General CreateGeneral()
            {
                return new ORC_ConcreteGeneral();
            }

            public override Captain CreateCaptain()
            {
                return new ORC_ConcreteCaptain();
            }

            public override Soldier CreateSoldier()
            {
                return new ORC_ConcreteSoldier();
            }

        }

        class Elf: AbsFactory
        {
            public override General CreateGeneral()
            {
                return new ELF_ConcreteGeneral();
            }

            public override Captain CreateCaptain()
            {
                return new ELF_ConcreteCaptain();
            }

            public override Soldier CreateSoldier()
            {
                return new ELF_ConcreteSoldier();
            }
        }

        abstract class General
        {
            public abstract void makeGen();
        }

        abstract class Captain
        {
            public abstract void makeCap();
        }

        abstract class Soldier
        {
            public abstract void makeSold();
        }

        class ORC_ConcreteGeneral: General
        {
            public override void makeGen()
            {
                Console.WriteLine("Перед Вами генерал ОРКОВ!");
            }
        }

        class ORC_ConcreteCaptain: Captain
        {
            public override void makeCap()
            {
                Console.WriteLine("Перед Вами капитан ОРКОВ!");
            }
        }

        class ORC_ConcreteSoldier: Soldier
        {
            public override void makeSold()
            {
                Console.WriteLine("Перед Вами всего лишь рядовой ОРК!");
            }
        }

        class ELF_ConcreteGeneral: General
        {
            public override void makeGen()
            {
                Console.WriteLine("Перед Вами генерал ЭЛЬФОВ!");
            }
        }

        class ELF_ConcreteCaptain: Captain
        {
            public override void makeCap()
            {
                Console.WriteLine("Перед Вами капитан ЭЛЬФОВ!");
            }
        }

        class ELF_ConcreteSoldier: Soldier
        {
            public override void makeSold()
            {
                Console.WriteLine("Перед Вами маленький рядовой ЭЛЬФ!");
            }
        }


        static void Main(string[] args)
        {
            General gen;
            Captain cap;
            Soldier sold;

            AbsFactory orcs = new Orc();
            gen = orcs.CreateGeneral();
            cap = orcs.CreateCaptain();
            sold = orcs.CreateSoldier();

            gen.makeGen();
            cap.makeCap();
            sold.makeSold();

            Console.WriteLine();

            AbsFactory elfs = new Elf();
            gen = elfs.CreateGeneral();
            cap = elfs.CreateCaptain();
            sold = elfs.CreateSoldier();

            gen.makeGen();
            cap.makeCap();
            sold.makeSold();

            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        abstract class Army   
        {
            public abstract General CreateGeneral();
            public abstract Captain CreateCaptain();
            public abstract Soldier CreateSoldier();
        }

        //Армия орков
        class OrcsArmy: Army
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

        //Армия эльфов
        class ElfsArmy: Army
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

        //АБСТРАКТНАЯ ФАБРИКА
        abstract class AbsFactory
        {
            public abstract Army createArmy();
        }

        //Создание армии эльфов
        class Elfs : AbsFactory
        {
            public override Army createArmy()
            {
                return new ElfsArmy();
            }
        }

        //Создание армии орков
        class Orcs : AbsFactory
        {
            public override Army createArmy()
            {
                return new OrcsArmy();
            }
        }

        //доп. классы для создания конкретных элементов
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
        //конец доп.классы для создания конкретных элементов

        //создание воина
        class Warrior
        {
            private Army gen, cap, sold;

            public Warrior (AbsFactory warrior)
            {
                gen = warrior.createArmy();
                cap = warrior.createArmy();
                sold = warrior.createArmy();

            }

            public void crArmy()
            {
                General congen = gen.CreateGeneral();
                Captain concap = cap.CreateCaptain();
                Soldier consold = sold.CreateSoldier();

                congen.makeGen();
                concap.makeCap();
                consold.makeSold();

            }
        }
        //конец создание воина

        static void Main(string[] args)
        {
            Warrior orcs = new Warrior(new Orcs());
            orcs.crArmy();

            Console.WriteLine();

            Warrior elfs = new Warrior(new Elfs());
            elfs.crArmy();

            Console.ReadKey();

        }
    }
}

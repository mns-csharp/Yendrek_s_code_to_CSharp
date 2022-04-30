using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Yendrek_s_code_to_CSharp
{    
    public static class Program
    {
        static Random rnd = new Random();
        public static int N { get; set; }
        const int period_boundary_int = 5;
        const double temperature_T__float = 10.0;
        const int min_atom_distance__float = 1;
        const int max_atom_distance__float = 3;

        public static List<Point2d> polymer_chain_vec;
        static List<string> stringList = new List<string>();

        static Program()
        {
            N = 16;
        }

        private static void PrintPolymer()
        {
            for (int i = 0; i < polymer_chain_vec.Count; i++)
            {
                polymer_chain_vec[i].Print();
            }
            Console.WriteLine();
        }

        public static List<Point2d> InitializePolymerChain()
        {
            int n = (int)(Math.Sqrt(N));
            int l = period_boundary_int / (n + 1);
            List<double> x_list = np.linspace(l, period_boundary_int - l, n);
            List<double> y_list = np.linspace(l, period_boundary_int - l, n);
            polymer_chain_vec = np.meshgrid(x_list, y_list).ToList();

            return polymer_chain_vec;
        }

        public static double GetAtomicEnergy(int index)
        {            
            double en = 0;

            for (int i = 0; i < polymer_chain_vec.Count; i++)
            {
                if (i == index)
                    continue;

                double dx = Math.Abs(polymer_chain_vec[index].X - polymer_chain_vec[i].X);
                double dy = Math.Abs(polymer_chain_vec[index].Y - polymer_chain_vec[i].Y);

                dx = (dx < period_boundary_int / 2) ? dx : period_boundary_int - dx;
                dy = (dy < period_boundary_int / 2) ? dy : period_boundary_int - dy;
                
                double d = Math.Sqrt(dx * dx + dy * dy);

                if (d < min_atom_distance__float)
                    en += 10000000;
                else if (d < max_atom_distance__float)
                    en += -1;
            }

            return en;
        }

        public static double GetTotalPolymerEnergy()
        {            
            double en = 0;
            for (int i = 0; i < polymer_chain_vec.Count; i++)
            {
                en += GetAtomicEnergy(i);
            }
            return en;
        }

        public static void RunSimulation()
        {
            //randomIndex__int = random.randint(0, N-1)
            int randomIndex__int = random.randint(rnd, 0, N);

            //energyBefore__float = get_energy(randomIndex__int)
            double energyBefore__float = GetAtomicEnergy(randomIndex__int);

            //dx = random.uniform(-0.5, 0.5)
            double dx = random.uniform(rnd, -0.5, 0.5);
            
            //dy = random.uniform(-0.5, 0.5)
            double dy = random.uniform(rnd, -0.5, 0.5);

            Console.Write("(" + dx + "," + dy+ "),,, ");

            //prev_x, prev_y = polymer_chain_vec[randomIndex__int]
            Point2d prev = polymer_chain_vec[randomIndex__int];
            double prev_x = prev.X;
            double prev_y = prev.Y;

            //temp_x = polymer_chain_vec[randomIndex__int][0] + dx
            double temp_x = polymer_chain_vec[randomIndex__int].X + dx;
            //temp_y = polymer_chain_vec[randomIndex__int][1] + dy 
            double temp_y = polymer_chain_vec[randomIndex__int].Y + dy;

            /*
             *  if temp_x < 0:
                    polymer_chain_vec[randomIndex__int][0] = period_boundary_int - temp_x
                else:
                    polymer_chain_vec[randomIndex__int][0] = temp_x if temp_x < period_boundary_int else temp_x - period_boundary_int
             */
            if (temp_x < 0)
                polymer_chain_vec[randomIndex__int].X = period_boundary_int - temp_x;
            else
                polymer_chain_vec[randomIndex__int].X = (temp_x < period_boundary_int) ? temp_x : temp_x - period_boundary_int;

            /*
             *  if temp_y < 0:
                    polymer_chain_vec[randomIndex__int][1] = period_boundary_int - temp_y
                else:
                    polymer_chain_vec[randomIndex__int][1] = temp_y if temp_y < period_boundary_int else temp_y - period_boundary_int
             */
            if (temp_y < 0)
                polymer_chain_vec[randomIndex__int].Y = period_boundary_int - temp_y;
            else
                polymer_chain_vec[randomIndex__int].Y = (temp_y < period_boundary_int) ? temp_y : temp_y - period_boundary_int;
                        
            // obtain new get_energy_of_one_atom
            double energyAfter__float = GetAtomicEnergy(randomIndex__int);

            double energyDifference__float = energyAfter__float - energyBefore__float;

            if (energyDifference__float < 0)  // e_before > e_after
            {
                //pass
                stringList.Add("A");
            }
            else
            {
                double randomVal__float = random.randdouble(rnd);

                double montecarlo = Math.Exp((-1) * (energyDifference__float) / (temperature_T__float));

                if (montecarlo > randomVal__float)
                {
                    //pass
                    stringList.Add("B");
                }
                else
                {
                    ///////////////////////////////////////////////////////
                    Point2d p = new Point2d(prev_x, prev_y);
                    polymer_chain_vec[randomIndex__int] = new Point2d(prev_x, prev_y);
                    stringList.Add("C");
                    ////////////////////////////////////////////////////////
                }
            }
        }

        public static void Main(string[] args)
        {
            N = 4;
            polymer_chain_vec = InitializePolymerChain();
            double previousEnergy = GetTotalPolymerEnergy();
            List<double> energies = new List<double>();
            energies.Add(previousEnergy);
            
            for (int i = 0; i < 100; i++)
            {               
                RunSimulation();
                double energy = GetTotalPolymerEnergy();
                energies.Add(energy);
            }

            //foreach (var item in stringList)
            //{
            //    Console.Write(item);
            //}

            double min = -5;
            double max = 5;

            double diff = max - min;

            Console.ReadKey();
        }
    }
}

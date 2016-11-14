using System;
using System.Collections.Generic;

namespace YieldKeyword
{
    /// <summary>
    ///     Reference From https://msdn.microsoft.com/en-us/library/9k7k7cf0.aspx
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            ShowGalaxies();
            Console.Read();
        }

        private static void ShowGalaxies()
        {
            foreach (var theGalaxy in Galaxies.NextGalaxy)
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears);
            Console.WriteLine();

            using (var enumerator = Galaxies.NextGalaxy.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current.Name + " " + enumerator.Current.MegaLightYears);
            }
        }

        private static class Galaxies
        {
            public static IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy {Name = "Tadpole", MegaLightYears = 400};
                    yield return new Galaxy {Name = "Pinwheel", MegaLightYears = 25};
                    yield return new Galaxy {Name = "Milky Way", MegaLightYears = 0};
                    yield return new Galaxy {Name = "Andromeda", MegaLightYears = 3};
                }
            }
        }

        private class Galaxy
        {
            public string Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }
}
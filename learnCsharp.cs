using System;
using System.Collections.Generic;

namespace learnCsharp.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
						Random rnd = new Random();            

						List<Film> FilmList = new List<Film>();
            FilmList.Add(new Film("Muj posledni Rok", "Vaclav", "Dobry", 2000 ));
            FilmList.Add(new Film("Podzimni radovanky", "Vaclav", "Schwarzenegger", 1955 ));
            FilmList.Add(new Film("Arnold utoci 2", "Robert", "Zemekyss", 2050 ));

						foreach (Film f in FilmList) {
							for (int i = 0; i < 15; i++) {
								f.PridaniHodnoceni(rnd.NextDouble() * 5);
							}
						}
						Film bestFilm = null;
						Film longestTitleFilm = null;

						foreach (Film f in FilmList) {
    			    if (bestFilm == null || f.Hodnoceni > bestFilm.Hodnoceni) {
        				bestFilm = f;
    					}

    					if (longestTitleFilm == null || f.Nazev.Length > longestTitleFilm.Nazev.Length) {
        				longestTitleFilm = f;
    					}
						}
	
						Console.Write("Film s nejlepším hodnocením: ");
						Console.WriteLine(bestFilm);

						Console.Write("\nFilm s nejdelším názvem: ");
						Console.WriteLine(longestTitleFilm);
						Console.WriteLine();
						
						foreach (Film f in FilmList) {
							if (f.Hodnoceni < 3) {
								Console.WriteLine($"{f.Nazev} je odpad! Má hodnocení jen {f.Hodnoceni:F2}.");
							}
							Console.WriteLine(f);
							Console.WriteLine();
						}
        }
    }
    public class Film
    {
        public Film(string nazev, string jmeno, string prijmeni, int rok)
        {
            Nazev = nazev;
            JmenoRezisera = jmeno;
            PrijmeniRezisera = prijmeni;
            RokVzniku = rok;
        }
        public string Nazev { get; }
        public string JmenoRezisera { get; }
        public string PrijmeniRezisera { get; }
        public int RokVzniku { get; }


        public double Hodnoceni { get; private set; }

        List<double> VsechnaHodnoceni = new List<double>();

        public void PridaniHodnoceni(double vlastniHodnoceni)
        {
            VsechnaHodnoceni.Add(vlastniHodnoceni);
            foreach (var h in VsechnaHodnoceni) {
							Hodnoceni += h;
						}
            Hodnoceni = Hodnoceni / VsechnaHodnoceni.Count;
        }
        public void VypisHodnoceni()
        {
            foreach (double hodnoc in VsechnaHodnoceni) {
							Console.WriteLine(hodnoc);
						}
        }
        public override string ToString()
        {
            return $"{{{Nazev}}} ({{{RokVzniku}}}; {{{PrijmeniRezisera}}}, {{{JmenoRezisera[0]}}}): {{{Hodnoceni}}}⭐";

        }
    }
}

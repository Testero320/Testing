namespace Baza_kostek
{

    partial class Program
    
    {
        static float CzyFloat(string f)
        {
            try
            { return (float)Convert.ToDouble(f); }
            catch { return 0.0f; }
        }
        static int? CzyInt(string i)
        {
            try
            { return Convert.ToInt32(i); }
             catch { return null; }
        }

        public static void inputData(List<Kostki> wszystkieKostki)
        {
            {
                string? nazwa = null;
                float? nowyCzas = null;
                string? data = null;

                Console.Clear();

                while ((nazwa == null) || (nowyCzas == null) || (data == null))
                {
                    //  Spróbuj wczytać nazwę do momentu aż użytkownik nie poda dobrej
                    while (nazwa == null)
                    {
                        string? wejscie = "";
                        Console.Write("Wpisz nazwę kostki: ");
                        wejscie = Console.ReadLine().Trim();
                        if (wejscie.Length > 2)
                        {
                            nazwa = wejscie;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wpisana nazwa jest za krótki - nazwa musi mieć przynjamniej 3 znaki");
                            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                    Console.Clear();

                    //  Poproś użytkownika o wprowadzenie czasu lub 0 jeśli nie chce podawać
                    while (nowyCzas == null)
                    {
                        string? wejscie = "";
                        Console.Write("Wpisz jeden czas ułożenia, lub 0 by nie dodawać żadnego (nie wpisuj 'f' na końcu, tylko np. 11.23): ");
                        wejscie = Console.ReadLine().Trim();

                        if (wejscie == "0") { nowyCzas = 0; }

                        else if (wejscie.Length < 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Wpisany czas jest za krótki -> wpisz go tak by miał minimum 3 cyfry");
                            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            float poKonwersji = CzyFloat(wejscie);
                            if (poKonwersji != 0.0f) { nowyCzas = poKonwersji; }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wpisany czas jest niepoprawny - by nie wpisywać żadnego czasu wpisz '0'");
                                Console.WriteLine("\n Naciśnij dowolny klawisz by kontynuować");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }

                    Console.Clear();

                    //  Poprosi o wpisanie daty dostania kostki
                    while (data == null)
                    {
                        string?[] wejscie = new string[3];
                        Console.Write("Wpisz datę w postaci 'rok miesiac dzien' - możesz pominąc dzien lub dzien i miesiac: ");
                        wejscie = Console.ReadLine().Split(" ");

                        //  wpisano ""
                        if (wejscie.Length < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Nie wpisano żadnej daty! - musisz podać przynajmniej rok");
                            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        //  wpisano "0"
                        if (wejscie[0].Length < 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Wpisana data jest za krótka -> wpisz go tak by miał minimum 3 cyfry");
                            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        //  wpisano "16"
                        if (wejscie[0].Length == 2)
                        {
                            int? rok = CzyInt(wejscie[0]);
                            if (rok != null)
                            {
                                if (rok > 23)
                                    data = "19" + wejscie[0];
                                else
                                    data = "20" + wejscie[0];

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wpisana data krótka nie jest cyfrą - wpisz ją poprawnie");
                                Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }



                        //  jeśli podano, wprowadź miesiąc
                        if (wejscie.Length > 1)
                        {
                            int? miesiac = CzyInt(wejscie[1]);
                            if (miesiac != null)
                            {
                                data += "." + (miesiac % 12).ToString();

                                //  jeśli podano też dzień dodaj go
                                if ((wejscie.Length > 2))
                                {
                                    int? dzien = CzyInt(wejscie[2]);
                                    if (dzien != null)
                                    {
                                        data += "." + (dzien % 30).ToString();
                                    }
                                    else
                                        continue;
                                }
                            }
                            else
                                continue;
                        }
                    }



                    // wyświetlenie poprawnego wpisania kostek
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Wczytanie danych poprawne\n");

                        Console.WriteLine("Oto wprowadzone przez ciebie dane:");
                        Console.WriteLine($"Nazwa: {nazwa}");
                        string? nowy = nowyCzas != 0.0f ? nowyCzas.ToString() : "Nie Wprowadzono";
                        Console.WriteLine($"Czas: {nowy}");
                        Console.WriteLine($"Data otrzymania / kupna: {data}");

                        Console.WriteLine("\nCzy zapisać kostkę? (Y/N)");
                        Console.Write(">>> ");
                        string czyZapisac = Console.ReadLine().Trim().ToLower();
                        if (czyZapisac == "y")
                        {
                            if (nowyCzas != 0.0f)
                            {
                                wszystkieKostki.Add(new Kostki(nazwa, (float)Convert.ToDouble(nowyCzas), data));
                                break;
                            }
                            else
                            {
                                wszystkieKostki.Add(new Kostki(nazwa, data));
                                break;
                            }
                        }
                        else if (czyZapisac == "n")
                            break;
                    }
                }

                Console.Clear();

            }

        }
    }
}

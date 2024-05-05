Console.WriteLine("Antal ingridienter:");
bool lyckadAntalIngridienter = int.TryParse(Console.ReadLine(), out int antalIngridienter);

if (lyckadAntalIngridienter && antalIngridienter > 0 && antalIngridienter < 6)
{
    for ( int i = 0; i < antalIngridienter; i++)
    {

    }
}
else Console.WriteLine("antal ingridienter är felaktiga");

bool KollaReadline(out int nummer)
{
    string lästRad = Console.ReadLine();
    bool lyckat = int.TryParse(lästRad, out nummer);
    return lyckat;
}
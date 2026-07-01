using System.Runtime.Intrinsics;

namespace decouverte.Poo.vaisseau;

internal class Episode2 : IItem
{
    Random r = new Random();

    private int nbEnVols = 0;
    public string GetName()
    {
        return  "StarWars Episode 2";
    }

    
    public void Run()
    {
        vaisseau v1 = new vaisseau("Xwing");
        vaisseau v2 = new vaisseau("Millenium");

        Console.WriteLine(v1.NbEnVol);
        Decolage(ref v1);
        Console.WriteLine(v1.NbEnVol);
        Decolage(ref v2);
        Console.WriteLine(v1.NbEnVol);
        Decolage(ref v1);
        Console.WriteLine(v1.NbEnVol);
        Atterissage(ref v1);
        Console.WriteLine(v1.NbEnVol);
        Atterissage(ref v1);
        Console.WriteLine(v1.NbEnVol);
        Atterissage(ref v2);
        Console.WriteLine(v1.NbEnVol);
    }

    public void Decolage(ref vaisseau v)
    {
        if (v.EnVol())
        {
            Console.WriteLine("Appareil deja en vol");
        }
        else
        {
            v.DecolageAtterisage();
            v.NbEnVolPlus();
        }
        
    }

    public void Atterissage(ref vaisseau v)
    {
        if (v.EnVol())
        {
            v.DecolageAtterisage();
            v.NbEnVolMoins();
        }
        else
        {
            Console.WriteLine("Appareil deja au sol");
        }
        
    }

    
}
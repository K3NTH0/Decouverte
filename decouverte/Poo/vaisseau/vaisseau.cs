using System.Globalization;
using System.Runtime.Intrinsics;

namespace decouverte.Poo.vaisseau;

internal class vaisseau
{
    private String nom {get; init;}
    private int ammo {get; set;}
    private int health {get; set;}
    private bool enEtatDeMarche {get; set;}
    private bool enVol { get; set; }
    
    private static int nbEnVol {get; set;}
    
    // Constructeur
    public vaisseau(String nom, int ammo)
    {
        this.nom = nom == null ? "" : nom;
        this.ammo = ammo >= 0? ammo : 0;
        health = 3;
        enEtatDeMarche = true;
        enVol = false;
        
    }
    
    public vaisseau(String nom)
    {
        new vaisseau(nom, 10);
    }
    
    // Get

    public int NbEnVol => nbEnVol;
    public bool EnVol() => enVol;
    public String getNom() => nom;


    public int GetAmmo() => ammo;

    public int GetHealth() => health;
        
    public bool GetStatus()=>enEtatDeMarche;
    
    // Set
    // public void Rename(String nom)
    // {
    //     this.nom = nom;
    // }

    public void NbEnVolPlus()
    {
        nbEnVol++;
    }
    
    public void NbEnVolMoins()
    {
        nbEnVol--;
    }

    public void DecolageAtterisage()
    {
        enVol = !enVol;
    }
    
    public void Reload(int amount)
    {
        ammo = amount > 0 ? amount : 0;
    }

    public void HasBeenHit()
    {
            health--;
    }
    
    public void IsDead() => enEtatDeMarche = false;
    
    public void Tirer(ref vaisseau adversaire)
    {
        if (enEtatDeMarche && GetAmmo() > 0)
        {
            if (GetAmmo() != 0)
            {
                Console.Write($"Le {nom} tire - ");
                ammo--;
                
                if (Hit())
                {
                    Console.WriteLine("Touché !");
                    adversaire.HasBeenHit();
                }
                else
                {
                    Console.WriteLine("Raté !");
                }

                if (adversaire.GetHealth() == 0)
                {
                    Console.WriteLine($"La vaisseau {adversaire.getNom()} à EXPLOSÉ !");
                    adversaire.IsDead();
                }

            }
            else
            {
                Console.WriteLine($"Le {nom} n'a plus de munitions");
            }
        }
       
    }
    
    public bool Hit()
    {
        Random r = new Random();
        return (r.Next(1, 3) == 1);
    }

    public void AffichageScore()
    {
        Console.WriteLine($"{this.nom} - {this.ammo} - {this.health}");
       
    }
    
}
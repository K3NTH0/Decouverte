namespace decouverte.Poo.vaisseau;

internal class Episode1 : IItem
{
    public string GetName()
    {
        return "Star Wars Episode 1";
    }

    public void Run()
    {
        vaisseau v1 = new vaisseau("Millénium", 10);
        vaisseau v2 = new vaisseau("Xwing", 10);

        while (v1.GetStatus() && v2.GetStatus())
        {
            v1.Tirer(ref v2);
            v2.Tirer(ref v1);
        }
        
        v1.AffichageScore();
        v2.AffichageScore();
        
    }
}
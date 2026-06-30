

namespace decouverte.liste
{
    internal class Liste
    {
        public int val;
        public Liste? suivant;
        
        public Liste(int val, Liste? suivant)
        {
            this.val = val;
            this.suivant = suivant;
        }
    }

    internal class MainList : IItem
    {
        public string GetName()
        {
            return "Manipulation de liste";
        }

        public void Run()
        {
            // Utiliser pour randomiser la position a viser dans la chaine de liste
            Random rand = new Random();
            int pos = rand.Next(1,5);
            int avantDernierElem = -1;
            
            Liste? liste = null;
            ListeUtil.Push(ref liste, 10);
            ListeUtil.Push(ref liste, 9);
            ListeUtil.Push(ref liste, 8);
            ListeUtil.Push(ref liste, 7);

            ListeUtil.PrintListe(liste);
            Console.WriteLine($"Le premier element de la liste est {ListeUtil.Peek(ref liste)}");
            
            Console.WriteLine($"\nTaille : {ListeUtil.Size(liste)}");
            
            ListeUtil.Pop(ref liste);
            Console.WriteLine("POP");
            ListeUtil.PrintListe(liste);

            avantDernierElem = ListeUtil.ElemAtPosition(ref liste, ListeUtil.Size(liste) - 1).val;
            ListeUtil.Add(ref liste,avantDernierElem );
            Console.WriteLine("\nRajout de 11");
            ListeUtil.PrintListe(liste);
            
            Console.WriteLine($"\nla valeur a la position {pos} est {ListeUtil.Read(liste, pos)}");

            Console.WriteLine($"Modification de la valeur a la position {pos} par un 0");
            ListeUtil.Insert(ref liste, pos, 0);
            ListeUtil.PrintListe(liste);

            Console.WriteLine($"Suppression de la derniere valeur de la liste\nAvant : ");
            ListeUtil.PrintListe(liste);
            ListeUtil.Remove(ref liste);
            Console.WriteLine("\nApres :");
            ListeUtil.PrintListe(liste);
            
            pos = rand.Next(1,ListeUtil.Size(liste)+1);
            Console.WriteLine($"\nOn retire l'élément a la position {pos}");
            ListeUtil.PrintListe(liste);
            ListeUtil.RemoveAt(ref liste, pos);
            ListeUtil.PrintListe(liste);
        }
    }

    internal class ListeUtil
    {
        public static void PrintListe(Liste l)
        {
            Console.Write('[');
            while(l != null)
            {
                Console.Write(l.val);
                if(l.suivant != null)
                {
                    Console.Write(", ");
                }
                l = l.suivant;
            }
            Console.Write("]\n");
        }

        //Voir premier element
        internal static int Peek(ref Liste? liste) => liste.val;
        
        
        //Ajouter une valeur au début
        internal static void Push( ref Liste? liste, int val)
        {
            Liste nouv = new Liste(val, liste);
            liste = nouv;
        }

        
        //Retirer le premier élément et retourner l'élément retiré
        internal static int Pop(ref Liste? liste)
        {
            int val = liste.val;
            liste = liste.suivant;
            return val;
        }
        
        //Obtenir la taille de la liste
        internal static int Size(Liste? l)
        {
            int taille = 0;
            while (l != null)
            {
                l = l.suivant;
                taille++;
            }
            return taille;
        }
        
        //Ajouter à la fin
        internal static void Add(ref Liste? l, int val)
        {
            Liste temp = l;
            while (temp.suivant != null)
            {
                temp = temp.suivant;
            }
            temp.suivant = new Liste(val, null);
        }
        // Trouver position 
        internal static Liste ElemAtPosition(ref Liste? l, int pos)
        {
            Liste temp = l;
            for (int i = 0; i < pos-1; i++)
            {
                temp = temp.suivant;
            }
            return temp;
        }
        
        //Lire à l'élément de position
        internal static int Read(Liste? l, int pos)
        {
            // for (int i = 0; i < pos-1; i++)
            // {
            //     temp = temp.suivant;
            // }
            return ElemAtPosition(ref l,pos).val;
        }
        
        //Insérer à l'élément de position
        internal static void Insert(ref Liste? l, int pos, int val)
        {
            //Liste temp = l;
            Liste temp = ElemAtPosition(ref l, pos);
            Liste nouv = new Liste(val, null);
            // for (int i = 0; i < pos-1; i++)
            // {
            //    temp = temp.suivant; 
            // }

            if (temp.suivant != null)
            {
                temp.val = val;
            }
            else
            {
                temp.val = val;
                temp.suivant = null;
            }
        }
        
        //Retirer le dernier élément
        internal static int Remove(ref Liste? l)
        {
            Liste temp = l;
            int val=-1;
            if (temp != null && temp.suivant != null)
            {
                while (temp.suivant.suivant != null)
                {
                    temp = temp.suivant;
                }
                val = temp.suivant.val;
                temp.suivant = null;
            }
            return val;
        }
        
        //Retirer l'élément de position pos
        internal static int RemoveAt(ref Liste? l, int pos)
        {
            Liste temp = l;
            int val = temp.val;
            if (pos > 1)
            {
                for (int i = 0; i < pos-2; i++)
                {
                
                    temp = temp.suivant;
                }
                val = temp.suivant.val;
                temp.suivant = temp.suivant.suivant;
            }
            else
            {
                Pop(ref l);
            }
            
            return val;
        }
    }
}

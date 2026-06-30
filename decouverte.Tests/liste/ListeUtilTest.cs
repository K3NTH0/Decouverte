using decouverte.liste;
using NUnit.Framework;

namespace decouverte.Tests.liste;

[TestFixture]
[TestOf(typeof(ListeUtil))]
public class ListeUtilTest
{
    /*
     * Tests de la fonction Eq (equals)
     */
    [Test]
    public void l1IsEqualTol2With2ListeInside()
    {
        Liste l1 = new Liste(4, new Liste(9, null));
        Liste l2 = new Liste(4, new Liste(9, null));
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = true;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void l1IsNotEqualTol2With2ListeInside()
    {
        Liste l1 = new Liste(5, new Liste(7, null));
        Liste l2 = new Liste(4, new Liste(9, null));
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = false;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void l1IsNotEqualTol2With2SizeDifferent()
    {
        Liste l1 = new Liste(4, new Liste(9, null));
        Liste l2 = new Liste(4, null);
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = false;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void l1IsEqualTol2WithSize1()
    {
        Liste l1 = new Liste(255, null);
        Liste l2 = new Liste(255, null);
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = true;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /*
     * Tests de la fonction Add
     */
    [Test]
    public void AddUneListeALaFinDUneListeVide()
    {
        Liste? l = null;
        Liste expected = new Liste(1, null);
        ListeUtil.Add(ref l, 1);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
    }
    
    [Test]
    public void AddUneListeALaFinDUneChaineDe2Liste()
    {
        Liste? l = new Liste(1, new Liste(2, null));
        Liste expected = new Liste(1, new Liste(2, new Liste(3, null)));
        ListeUtil.Add(ref l, 3);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
        
    }

    [Test]
    public void AddUneListeA1Liste()
    {
        Liste? l = new Liste(1, null);
        Liste expected = new Liste(1, new Liste(2, null));
        
        ListeUtil.Add(ref l, 2);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
        
    }

    
}
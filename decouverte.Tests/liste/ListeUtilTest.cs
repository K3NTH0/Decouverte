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
    [Category("Eq")]
    [Test]
    public void L1IsEqualTol2With2ListeInside()
    {
        Liste l1 = new Liste(4, new Liste(9, null));
        Liste l2 = new Liste(4, new Liste(9, null));
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = true;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Category("Eq")]
    [Test]
    public void L1IsNotEqualTol2With2ListeInside()
    {
        Liste l1 = new Liste(5, new Liste(7, null));
        Liste l2 = new Liste(4, new Liste(9, null));
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = false;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Category("Eq")]
    [Test]
    public void L1IsNotEqualTol2With2SizeDifferent()
    {
        Liste l1 = new Liste(4, new Liste(9, null));
        Liste l2 = new Liste(4, null);
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = false;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Category("Eq")]
    [Test]
    public void L1IsEqualTol2WithSize1()
    {
        Liste l1 = new Liste(255, null);
        Liste l2 = new Liste(255, null);
        
        bool result = ListeUtil.Eq(l1, l2);
        bool expected = true;
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /*
     * Tests fonction Peek
     */
    [Category("Peek")]
    [Test]
    public void FirstValIs4AndSizeIs1()
    {
        Liste l = new Liste(4, null);

        int expected = 4;
        int actual = ListeUtil.Peek(ref l);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Category("Peek")]
    [Test]
    public void FirstValIs2AndSizeIs3()
    {
        Liste l = new Liste(2, new Liste(7, new Liste(0, null)));

        int expected = 2;
        int actual = ListeUtil.Peek(ref l);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Category("Peek")]
    [Test]
    public void ListeIsNull()
    {
        Liste l = null;

        int expected = -1;
        int actual = ListeUtil.Peek(ref l);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    /*
     * Tests de la fonction Push
     */
    [Category("Push")]
    [Test]
    public void AjoutDeVal2DevantVal1Size2()
    {
        Liste lInitiale = new Liste(1, new Liste(3, null));
        Liste expected = new Liste(2, new Liste(1, new Liste(3, null)));
        int valAjoutée = 2;
        
        ListeUtil.Push(ref lInitiale, valAjoutée);
        
        Assert.That(ListeUtil.Eq(lInitiale, expected), Is.True);
    }

    [Category("Push")]
    [Test]
    public void AjoutAUneListeNull()
    {
        Liste lInitiale = null;
        Liste expected = new Liste(1, null);
        int valAjoutée = 1;
        
        ListeUtil.Push(ref lInitiale, valAjoutée);
        Assert.That(ListeUtil.Eq(lInitiale, expected), Is.True);
    }
    
    /*
     * Tests de la fonction Pop TODO
     */
    
    /*
     * Tests de la fonction Add
     */
    [Category("Add")]
    [Test]
    public void AddUneListeALaFinDUneListeVide()
    {
        Liste? l = null;
        Liste expected = new Liste(1, null);
        ListeUtil.Add(ref l, 1);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
    }
    
    [Category("Add")]
    [Test]
    public void AddUneListeALaFinDUneChaineDe2Liste()
    {
        Liste? l = new Liste(1, new Liste(2, null));
        Liste expected = new Liste(1, new Liste(2, new Liste(3, null)));
        ListeUtil.Add(ref l, 3);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
        
    }

    [Category("Add")]
    [Test]
    public void AddUneListeA1Liste()
    {
        Liste? l = new Liste(1, null);
        Liste expected = new Liste(1, new Liste(2, null));
        
        ListeUtil.Add(ref l, 2);
        
        Assert.That(ListeUtil.Eq(l, expected), Is.True);
        
    }

    /*
     * Tests de la fonction ElemAtPosition TODO
     */
    
    /*
     * Tests de la fonction Read TODO
     */
    
    /*
     * Tests de la fonction Insert TODO
     */
    
    /*
     * Tests de la fonction Remove 
     */
    [Category("Remove")]
    [Test]
    public void RemoveLastSize2()
    {
        Liste l = new Liste(2, new Liste(5, null));
        Liste expected = new Liste(2, null);
        int expectedValue = 5;
        int? deletedValue = ListeUtil.Remove(ref l);
        
        Assert.That(ListeUtil.Eq(l,expected));
        Assert.That(deletedValue, Is.EqualTo(expectedValue));
    }
    
    [Category("Remove")]
    [Test]
    public void RemoveSize1()
    {
        Liste l = new Liste(2, null);
        Liste expected = null;
        int expectedValue = 2;
        int? deletedValue = ListeUtil.Remove(ref l);
        
        Assert.That(ListeUtil.Eq(l,expected));
        Assert.That(deletedValue, Is.EqualTo(expectedValue));
    }
    
    /*
     * Tests de la fonction RemoveAt 
     */
    [Category("RemoveAt")]
    [Test]
    public void RemoveAtPos2Size3()
    {
        Liste l = new Liste(2, new Liste(5, new Liste(3, null)));
        Liste expected = new Liste(2, new Liste(3, null));
        int expectedValue = 5;
        int? deletedValue = ListeUtil.RemoveAt(ref l,2);
        
        Assert.That(ListeUtil.Eq(l,expected));
        Assert.That(deletedValue, Is.EqualTo(expectedValue));
    }
    
    [Category("RemoveAt")]
    [Test]
    public void RemoveAtPos1Size3()
    {
        Liste l = new Liste(2, new Liste(5, new Liste(3, null)));
        Liste expected = new Liste(5, new Liste(3, null));
        int expectedValue = 2;
        int? deletedValue = ListeUtil.RemoveAt(ref l,1);
        
        Assert.That(ListeUtil.Eq(l,expected));
        Assert.That(deletedValue, Is.EqualTo(expectedValue));
    }
    
    [Category("RemoveAt")]
    [Test]
    public void RemoveAtPos2Size1()
    {
        Liste l = new Liste(2, null);
        Liste? expected = l;
        int? expectedValue = null;
        int? deletedValue = ListeUtil.RemoveAt(ref l,2);
        
        Assert.That(ListeUtil.Eq(l,expected));
        Assert.That(deletedValue, Is.EqualTo(expectedValue));
    }
    
    
}
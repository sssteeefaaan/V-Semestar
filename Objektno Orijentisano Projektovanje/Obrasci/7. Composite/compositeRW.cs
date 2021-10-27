// Composite -- Primer iz stvarnog sveta 

using System;
using System.Collections;

namespace DoFactory.GangOfFour.Composite.RealWorld
{
  
  // MainApp test aplikacija 

  class MainApp
  {
    static void Main()
    {
      // Kreiranje strukture stabla 
      CompositeElement root = 
        new CompositeElement("Picture");
      root.Add(new PrimitiveElement("Red Line"));
      root.Add(new PrimitiveElement("Blue Circle"));
      root.Add(new PrimitiveElement("Green Box"));

      CompositeElement comp = 
        new CompositeElement("Two Circles");
      comp.Add(new PrimitiveElement("Black Circle"));
      comp.Add(new PrimitiveElement("White Circle"));
      root.Add(comp);

      // Dodavanje i brisanje primitivnih elemenata 
      PrimitiveElement pe = 
        new PrimitiveElement("Yellow Line");
      root.Add(pe);
      root.Remove(pe);

      // Rekurzivni prikaz stabla 
      root.Display(1);

      // Čekanje na korisnikov unos 
      Console.Read();
    }
  }

  // "Component" – čvor u stablu

  abstract class DrawingElement
  {
    protected string name;

    // Konstruktor  
    public DrawingElement(string name)
    {
      this.name = name;
    }

    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
  }

  // "Leaf" 

  class PrimitiveElement : DrawingElement
  {
    // Konstruktor
    public PrimitiveElement(string name) : base(name) 
    {  
    }

    public override void Add(DrawingElement c)
    {
      Console.WriteLine(
        "Cannot add to a PrimitiveElement");
    }

    public override void Remove(DrawingElement c)
    {
      Console.WriteLine(
        "Cannot remove from a PrimitiveElement");
    }

    public override void Display(int indent)
    {
      Console.WriteLine(
        new String('-', indent) + " " + name);
    }
  }

  // "Composite" 

  class CompositeElement : DrawingElement
  {
    private ArrayList elements = new ArrayList();
  
    // Konstruktor
    public CompositeElement(string name) : base(name) 
    {  
    }

    public override void Add(DrawingElement d)
    {
      elements.Add(d);
    }

    public override void Remove(DrawingElement d)
    {
      elements.Remove(d);
    }

    public override void Display(int indent)
    {
      Console.WriteLine(new String('-', indent) + 
        "+ " + name);

      // Display each child element on this node 
      foreach (DrawingElement c in elements)
      {
        c.Display(indent + 2);
      }
    }
  }
}

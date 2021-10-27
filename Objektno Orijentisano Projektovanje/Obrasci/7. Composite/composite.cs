 
// Composite -- Strukturni primer

using System;
using System.Collections;

namespace DoFactory.GangOfFour.Composite.Structural
{

  // MainApp test aplikacija 

  class MainApp
  {
    static void Main()
    {
      // Kreiranje strukture stabla
      Composite root = new Composite("root");
      root.Add(new Leaf("Leaf A"));
      root.Add(new Leaf("Leaf B"));

      Composite comp = new Composite("Composite X");
      comp.Add(new Leaf("Leaf XA"));
      comp.Add(new Leaf("Leaf XB"));

      root.Add(comp);
      root.Add(new Leaf("Leaf C"));

      // Dodavanje i izbacivanje listova 
      Leaf leaf = new Leaf("Leaf D");
      root.Add(leaf);
      root.Remove(leaf);

      // Rekurzivni prikaz stabla 
      root.Display(1);

      // Čekanje na korisnikov unos 
      Console.Read();
    }
  }

  // "Component" 

  abstract class Component
  {
    protected string name;

    // Konstruktor 
    public Component(string name)
    {
      this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
  }

  // "Composite" 

  class Composite : Component
  {
    private ArrayList children = new ArrayList();

    // Konstruktor 
    public Composite(string name) : base(name) 
    {  
    }

    public override void Add(Component component)
    {
      children.Add(component);
    }

    public override void Remove(Component component)
    {
      children.Remove(component);
    }

    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);

      // Rekurzivni prikaz podelemenata 
      foreach (Component component in children)
      {
        component.Display(depth + 2);
      }
    }
  }

  // "Leaf" 

  class Leaf : Component
  {
    // Konstruktor 
    public Leaf(string name) : base(name) 
    {  
    }

    public override void Add(Component c)
    {
      Console.WriteLine("Cannot add to a leaf");
    }

    public override void Remove(Component c)
    {
      Console.WriteLine("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
    }
  }
}

using System.Reflection.Metadata.Ecma335;

namespace myApp;

class Program
{
    public interface Catalogue(string[] args)
    {
        FabriqueVehicule fabrique(Vehicule v) = new FabriqueVehicule();
    }
}

class ConcreteCatalogue : Catalogue
{
    public interface Catalogue(string[] args)
    {
       return new ConcreteCatalogue();
    }
    public interface FabriqueVehicule(Vehicule v)
    {
        return new ConcreteFabriqueVehicule();
    }
}
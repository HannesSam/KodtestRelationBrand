using System.Collections.Generic;

namespace ApiLibrary
{
    //Denna klass existerar för att få ut listan ur JSON objektet "list". Objektet RootObject sätts som lika med "list" så att man
    //Sedan kan iterera igenom detta objekt för att få ur alla listobjekt. 
    public class RootObject
    {
        public List<Subscriber> list { get; set; }
    }
}

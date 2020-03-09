using System.Collections.Generic;

namespace ApiLibrary
{
    //Denna klass skriver över defult sättet att jämföra två objekt vilket låter oss jämföra de egenskapade objektet Customer för equality.
    public class CustomComparer : IEqualityComparer<Subscriber>
    {
        public int GetHashCode(Subscriber email)
        {
            if (email == null)
            {
                return 0;
            }
            return email.Email.GetHashCode();
        }

        public bool Equals(Subscriber email1, Subscriber email2)
        {
            if (object.ReferenceEquals(email1, email2))
            {
                return true;
            }
            if (object.ReferenceEquals(email1, null) ||
                object.ReferenceEquals(email2, null))
            {
                return false;
            }
            return email1.Email == email2.Email;
        }
    }
}

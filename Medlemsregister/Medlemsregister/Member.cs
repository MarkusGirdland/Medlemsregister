using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private int _phoneNumber;
        private int _memberNumber;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new ArgumentException();
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new ArgumentException();
                }

                _lastName = value;
            }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _phoneNumber = value;
            }
        }

        public void CreateMemberNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(00000, 99999);

            this._memberNumber = randomNumber;
        }

        public string PrintToString()
        {
            string returnString;

            returnString = String.Format("\n\nNamn  :\t{0}\nEfternamn   :\t{1}\nTelefonnummer   :\t{2}\nMedlemsnummer   :\t{3}\n", _firstName, _lastName, _phoneNumber, _memberNumber);

            return returnString;
        }

        public Member()
        {
            this._firstName = "John";
            this._lastName = "Doe";
            this._memberNumber = 00000;
            this._phoneNumber = 112;
        }

    }
}

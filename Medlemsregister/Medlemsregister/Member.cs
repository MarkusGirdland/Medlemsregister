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
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
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

        public int MemberNumber
        {
            get { return _memberNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _memberNumber = value;
            }
        }

        public void CreateMemberNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);

            this._memberNumber = randomNumber;
        }

        public string PrintToString()
        {
            string returnString;

            returnString = String.Format("\nNamn:\t\t{0}\nEfternamn:\t{1}", _firstName, _lastName);

            return returnString;
        }

        public string PrintDetailedToString()
        {
            string returnString;

            returnString = String.Format("\nNamn:\t\t{0}\nEfternamn:\t{1}\nTelefonnummer:\t{2}\nMedlemsnummer:\t{3}", _firstName, _lastName, _phoneNumber, _memberNumber);

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

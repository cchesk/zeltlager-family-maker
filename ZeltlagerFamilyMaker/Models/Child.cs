using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class Child
    {
        public int id;
        public string firstName;
        public string lastName;
        public bool isMale;
        public DateTime dateOfBirth;


        public int? wishedMateId;
        public int? wishedById;
        public Child wishedMate;
        public Child wishedBy;

        public Child(int id, string firstName, string lastName, bool isMale, DateTime dateOfBirth, int? wishedMateID)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.isMale = isMale;
            this.dateOfBirth = dateOfBirth;
            
            this.wishedMateId = wishedMateID;
        }

        public Child(int id, string firstName, string lastName, bool isMale, DateTime dateOfBirth)
        {
            new Child(id, firstName, lastName, isMale, dateOfBirth, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class ChildChain
    {
        public List<Child> children;
        public Child youngestChild;
        public Child oldestChild;

        public DateTime youngestChildDateOfBirth { get { return youngestChild.dateOfBirth; } private set; }
        public DateTime oldestChildDateOfBirth { get { return oldestChild.dateOfBirth; } private set; }
    }
}

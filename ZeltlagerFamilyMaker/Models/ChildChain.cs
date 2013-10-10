using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class ChildChain
    {
        public List<Child> children { get { return children.ToList(); } private set { children = value; } }
        public Child youngestChild;
        public Child oldestChild;

        public DateTime youngestChildDateOfBirth { get { return youngestChild.dateOfBirth; } private set { youngestChildDateOfBirth = value; } }
        public DateTime oldestChildDateOfBirth { get { return oldestChild.dateOfBirth; } private set { oldestChildDateOfBirth = value; } }

        public ChildChain(Child child)
        {
            children = new List<Child>();
            youngestChild = child;
            oldestChild = child;
            children.Add(child);
        }

        public void add(Child child)
        {
            children.Add(child);

            if (child.dateOfBirth.CompareTo(youngestChild) > 0)
            {
                youngestChild = child;
            }
            else if (child.dateOfBirth.CompareTo(oldestChild) < 0)
            {
                oldestChild = child;
            }
        }
    }
}

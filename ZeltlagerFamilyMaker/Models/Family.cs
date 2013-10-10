using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class Family
    {
        public int number;

        public List<Child> boys { get { return boys.ToList(); } private set { boys = value; } }
        public List<Child> girls { get { return girls.ToList(); } private set { girls = value; } }

        public int numberOfChildren { get { return boys.Count + girls.Count; } private set { numberOfChildren = value; } }

        public Family(Child child, int number)
        {
            this.number = number;

            boys = new List<Child>();
            girls = new List<Child>();

            if (child.isMale)
            {
                boys.Add(child);
            }
            else
            {
                girls.Add(child);
            }
        }

        public void add(Child child)
        {
            if (child.isMale)
            {
                boys.Add(child);
            }
            else
            {
                girls.Add(child);
            }
        }
    }
}

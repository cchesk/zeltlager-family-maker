using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class Singleton
    {
        private static Singleton instance;
        private List<Child> allChildren;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public bool addChild(Child child)
        {
            if (allChildren.Exists(c => c.id == child.id))
            {
                allChildren.Add(child);
                return true;
            }
            return false;
        }

        // only allow 1:1 wishing connections
        public bool createAllConnections()
        {
            foreach (var child in allChildren)
            {
                if (child.wishedMateId != null)
                {
                    var wishedMate = allChildren.Find(c => c.id == (int)child.wishedMateId && c.wishedMateId == child.id);
                    {
                        child.wishedMate = wishedMate;
                        child.wishedBy = wishedMate;
                        child.wishedById = wishedMate.id;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}

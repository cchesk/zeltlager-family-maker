using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class Singleton
    {
        public Settings settings = new Settings();
        public int famSize = 10;
        public int nextFamSize = 10;
        public int variance = 1;

        private static Singleton instance;
        private List<Child> allChildren = new List<Child>();
        private List<ChildChain> allChildChains = new List<ChildChain>();
        private List<Family> allFamilies = new List<Family>();

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
            // count children
            foreach (var child in allChildren)
            {
                if (child.wishedMateId != null)
                {
                    var wishedMate = allChildren.Find(c => c.id == (int)child.wishedMateId && c.wishedMateId == child.id && Math.Abs( (c.dateOfBirth - child.dateOfBirth).Days )<= settings.maxAgeDifferenceInFam.Days);
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

        public void sortChildren()
        {
            allChildren = allChildren.OrderByDescending(c => c.dateOfBirth).ToList();
        }

        public void createChildChains()
        {
            foreach (var child in allChildren)
            {
                if (child.childChain == null)
                {
                    if (child.wishedMate != null)
                    {
                        var newChildChain = new ChildChain(child);
                        newChildChain.add(child.wishedMate);

                        child.childChain = newChildChain;
                        child.wishedMate.childChain = newChildChain;

                        allChildChains.Add(newChildChain);
                    }
                }
            }
        }

        public void initializeFams()
        {
            for (int i = 0; i < settings.famCount; i++)
            {
                ChildChain childChain;
                if (allChildChains.Count > 0)
                {
                    childChain = popChildChain();
                }
                else
                {
                    throw new Exception();
                }

                var newFamily = new Family(childChain.children[0], i);
                if (childChain.children.Count > 1)
                {
                    newFamily.add(childChain.children[1]);
                }

                while (newFamily.numberOfChildren < nextFamSize && newFamily.numberOfChildren < famSize)
                {
                    childChain = popChildChain();

                    newFamily.add(childChain.children[0]);
                    if (childChain.children.Count > 1)
                    {
                        newFamily.add(childChain.children[1]);
                    }
                }

                if (newFamily.numberOfChildren > famSize)
                {
                    nextFamSize--;
                }

                if (newFamily.numberOfChildren < famSize)
                {
                    nextFamSize++;
                }

                allFamilies.Add(newFamily);
            }
        }

        private ChildChain popChildChain()
        {
            var currentChildChain = allChildChains.First();
            allChildChains.RemoveAt(0);
            return currentChildChain;
        }
    }
}

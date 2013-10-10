using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeltlagerFamilyMaker.Models
{
    class Settings
    {
        //public int famSize;

        public int minSameSexPerFam;

        public int famCount;

        public TimeSpan maxAgeDifferenceInFam;
        
        public bool allowWishingChains;

        public Settings()
        {
            minSameSexPerFam = 4;

            famCount = 10;

            maxAgeDifferenceInFam = TimeSpan.FromDays(730);

            allowWishingChains = false;
        }
    }
}

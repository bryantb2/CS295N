using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngineProject
{
    public static class ThreadCategories
    {
        public static String GetCategory(int categorySelector)
        {
            switch(categorySelector)
            {
                // technology
                case 0:
                    return "technology";

                // education/tutorials
                case 1:
                    return "education/tutorials";

                // lifestyle
                case 2:
                    return "lifestyle";
            }

            // returns empty string if there was no number specified
            return " ";
        }
    }
}

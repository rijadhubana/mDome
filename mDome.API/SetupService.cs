using mDome.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API
{
    public class SetupService
    {
        public static void Init(mDomeT1Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}

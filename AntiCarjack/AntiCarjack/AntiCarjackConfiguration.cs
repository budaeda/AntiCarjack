using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCarjack
{
    public class AntiCarjackConfiguration : IRocketPluginConfiguration
    {
        public bool NotifyPlayerNotAllowed;
        public bool IgnoreAdmins;
        public void LoadDefaults()
        {
            NotifyPlayerNotAllowed = true;
            IgnoreAdmins = true;
        }
    }
}

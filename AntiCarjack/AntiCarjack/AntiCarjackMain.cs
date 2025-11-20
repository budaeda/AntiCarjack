using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCarjack
{
    public class AntiCarjackMain : RocketPlugin<AntiCarjackConfiguration>
    {
        public static AntiCarjackMain Instance { get; private set; }
        public AntiCarjackService ACS { get; private set; }

        protected override void Load()
        {
            Instance = this;

            ACS = new AntiCarjackService();
            Logger.Log($"{Assembly.GetName().Name} Version: {Assembly.GetName().Version} Has Successfully Loaded");
        }

        protected override void Unload()
        {
            ACS.Destroy();
            Logger.Log($"{Assembly.GetName().Name} Version: {Assembly.GetName().Version} Has Successfully Unloaded");
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                TranslationList translationList = new TranslationList();
                translationList.Add("CarjackingNotAllowed", "You Are Not Allowed To Carjack This Vehicle As You Do Not Own It!");

                return translationList;
            }
        }
    }
}

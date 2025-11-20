using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntiCarjack
{
    public class AntiCarjackService
    {
        public AntiCarjackService()
        {
            VehicleManager.onVehicleCarjacked += Event_OnVehicleCarjacked;
        }

        private void Event_OnVehicleCarjacked(InteractableVehicle vehicle, Player instigatingPlayer, ref bool shouldAllow, ref Vector3 force, ref Vector3 torque)
        {
            UnturnedPlayer uPlayer = UnturnedPlayer.FromPlayer(instigatingPlayer);
            if (uPlayer.CSteamID == vehicle.lockedOwner || uPlayer.SteamGroupID == vehicle.lockedGroup) return;
            if (AntiCarjackMain.Instance.Configuration.Instance.IgnoreAdmins && uPlayer.IsAdmin || !vehicle.isLocked) return;

            shouldAllow = false;
            if (AntiCarjackMain.Instance.Configuration.Instance.NotifyPlayerNotAllowed)
            {
                UnturnedChat.Say(uPlayer, AntiCarjackMain.Instance.Translate("CarjackingNotAllowed"), Color.red, true); ;
            }
        }

        public void Destroy()
        {
            VehicleManager.onVehicleCarjacked -= Event_OnVehicleCarjacked;
        }
    }
}

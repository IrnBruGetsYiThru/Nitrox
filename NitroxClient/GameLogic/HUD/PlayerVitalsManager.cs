﻿using System.Collections.Generic;
using NitroxClient.MonoBehaviours.Gui.HUD;
using UnityEngine;

namespace NitroxClient.GameLogic.HUD
{
    public class PlayerVitalsManager
    {
        private readonly Dictionary<ulong, RemotePlayerVitals> vitalsByPlayerId = new Dictionary<ulong, RemotePlayerVitals>();

        public void RemovePlayer(ulong playerId)
        {
            RemotePlayerVitals removedPlayerVitals = GetForPlayerId(playerId);
            vitalsByPlayerId.Remove(playerId);

            Object.Destroy(removedPlayerVitals);

            int i = 1;

            foreach (RemotePlayerVitals vitals in vitalsByPlayerId.Values)
            {
                vitals.SetNewPosition(i++);
            }
        }

        public RemotePlayerVitals GetForPlayerId(ulong playerId)
        {
            RemotePlayerVitals vitals;
            if (!vitalsByPlayerId.TryGetValue(playerId, out vitals))
            {
                vitals = new GameObject().AddComponent<RemotePlayerVitals>();

                vitals.CreateVitals(playerId, vitalsByPlayerId.Count);

                vitalsByPlayerId[playerId] = vitals;
            }

            return vitals;
        }
    }
}

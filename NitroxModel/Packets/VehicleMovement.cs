﻿using System;
using NitroxModel.DataStructures.GameLogic;
using Lidgren.Network;

namespace NitroxModel.Packets
{
    [Serializable]
    public class VehicleMovement : Movement
    {
        public VehicleMovementData Vehicle { get; }

        public VehicleMovement(ulong playerId, VehicleMovementData vehicle) : base(playerId, vehicle.Position, vehicle.Velocity, vehicle.Rotation, vehicle.Rotation)
        {
            Vehicle = vehicle;
            DeliveryMethod = NetDeliveryMethod.UnreliableSequenced;
            UdpChannel = UdpChannelId.VEHICLE_MOVEMENT;
        }

        public override string ToString()
        {
            return "[VehicleMovement - vehicle: " + Vehicle +
                "]\n\t" + base.ToString();
        }
    }
}

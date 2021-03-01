﻿namespace NebulaModel.Packets.Session
{
    public class JoinSessionConfirmed
    {
        public ushort LocalPlayerId { get; set; }

        public JoinSessionConfirmed() { }
        public JoinSessionConfirmed(ushort id) { LocalPlayerId = id; }
    }
}

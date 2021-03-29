﻿using NebulaModel.Attributes;
using NebulaModel.Networking;
using NebulaModel.Packets.GameHistory;
using NebulaModel.Packets.Processors;
using NebulaWorld.GameDataHistory;

namespace NebulaHost.PacketProcessors.GameHistory
{
    [RegisterPacketProcessor]
    class GameHistoryNotificationProcessor : IPacketProcessor<GameHistoryNotificationPacket>
    {
        private PlayerManager playerManager;

        public GameHistoryNotificationProcessor()
        {
            playerManager = MultiplayerHostSession.Instance.PlayerManager;
        }
        public void ProcessPacket(GameHistoryNotificationPacket packet, NebulaConnection conn)
        {
            Player player = playerManager.GetPlayer(conn);
            if (player != null)
            {
                GameDataHistoryManager.IsIncommingRequest = true;
                switch(packet.Event)
                {
                    case GameHistoryEvent.ResumeQueue:
                        GameMain.history.ResumeTechQueue();
                        break;
                    case GameHistoryEvent.PauseQueue:
                        GameMain.history.PauseTechQueue();
                        break;
                }
                GameDataHistoryManager.IsIncommingRequest = false;
                playerManager.SendPacketToOtherPlayers(packet, player);
            }
        }
    }
}
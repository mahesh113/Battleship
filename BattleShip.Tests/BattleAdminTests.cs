using Moq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using System.Collections.Generic;

namespace BattleShip.Tests
{
    public class BattleAdminTests
    {

        [Fact]
        public void AdminReturnsPlayersArray()
        {
            var players = BattleShipAdmin.Initialize();

            Assert.NotNull(players);
            Assert.IsType<Player[]>(players);
            Assert.Equal(2, players.Length);
        }
        [Fact]
        public void AdminSetsTheOpponent()
        {
            var players = BattleShipAdmin.Initialize();
            var player1 = players[0];
            var player2 = players[1];

            Assert.NotNull(players);
            Assert.NotNull(player2.opponent);
            Assert.NotNull(player1.opponent);
            Assert.Equal(player2, player1.opponent);
            Assert.Equal(player1, player2.opponent);

        }
    }
}

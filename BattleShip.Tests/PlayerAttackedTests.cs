using Moq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using System.Collections.Generic;

namespace BattleShip.Tests
{
    public class PlayerAttackedTests
    {
        IPlayer player1;
        IPlayer player2;

        void Setup()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.RepeatCount = 2;
            IList<Player> players = fixture.Create<List<Player>>();
            player1 = players[0];
            player2 = players[1];

            player1.opponent = player2;
            player2.opponent = player1;
            player1.PlaceShipOnBoard(new ShipPosition
            {
                X = 0,
                Y = 4,
                Length = 5,
                Align = ShipPosition.AlignmentType.Horizontal
            });
        }
        [Fact]
        public void AttackedWhenNoShips()
        {
            Setup();

            bool ret = player2.HitFromOpponent(3, 3);

            Assert.False(ret);
        }
        [Fact]
        public void MissedAttack()
        {
            Setup();

            bool ret = player1.HitFromOpponent(0, 5);

            Assert.False(ret);
        }
        [Fact]
        public void HitTheShip()
        {
            Setup();

            bool ret = player1.HitFromOpponent(1, 4);

            Assert.True(ret);
        }
        [Fact]
        public void HitTwiceAtSamePointOnShip()
        {
            Setup();

            bool ret = player1.HitFromOpponent(1, 4);
            Assert.True(ret);
            ret = player1.HitFromOpponent(1, 4);
            Assert.False(ret);
        }
        [Fact]
        public void HitMultipleOnShip()
        {
            Setup();

            bool ret = player1.HitFromOpponent(1, 4);
            Assert.True(ret);
            ret = player1.HitFromOpponent(3, 4);
            Assert.True(ret);
            ret = player1.HitFromOpponent(0, 4);
            Assert.True(ret);
            ret = player1.HitFromOpponent(2, 4);
            Assert.True(ret);
            ret = player1.HitFromOpponent(4, 4);
            Assert.True(ret);

            Assert.True(player1.HasLost());
        }
        [Fact]
        public void InvalidCoordinates()
        {
            Setup();

            bool ret = player1.HitFromOpponent(5, 10);
            Assert.False(ret);
            ret = player1.HitFromOpponent(1, -1);
            Assert.False(ret);
            ret = player1.HitFromOpponent(10, 3);
            Assert.False(ret);
            ret = player1.HitFromOpponent(-1, 6);
            Assert.False(ret);
        }
    }
}

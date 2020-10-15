using Moq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using System.Collections.Generic;

namespace BattleShip.Tests
{
    public class PlayerAttackTests
    {
        IPlayer player1;
        IPlayer player2;

        void Setup()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.RepeatCount = 2;
            IList<Player>  players = fixture.Create<List<Player>>();
            player1 = players[0];
            player2 = players[1];

            player1.opponent = player2;
            player2.opponent = player1;
            var AdminMock = fixture.Freeze<Mock<ILauncher>>();

            //var adminMock = fixture.Freeze<Mock<ILauncher>>();
            AdminMock.Setup(admin => admin.AttackHandler(It.IsAny<int>(),
                                                It.IsAny<int>(),
                                                It.IsAny<IPlayer>()))
                     .Returns(true) ;

        }
        [Fact]
        public void WrongCoordinates()
        {
            Setup();
            int x = 0, y = 10;
            bool ret = player1.Attack(x, y);

            Assert.False(ret);

            x = -1; y = 3;
            ret = player1.Attack(x, y);

            Assert.False(ret);
        }
        [Fact]
        public void NoShipPlaced()
        {
            Setup();
            int x = 0, y = 5;
            bool ret = player1.Attack(x, y);

            Assert.False(ret);
        }
        [Fact]
        public void ShipPlaceddd()
        {
            Setup();
            int x = 0, y = 5;

            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 4,
                Length = 11,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            player1.PlaceShipOnBoard(pos);

            bool ret = player1.Attack(x, y);

            Assert.False(ret);
        }
        [Fact]
        public void TestHasLost()
        {
            Setup();
            int x = 0;
            bool ret = true;

            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 4,
                Length = 5,
                Align = ShipPosition.AlignmentType.Vertical
            };
            player1.PlaceShipOnBoard(pos);
            player2.PlaceShipOnBoard(pos);


            for (int y = 4; y < 9; y++)
            {
                 player2.Attack(x, y);
            }
            

            ret = player1.HasLost();
            Assert.True(ret);
        }
        [Fact]
        public void InvalidCoordinates()
        {
            Setup();

            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 4,
                Length = 5,
                Align = ShipPosition.AlignmentType.Vertical
            };
            bool ret = player1.Attack(5, 10);
            Assert.False(ret);
            ret = player1.Attack(1, -1);
            Assert.False(ret);
            ret = player1.Attack(10, 3);
            Assert.False(ret);
            ret = player1.Attack(-1, 6);
            Assert.False(ret);
        }
    }
}

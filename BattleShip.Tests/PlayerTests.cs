using Moq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using BattleShip;

namespace BattleShip.Tests
{
    public class PlayerTests
    {
        IPlayer _sut;

        void Setup()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _sut = fixture.Create<Player>();

        }
            [Fact]
        public void ShipPositionWithOutOfBoundXY()
        {
            Setup();
            ShipPosition pos1 = new ShipPosition
            {
                X = 0,
                Y = 10,
                Length = 9,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            ShipPosition pos2 = new ShipPosition
            {
                X = -1,
                Y = 4,
                Length = 9,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            bool ret1 = _sut.PlaceShipOnBoard(pos1);
            bool ret2 = _sut.PlaceShipOnBoard(pos2);

            Assert.False(ret1);
            Assert.False(ret2);

        }
    }
}

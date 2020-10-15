using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;

namespace BattleShip.Tests
{
    public class PlayerShipPlacementTests
    {
        IPlayer _sut;

        void Setup()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _sut = fixture.Create<Player>();

        }
        [Fact]
        public void PlaceShipPositionWithOutOfBoundLength()
        {
            Setup();
            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 4,
                Length = 11,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.False(ret);
        }
        [Fact]
        public void PlaceShipPositionWithOutOfBoundXY()
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
        [Fact]
        public void PlaceShipCoveringFullRow()
        {
            Setup();
            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 6,
                Length = 10,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.True(ret);
        }
        [Fact]
        public void PlaceShipCoveringFullColumn()
        {
            Setup();
            var pos = new ShipPosition
            {
                X = 8,
                Y = 0,
                Length = 10,
                Align = ShipPosition.AlignmentType.Vertical
            };
            var ret = _sut.PlaceShipOnBoard(pos);

            Assert.True(ret);
        }

        [Fact]
        public void PlaceShipCoveringWithIntersectingShips()
        {
            Setup();
            ShipPosition pos = new ShipPosition
            {
                X = 5,
                Y = 2,
                Length = 4,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.True(ret);

            pos = new ShipPosition
            {
                X = 8,
                Y = 0,
                Length = 4,
                Align = ShipPosition.AlignmentType.Vertical
            };
            ret = _sut.PlaceShipOnBoard(pos);

            // Second Ship intersects, so return false
            Assert.False(ret);
        }

        [Fact]
        public void PlaceShipWhichGoesOutOfBoundDuringPlacement()
        {
            Setup();
            ShipPosition pos = new ShipPosition
            {
                X = 0,
                Y = 7,
                Length = 4,
                Align = ShipPosition.AlignmentType.Vertical
            };
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.False(ret);
            pos = new ShipPosition
            {
                X = 6,
                Y = 7,
                Length = 5,
                Align = ShipPosition.AlignmentType.Horizontal
            };
            ret = _sut.PlaceShipOnBoard(pos);

            Assert.False(ret);
        }

        [Fact]
        public void NullShipObject()
        {
            Setup();
            ShipPosition pos = null;
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.False(ret);
        }

        [Fact]
        public void UninitializedShipObject()
        {
            Setup();
            ShipPosition pos = new ShipPosition();
            bool ret = _sut.PlaceShipOnBoard(pos);

            Assert.False(ret);
        }
    }
}

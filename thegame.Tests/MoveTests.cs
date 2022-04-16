using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using thegame.Models;

namespace thegame.Tests
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void MoveDown_ShouldMoveSingleNumber()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;3", new VectorDto(0,1), "", "0", 0),
            };
            
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("2");
        }
        
        [Test]
        public void MoveDown_ShouldMoveMultipleVariousNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,1), "", "4", 0),
                new CellDto("0;3", new VectorDto(0,1), "", "0", 0),
            };
            
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            game.Cells.First(cell => cell.Pos.Y == 2).Content.Should().Be("2");
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("4");
        }
        
        [Test]
        public void MoveDown_ShouldSumEqualNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,1), "", "2", 0),
                new CellDto("0;3", new VectorDto(0,1), "", "0", 0),
            };
            
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("4");
        }
    }
}

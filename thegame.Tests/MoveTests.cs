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
        [Test, Category("MoveDown")]
        public void MoveDown_ShouldMoveSingleNumber()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "0", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "0", 0),
            };
            var game = new GameDto(testCells, false, false, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("2");
        }
        
        [Test, Category("MoveDown")]
        public void MoveDown_ShouldMoveMultipleVariousNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "4", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "0", 0),
            };
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            
            game.Cells.First(cell => cell.Pos.Y == 2).Content.Should().Be("2");
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("4");
        }
        
        [Test, Category("MoveDown")]
        public void MoveDown_ShouldSumEqualNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "2", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "0", 0),
            };
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveDown();
            
            game.Cells.First(cell => cell.Pos.Y == 3).Content.Should().Be("4");
        }
        
        [Test, Category("MoveUp")]
        public void MoveUp_ShouldMoveSingleNumber()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "0", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "2", 0),
            };
            var game = new GameDto(testCells, false, false, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveUp();
            
            game.Cells.First(cell => cell.Pos.Y == 0).Content.Should().Be("2");
        }
        
        [Test, Category("MoveUp")]
        public void MoveUp_ShouldMoveMultipleVariousNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "4", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "0", 0),
            };
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveUp();
            
            game.Cells.First(cell => cell.Pos.Y == 0).Content.Should().Be("2");
            game.Cells.First(cell => cell.Pos.Y == 1).Content.Should().Be("4");
        }
        
        [Test, Category("MoveUp")]
        public void MoveUp_ShouldSumEqualNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("0;1", new VectorDto(0,1), "", "0", 0),
                new CellDto("0;2", new VectorDto(0,2), "", "2", 0),
                new CellDto("0;3", new VectorDto(0,3), "", "0", 0),
            };
            var game = new GameDto(testCells, true, true, 1, 4, Guid.NewGuid(), false, 0); 
            
            game.MoveUp();
            
            game.Cells.First(cell => cell.Pos.Y == 0).Content.Should().Be("4");
        }

        [Test, Category("MoveLeft")]
        public void MoveLeft_ShouldMoveSingleNumber()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "0", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "2", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveLeft();
            
            game.Cells.First(cell => cell.Pos.X == 0).Content.Should().Be("2");
        }
        
        [Test, Category("MoveLeft")]
        public void MoveLeft_ShouldMoveMultipleVariousNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "2", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "4", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveLeft();
            
            game.Cells.First(cell => cell.Pos.X == 0).Content.Should().Be("2");
            game.Cells.First(cell => cell.Pos.X == 1).Content.Should().Be("4");
        }
        
        [Test, Category("MoveLeft")]
        public void MoveLeft_ShouldSumEqualNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "2", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "2", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveLeft();
            
            game.Cells.First(cell => cell.Pos.X == 0).Content.Should().Be("4");
        }
        
        [Test, Category("MoveRight")]
        public void MoveRight_ShouldMoveSingleNumber()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "2", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "0", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "0", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveRight();
            
            game.Cells.First(cell => cell.Pos.X == 3).Content.Should().Be("2");
        }
        
        [Test, Category("MoveRight")]
        public void MoveRight_ShouldMoveMultipleVariousNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "2", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "4", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveRight();
            
            game.Cells.First(cell => cell.Pos.X == 2).Content.Should().Be("2");
            game.Cells.First(cell => cell.Pos.X == 3).Content.Should().Be("4");
        }
        
        [Test, Category("MoveRight")]
        public void MoveRight_ShouldSumEqualNumbers()
        {
            var testCells = new[]
            {
                new CellDto("0;0", new VectorDto(0,0), "", "0", 0),
                new CellDto("1;0", new VectorDto(1,0), "", "2", 0),
                new CellDto("2;0", new VectorDto(2,0), "", "0", 0),
                new CellDto("3;0", new VectorDto(3,0), "", "2", 0),
            };
            var game = new GameDto(testCells, false, false, 4, 1, Guid.NewGuid(), false, 0); 
            
            game.MoveRight();
            
            game.Cells.First(cell => cell.Pos.X == 3).Content.Should().Be("4");
        }
        
    }
}

using System;
using Xunit;
using ConwaysGameOfLife;

namespace ConwaysGameOfLifeTests
{
    public class UnitTest1
    {
        public int[,] FirstGen = new int[,]
        {
            {0,0,1,0,0},
            {0,0,0,1,0},
            {0,1,1,1,0},
            {0,0,0,0,0},
            {0,0,0,0,0}
        };
        public int[,] SecondGen = new int[,]
        {
            {0,0,0,0,0},
            {0,1,0,1,0},
            {0,0,1,1,0},
            {0,0,1,0,0},
            {0,0,0,0,0}
        };
        public int[,] ThirdGen = new int[,]
        {
            {0,0,0,0,0},
            {0,0,0,1,0},
            {0,1,0,1,0},
            {0,0,1,1,0},
            {0,0,0,0,0}
        };
        public int[,] WrongSecondGen = new int[,]
        {
            {0,0,0,0,0},
            {0,1,0,1,0},
            {1,0,1,1,0},
            {0,0,1,0,0},
            {0,0,0,0,0}
        };

        [Fact]
        public void ShouldReturnCorrectNumberOfLiveNeighbors()
        {
            // given FirstGen grid, neighbors for [1,2] = 5
            var liveNeighbors = GameOfLife.CheckNeighbors(FirstGen, 1, 2);
            Assert.True(liveNeighbors == 5);
        }

        [Fact]
        public void ShouldReturnIncorrectNumberOfLiveNeighbors()
        {
            //given FirstGen grid, neighbors for [1,3] = 3
            var liveNeighbors = GameOfLife.CheckNeighbors(FirstGen, 1, 3);
            Assert.False(liveNeighbors == 4);
        }

        [Fact]
        public void ShouldReturnCorrectSecondGenerationGivenFirst()
        {
            //check that returned generation is as expected
            var secondGen = GameOfLife.GenerateNextGeneration(FirstGen);
            Assert.Equal(SecondGen, secondGen);
        }

        [Fact]
        public void ShouldReturnCorrectThirdGenerationGivenSecond()
        {
            //check that returned generation is as expected
            var thirdGen = GameOfLife.GenerateNextGeneration(SecondGen);
            Assert.Equal(ThirdGen, thirdGen);
        }

        [Fact]
        public void ShouldReturnCorrectSecondGenerationGivenFirstNotEqualToWrongOne()
        {
            //check that returned generation is NOT as expected
            var secondGen = GameOfLife.GenerateNextGeneration(FirstGen);
            Assert.NotEqual(WrongSecondGen, secondGen);
        }
    }
}

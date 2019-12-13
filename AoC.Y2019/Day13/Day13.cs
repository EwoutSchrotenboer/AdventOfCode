using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day13 : BaseDay
    {
        private Dictionary<Point, TileType> screen = new Dictionary<Point, TileType>();

        public Day13() : base(2019, 13)
        {
        }

        public Day13(IEnumerable<string> inputLines) : base(2019, 13, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = ParseInput(inputLines);
            var outputs = RunProgram(program, new List<long>());
            var tiles = GetTiles(outputs);
            return tiles.Count(t => t.TileType == TileType.Block);
        }

        protected override IConvertible PartTwo()
        {
            var program = ParseInput(inputLines);
            var score = PlayGame(program);
            return score;
        }

        private static List<Tile> GetTiles(List<long> outputs)
        {
            var tiles = new List<Tile>();

            for (int i = 0; i < outputs.Count; i += 3)
            {
                tiles.Add(new Tile(outputs[i], outputs[i + 1], outputs[i + 2]));
            }

            return tiles;
        }

        private static string ParseInput(IEnumerable<string> inputLines) => inputLines.First();

        private static List<long> RunProgram(string program, List<long> inputs)
        {
            var arcade = new Computer(program, inputs);
            var (_, outputs) = arcade.Run();

            return outputs;
        }

        private long PlayGame(string program)
        {
            var arcade = new Computer(program);
            arcade.SetAddress(0, 2);

            var (_, outputs) = arcade.Run();

            while (!arcade.Finished)
            {
                var (joystickDirection, _, blocksLeft) = ProcessResults(outputs);
                if (!blocksLeft) { break; }
                arcade.ClearOutputs();
                (_, outputs) = arcade.Resume(joystickDirection);
            }

            var (_, finalScore, _) = ProcessResults(outputs);

            return finalScore;
        }

        private (long paddleInput, long score, bool blocksLeft) ProcessResults(List<long> outputs)
        {
            var tiles = GetTiles(outputs);

            Point ballPos = new Point(-1, -1);
            Point paddlePos = new Point(-1, -1);
            var score = 0;

            foreach (var tile in tiles)
            {
                if (!screen.Keys.Contains(tile.Position))
                {
                    screen.Add(tile.Position, TileType.Empty);
                }

                screen[tile.Position] = tile.TileType;

                switch (tile.TileType)
                {
                    case TileType.Ball: ballPos = tile.Position; break;
                    case TileType.Paddle: paddlePos = tile.Position; break;
                    case TileType.Score: score = tile.Score; break;
                }
            }

            var blocksLeft = screen.Values.Any(t => t == TileType.Block);

            if (ballPos.X < paddlePos.X) { return (-1, score, blocksLeft); }
            else if (ballPos.X > paddlePos.X) { return (1, score, blocksLeft); }
            else { return (0, score, blocksLeft); }
        }
    }
}
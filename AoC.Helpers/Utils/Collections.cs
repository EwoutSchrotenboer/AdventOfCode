using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Helpers.Utils
{
    public static partial class Extensions
    {
        public static (Point upperLeft, Point downRight) GetDimensions(this IEnumerable<Point> data)
        {
            return (
                new Point(data.Select(p => p.X).Min(), data.Select(p => p.Y).Min()),
                new Point(data.Select(p => p.X).Max(), data.Select(p => p.Y).Max())
            );
        }

        public static (int sizeX, int sizeY, int offsetX, int offsetY) GetSizesAndOffsets(this IEnumerable<Point> data)
        {
            var upperLeft = new Point(data.Select(p => p.X).Min(), data.Select(p => p.Y).Min());
            var downRight = new Point(data.Select(p => p.X).Max(), data.Select(p => p.Y).Max());

            var offsetX = Math.Abs(upperLeft.X);
            var offsetY = Math.Abs(upperLeft.Y);
            var sizeX = downRight.X + offsetX;
            var sizeY = downRight.Y + offsetY;

            return (sizeX, sizeY, offsetX, offsetY);
        }

        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
                    where TValue : new()
        {
            return dict.GetOrCreate(key, new TValue());
        }

        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultIfNull)
        {
            if (!dict.TryGetValue(key, out TValue val))
            {
                val = defaultIfNull;
                dict.Add(key, val);
            }

            return val;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static char[,] To2DCharArray(this IEnumerable<string> inputLines)
        {
            var lines = inputLines.ToList();
            var result = new char[lines.Count(), lines.First().Length];

            for (int y = 0; y < result.GetLength(0); y++)
            {
                for (int x = 0; x < result.GetLength(1); x++)
                {
                    result[y, x] = lines[y][x];
                }
            }
            return result;
        }
    }
}
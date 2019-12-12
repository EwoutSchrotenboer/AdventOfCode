using AoC.Helpers.Days;
using AoC.Helpers.Models.Day04;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AoC.Y2018.Days
{
    public class Day03 : BaseDay
    {
        public Day03() : base(2018, 3) { }

        public Day03(IEnumerable<string> inputLines) : base(2018, 3, inputLines) { }

        protected override IConvertible PartOne()
        {
            var claims = this.GetClaims(this.inputLines);

            var overlappedPoints = this.GetOverlappedPoints(claims);

            return overlappedPoints.Count;
        }

        protected override IConvertible PartTwo()
        {
            var claims = this.GetClaims(this.inputLines);

            var overlappingClaims = this.GetOverlappedClaims(claims);

            foreach (var claim in claims)
            {
                if (overlappingClaims.Add(claim))
                {
                    return claim.Id;
                }
            }

            return null;
        }

        private List<FabricClaim> GetClaims(IEnumerable<string> lines)
        {
            var claims = new List<FabricClaim>();

            foreach (var line in lines)
            {
                claims.Add(new FabricClaim(line));
            }

            return claims;
        }

        private IEnumerable<Point> GetIntersectedSurface(Rectangle overlap)
        {
            var points = new List<Point>();

            for (int withIndex = 0; withIndex < overlap.Width; withIndex++)
            {
                for (int heightIndex = 0; heightIndex < overlap.Height; heightIndex++)
                {
                    var xCoord = withIndex + overlap.X;
                    var yCoord = heightIndex + overlap.Y;

                    points.Add(new Point(xCoord, yCoord));
                }
            }

            return points;
        }

        private HashSet<FabricClaim> GetOverlappedClaims(List<FabricClaim> claims)
        {
            var overlappingClaims = new HashSet<FabricClaim>();

            for (int i = 0; i < claims.Count; i++)
            {
                for (int j = i + 1; j < claims.Count; j++)
                {
                    if (!(overlappingClaims.Contains(claims[i]) || overlappingClaims.Contains(claims[j])))
                    {
                        var intersection = Rectangle.Intersect(claims[i].Surface, claims[j].Surface);

                        if (!intersection.IsEmpty && intersection.Width > 0 && intersection.Height > 0)
                        {
                            overlappingClaims.Add(claims[i]);
                            overlappingClaims.Add(claims[j]);
                        }
                    }
                }
            }

            return overlappingClaims;
        }

        private HashSet<Point> GetOverlappedPoints(List<FabricClaim> claims)
        {
            var overlappingPoints = new HashSet<Point>();

            for (int i = 0; i < claims.Count; i++)
            {
                for (int j = i + 1; j < claims.Count; j++)
                {
                    var intersection = Rectangle.Intersect(claims[i].Surface, claims[j].Surface);

                    if (!intersection.IsEmpty && intersection.Width > 0 && intersection.Height > 0)
                    {
                        foreach (var point in this.GetIntersectedSurface(intersection))
                        {
                            overlappingPoints.Add(point);
                        }
                    }
                }
            }

            return overlappingPoints;
        }
    }
}
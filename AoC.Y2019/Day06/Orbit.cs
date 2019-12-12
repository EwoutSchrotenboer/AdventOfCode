using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    public class Orbit
    {
        public string Name { get; set; }
        public Orbit Parent { get; set; }
        public List<Orbit> Children { get; set; } = new List<Orbit>();

        public Orbit(string name) 
        {
            Name = name;
        }

        public Orbit(Orbit parent, string name) : this(name)
        {
            Parent = parent;
        }

		public int GetOrbitCount()
		{
			if (Parent != null)
			{
				return Parent.GetOrbitCount() + 1;
			}

			return 0;
		}

		public int GetChildOrbitCounts()
		{
			var count = 0;

			foreach (var child in Children)
			{
				count += child.GetChildOrbitCounts();
			}

			return count + GetOrbitCount();
		}

		public List<Orbit> GetOrbitsToSource(List<Orbit> orbits)
		{
			if (Parent != null)
			{
				orbits.Add(Parent);
				return Parent.GetOrbitsToSource(orbits);
			}

			return orbits;
		}
	}
}

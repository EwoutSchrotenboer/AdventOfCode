using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day11 : BaseDay
    {
		private const long StateMask = 0b11111111_11111111_11111111_11111111_11111111_11111111;
		private const int Down = -1;
		private const int Up = 1;
		private static readonly int[] ElevatorDirections = new int[] { Down, Up };

		public Day11() : base(2016, 11)
        {
        }

        public Day11(IEnumerable<string> inputLines) : base(2016, 11, inputLines)
        {
        }

        protected override IConvertible PartOne()
		{
			var inputItems = ParseInput(inputLines);
			var initialState = GetInitialState(inputItems.elementItems, inputItems.elements, false);
			return CalculateShortest(initialState);
		}

        protected override IConvertible PartTwo()
		{
			// Note, horribly slow: ~2 minutes. Needs an optimization by pruning similar but not equal states.
			var inputItems = ParseInput(inputLines);
			var initialState = GetInitialState(inputItems.elementItems, inputItems.elements, true);
			return CalculateShortest(initialState);
		}

		private static int CalculateShortest(ElementsState state)
		{
			var minimumSteps = int.MaxValue;
			var stateQueue = new Queue<ElementsState>();
			stateQueue.Enqueue(state);
			var visited = new Dictionary<ElementsState, int>();

			var loop = 0;

			while (stateQueue.Any())
			{
				var currentState = stateQueue.Dequeue();

				if (visited.TryGetValue(currentState, out var steps))
				{
					if (steps <= currentState.Steps) { continue; }
					else { visited[currentState] = currentState.Steps; }
				}
				else
				{
					visited.Add(currentState, currentState.Steps);
				}

				if ((currentState.Items & StateMask) == 0)
				{
					minimumSteps = Math.Min(minimumSteps, currentState.Steps);
					continue;
				}

				foreach (var direction in ElevatorDirections)
				{
					if (currentState.Elevator == 0 && direction == Down) { continue; }
					if (currentState.Elevator == 3 && direction == Up) { continue; }

					for (var firstIndex = 0; firstIndex < 16; firstIndex++)
					{
						// single item
						var nextState = GetNextState(currentState, direction, firstIndex);
						if (nextState != null)
						{
							stateQueue.Enqueue(nextState);
						}

						// two items
						for (var secondIndex = firstIndex + 1; secondIndex < 16; secondIndex++)
						{
							nextState = GetNextState(currentState, direction, firstIndex, secondIndex);
							if (nextState != null)
							{
								stateQueue.Enqueue(nextState);
							}
						}
					}
				}

				loop++;
			}

			return minimumSteps;
		}

		private static ElementsState? GetNextState(ElementsState currentState2, int direction, int first, int second = -1)
		{
			var elevator = currentState2.Elevator;
			var items = currentState2.Items;
			var steps = currentState2.Steps;

			var secondUsed = second != -1;
			if (secondUsed
				&& ((first >= 8 && second < 8 && first != second + 8)
				|| (first < 8 && second >= 8 && first != second - 8)))
			{
				return null;
			}

			int nextElevator = elevator + direction;
			var nextItems = items;

			var oldFirst = 1ul << (elevator * 16 + first);
			var newFirst = 1ul << (nextElevator * 16 + first);
			var oldSecond = secondUsed ? 1ul << (elevator * 16 + second) : 0;
			var newsecond = secondUsed ? 1ul << (nextElevator * 16 + second) : 0;

			if ((items & oldFirst) == 0) { return null; }
			if (secondUsed && (items & oldSecond) == 0) { return null; }

			nextItems &= ~oldFirst;
			nextItems |= newFirst;

			if (secondUsed)
			{
				nextItems &= ~oldSecond;
				nextItems |= newsecond;
			}

			for (int floor = 0; floor < 4; floor++)
			{
				var chips = (nextItems >> (floor * 16 + 8) & 0xFF);
				var gens = (nextItems >> (floor * 16) & 0XFF);

				var unprotectedChips = chips & ~gens;
				if (unprotectedChips != 0 && gens != 0) { return null; }
			}

			return new ElementsState(nextItems, nextElevator, steps + 1);
		}

		private static ElementsState GetInitialState(List<(string element, int floor, bool generator)> elementItems, List<string> elements, bool partTwo)
		{
			// | Floor 4      |              | Floor 3      |              | Floor 2      |              | Floor 1      |              |
			// | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
			// | Chips        | Generators   | Chips        | Generators   | Chips        | Generators   | Chips        | Generators   |
			// | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 | _ (00) 00000 |
			ulong state = 0;

			foreach (var elementItem in elementItems)
			{
				var power = elements.IndexOf(elementItem.element);
				var shift = (elementItem.floor - 1) * 16 + (elementItem.generator ? 0 : 8);
				var item = ((ulong)Math.Pow(2, power) << shift);
				state += item;
			}


			if (partTwo)
			{
				state += (ulong)Math.Pow(2, 5); // elerium generator
				state += (ulong)Math.Pow(2, 6); // dilithium generator
				state += (ulong)Math.Pow(2, 5) << 8; // elerium chip
				state += (ulong)Math.Pow(2, 6) << 8; // dilithium chip
			}

			return new ElementsState(state);
		}

		private static (List<(string element, int floor, bool generator)> elementItems, List<string> elements) ParseInput(IEnumerable<string> inputLines)
		{
			var elementItems = new List<(string, int, bool)>();
			var elements = new List<string>();
			var floor = 1;

			foreach (var line in inputLines)
			{
				var items = line.Replace(",", "").Replace(".", "").Split(new char[] { ' ', '-' });

				for (int i = 0; i < items.Length; i++)
				{
					if (items[i] == "generator" || items[i] == "compatible")
					{
						elementItems.Add((items[i - 1], floor, items[i] == "generator"));
						elements.Add(items[i - 1]);
					}

				}

				floor++;
			}

			return (elementItems, elements.Distinct().ToList());
		}
	}
}

using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day23 : BaseDay
    {
        public Day23() : base(2017, 23)
        {
        }

        public Day23(IEnumerable<string> inputLines) : base(2017, 23, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = inputLines.Select((l, index) => new CoInstruction(index, l)).ToList();
            var coprocessor = new Coprocessor(program, true);
            coprocessor.Run();
            return coprocessor.MulInvoked;
        }

        protected override IConvertible PartTwo()
        {
			var program = inputLines.Select((l, index) => new CoInstruction(index, l)).ToList();

			//  0 set b 84			
			//  1 set c b			
			//  2 jnz a 2			Part two triggers when register A is set to a non 0 value
			//  3 jnz 1 5			This increases the values for registers B and C to form a range over which we will iterate.
			//  4 mul b 100			For this input, it results in B = 108400, C = 125400
			//  5 sub b -100000	
			var b = (int.Parse(program[0].B) * int.Parse(program[4].B)) - int.Parse(program[5].B);
			//  6 set c b			
			//  7 sub c - 17000	
			var c = b - int.Parse(program[7].B);
			var h = 0;

			var step = int.Parse(program[30].B) * -1; // Defined in instruction #30
			for (int value = b; value <= c; value += step)
			{
				//  8 set f 1			| <-- Outer loop - This loop runs from 9 to 31. It executes the inner loops, checks if B is larger than C, and if it is not, adds 17 to B
				//  9 set d 2			| 
				// 10 set e 2			| | <-- The inner loops set D and E to 2, and iterate over all values from 2 to the current value of B.
				// 11 set g d			| |	| G is the multiplication of D and E, and is used as an accumulator, to check the value by comparing it to B.
				// 12 mul g e			| | | if G - B equals 0, or: D * E == B, F is set to 0 (executed in  instructions 11-13, checked in 14.
				// 13 sub g b			| | |
				// 14 jnz g 2			| | |
				// 15 set f 0			| | |
				// 16 sub e -1			| | | Increase E by one
				// 17 set g e			| | | Set E to G
				// 18 sub g b			| | | Subtract B from G and check if the result is zero
				// 19 jnz g -8			| | | If it is not, return to 11, to loop again.
				// 20 sub d -1			| | Increase D by one
				// 21 set g d			| | Set D to G
				// 22 sub g b			| | Subtract B from G and check if the result is zero
				// 23 jnz g -13			| | If it is not, return to 11, to loop again.
				// 24 jnz f 2			| Check if any of the looped values were valid (D * E == B), meaning b is divisible by anything other than 1 or itself, so it is a composite.
				// 25 sub h -1			| Add 1 to H if B is a composite.
				if (!IsPrime(value)) { h++; }
				// 26 set g b			| Set G to B
				// 27 sub g c			| Subtract C from G
				// 28 jnz g 2			| if G is not zero (B == C) jump over the exit condition
				// 29 jnz 1 3			|
				// 30 sub b -17			| Add 17 to B, and return to 8, restarting the process for the next value of B.
				// 31 jnz 1 - 23		| Summarized: For the values between 108400 and 125400, with jumps of 17, check if they are composites or primes. Return the composite count.
			}

			return h;
		}

		private static bool IsPrime(int n)
		{
			//  6k ± 1 optimization
			if (n <= 3) { return n > 1; }
			else if (n % 2 == 0 || n % 3 == 0) { return false; }

			var i = 5;

			while (i * i <= n)
			{
				if (n % i == 0 || n % (i + 2) == 0) { return false; }
				i += 6;
			}

			return true;
		}
	}
}

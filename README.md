# Advent of Code

This repository contains my solutions to the advent of code puzzles ( https://adventofcode.com/ )

Some tests are tailored to my personal inputs, but many use the given examples in the puzzles.

To automate input retrieval and caching, add your login token in the AoC.Helpers.Utils.Constants-class.

## Retrospective 2019

I had a lot of fun solving the puzzles, and building a simple VM was great. The hardest puzzles were day 18 and day 22 for me.
18 was very informative, as I initially implemented a simple brute force solution that ground to a halt after the first few testcases. Caching the routes between keys was a great new perspective.

Day 22 was less fun, as it was too 'mathy' for my tastes. But with the help of some internet users who explained the problem and the math involved, I finally retrieved my stars.

I've spent some time making the solutions generic, but day 25 is tailored to my own input. However, by adjusting Program.cs in the CLI-project it is possible to play the game for yourself!

Next year, I'll try to start on day 1, as I had some catching up to do.

I have omitted the score-parts of my ranking table, as I've scored exactly zero points:

| Day  | Part One | | Part Two | |
|---:|---:|---:|---:|---:|
|    |     Time |  Rank  |     Time |  Rank|
| 25  | 02:44:15 |   802  | 02:44:32 |   597|
| 24  | 01:24:54 |   983  | 02:07:11 |   593|
| 23  | 02:14:14 |   977  | 02:44:50 |   920|
| 22  | 04:49:57 |  1725  | 08:04:47 |   635|
| 21  | 01:01:55 |   673  | 01:30:29 |   514|
| 20  | 01:50:49 |   763  | 02:02:17 |   425|
| 19  | 00:36:13 |  1113  | 01:23:12 |   669|
| 18  | 08:31:12 |   875  | 08:59:00 |   583|
| 17  | 00:55:54 |  1451  | 02:18:30 |   794|
| 16  | 01:09:52 |  1550  | 01:51:00 |   401|
| 15  | 03:44:27 |  1384  | 04:01:29 |  1197|
| 14  | 06:09:05 |  2168  | 07:01:57 |  1913|
| 13  | 00:46:26 |  2169  | 02:00:14 |  1544|
| 12  | 01:27:48 |  2343  | 02:05:04 |  1133|
| 11  | 00:53:21 |  1457  | 01:03:35 |  1343|
| 10  | 07:51:27 |  5482  | 08:29:14 |  3355|
|  9  | 07:28:20 |  5271  | 07:29:22 |  5194|
|  8  |     >24h | 14709  |     >24h | 14314|
|  7  |     >24h | 14380  |     >24h | 11741|
|  6  |     >24h | 19635  |     >24h | 18376|
|  5  |     >24h | 20253  |     >24h | 20844|
|  4  |     >24h | 30456  |     >24h | 28124|
|  3  |     >24h | 31600  |     >24h | 27818|
|  2  |     >24h | 49139  |     >24h | 44513|
|  1  |     >24h | 69418  |     >24h | 61275|

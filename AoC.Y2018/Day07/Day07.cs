using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day07 : BaseDay
    {
        private int workerCount;
        private bool subtractMinute;

        public Day07() : base(2018, 7)
        {
            workerCount = 6;
            subtractMinute = false;

        }
        public Day07(IEnumerable<string> inputLines) : base(2018, 7, inputLines)
        {
            workerCount = 2;
            subtractMinute = true;
        }

        protected override IConvertible PartOne()
        {
            var steps = GetSteps(inputLines);

            // update steps from ready to done
            var sortedSteps = GetSortedSteps(steps, true);
            return sortedSteps;
        }

        protected override IConvertible PartTwo()
        {
            var steps = GetSteps(inputLines);
            var workers = GetWorkers(workerCount);
            var timeSpent = CalculateTime(steps, workers, subtractMinute);

            return timeSpent;
        }

        private static List<Step> GetSteps(IEnumerable<string> inputLines)
        {
            var steps = new List<Step>();
            var prereqList = new List<(char step, char prerequisite)>();

            foreach (var line in inputLines)
            {
                var words = line.Split(' ');
                prereqList.Add((char.Parse(words[7]), char.Parse(words[1])));
            }

            var allSteps = prereqList.Select(s => s.step).ToList();
            allSteps.AddRange(prereqList.Select(s => s.prerequisite));
            var distinctSteps = allSteps.Distinct();

            steps.AddRange(distinctSteps.Select(s => new Step(s)));

            foreach (var step in steps)
            {
                var prereqs = prereqList.Where(p => p.step == step.Name);

                foreach (var prereq in prereqs)
                {
                    step.Prerequisites.Add(steps.Single(s => s.Name == prereq.prerequisite));
                    step.Status = StepStatus.NotReady;
                }
            }

            return steps;
        }

        private static string GetSortedSteps(List<Step> steps, bool setReadyToDone)
        {
            var stepOrder = string.Empty;

            foreach (var step in steps)
            {
                if (step.Status == StepStatus.Ready)
                {
                    step.Status = StepStatus.Done;
                }
            }

            while (steps.Any())
            {
                var doneSteps = steps.Where(s => s.Status == StepStatus.Done).OrderBy(s => s.Name);

                foreach (var doneStep in doneSteps)
                {
                    stepOrder += doneStep.Name;
                    var updated = UpdateStepList(steps, doneStep, setReadyToDone);
                    steps.Remove(doneStep);

                    if (updated)
                    {
                        break;
                    }
                }
            }

            return stepOrder;
        }

        private static bool UpdateStepList(List<Step> steps, Step doneStep, bool setReadyToDone)
        {
            var stepsToUpdate = steps.Where(s => s.Prerequisites.Contains(doneStep));
            var stepsUpdated = false;

            foreach (var update in stepsToUpdate)
            {
                update.Prerequisites.Remove(doneStep);

                if (!update.Prerequisites.Any())
                {
                    update.Status = setReadyToDone ? StepStatus.Done : StepStatus.Ready;
                    stepsUpdated = true;
                }
            }

            return stepsUpdated;
        }

        private static int CalculateTime(List<Step> steps, List<Worker> workers, bool subtractMinute)
        {
            var currentSecond = 0;

            while (steps.Any())
            {
                var readySteps = steps.Where(s => s.Status == StepStatus.Ready);

                // start ready steps, assign available workers
                foreach (var readyStep in readySteps)
                {
                    var worker = workers.FirstOrDefault(w => w.Available);

                    if (worker != null)
                    {
                        readyStep.AssignedWorker = worker;
                        worker.Available = false;
                        readyStep.Status = StepStatus.InProgress;

                        if (subtractMinute)
                        {
                            readyStep.TimeLeft -= 60;
                        }
                    }
                }

                foreach (var inProgressStep in steps.Where(s => s.Status == StepStatus.InProgress))
                {
                    inProgressStep.TimeLeft--;

                    if (inProgressStep.TimeLeft <= 0)
                    {
                        inProgressStep.Status = StepStatus.Done;
                    }
                }

                foreach (var doneStep in steps.Where(s => s.Status == StepStatus.Done))
                {
                    if (doneStep.AssignedWorker != null)
                    {
                        var worker = doneStep.AssignedWorker;
                        worker.Available = true;
                    }

                    UpdateStepList(steps, doneStep, false);
                }

                steps.RemoveAll(s => s.Status == StepStatus.Done);
                currentSecond++;
            }

            return currentSecond;
        }

        private static List<Worker> GetWorkers(int count)
        {
            var workerList = new List<Worker>();

            for (int i = 0; i < count; i++)
            {
                workerList.Add(new Worker(i + 1));
            }

            return workerList;
        }
    }
}
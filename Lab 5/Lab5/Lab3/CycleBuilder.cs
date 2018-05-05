using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab3
{
    public static class CycleBuilder
    {
        public class EngagedElement
        {
            public Point Position;
            public double Value;
            public EngagedElement(double value, int i, int j)
            {
                Value = value;
                Position = new Point(i, j);
            }
        }
        public class CycleElement
        {
            public Point Position;
            private int _sign;
            public CycleElement(int i, int j, int sign)
            {
                Position = new Point(i, j);
                _sign = sign;
            }
            public int GetSign()
            {
                return _sign;
            }
        }

        private static List<EngagedElement> _plan;
        private static CycleElement _cycle;
        public static bool Build(List<CycleElement> cycle, List<EngagedElement> plan)
        {
            _plan = plan;
            _cycle = cycle.First();
            while (true)
            {
                // using try, catch to leave recursion
                try
                {
                    cycle.Clear();
                    cycle.Add(_cycle);
                    if (CycleBuilder.BuildCycle(cycle))
                        return true;
                }
                catch (Exception)
                {
                }
            }
        }
        public static bool BuildCycle(List<CycleElement> cycle)
        {
            CycleElement head = cycle.First();//destination
            CycleElement currentElement = cycle.Last();

            // якщо є початок і цикл вміщує більше ніж 2 елемента, то повертаємося
            var engaged = _plan.FindAll(element => element.Position.X < currentElement.Position.X && element.Position.Y == currentElement.Position.Y || element.Position.X == currentElement.Position.X && element.Position.Y > currentElement.Position.Y || element.Position.X > currentElement.Position.X && element.Position.Y == currentElement.Position.Y || element.Position.X == currentElement.Position.X && element.Position.Y < currentElement.Position.Y).ToList();
            if (engaged.Any(element => element.Position.X == cycle.First().Position.X && element.Position.Y == cycle.First().Position.Y) && cycle.Count > 2)
            {
                return true;
            }

            // шукаємо елементи зверху
            engaged = _plan.FindAll(element => element.Position.X < currentElement.Position.X && element.Position.Y == currentElement.Position.Y).ToList();
            if (engaged.Count > 0)
            {
                if (!CheckForInterference(cycle, engaged))
                {
                    var elem = engaged.Find(e => e.Position.X == engaged.Min(k => k.Position.X));
                    engaged.Clear();
                    engaged.Add(elem);
                    if (CheckCycleElement(engaged.ElementAt(0), head) && !cycle.ElementAt(cycle.Count() - 2).Equals(head)) return true;//якщо я знайшов початок і він не передує мені
                    if (!IsEqual(engaged.ElementAt(0), (head)))//на голову рекурсії не запускаєм
                    {
                        cycle.Add(new CycleElement(engaged.ElementAt(0).Position.X, engaged.ElementAt(0).Position.Y, cycle.Last().GetSign() * (-1)));
                        // рекурсивно до цього елементу
                        if (BuildCycle(cycle)) return true;
                    }
                }
            }


            // шукаємо елементи з правого боку
            engaged = _plan.FindAll(element => element.Position.X == currentElement.Position.X && element.Position.Y > currentElement.Position.Y).ToList();
            if (engaged.Count > 0)
            {
                if (!CheckForInterference(cycle, engaged))
                {
                    var elem = engaged.Find(e => e.Position.Y == engaged.Max(k => k.Position.Y));
                    engaged.Clear();
                    engaged.Add(elem);
                    if (CheckCycleElement(engaged.ElementAt(0), head) && !cycle.ElementAt(cycle.Count() - 2).Equals(head)) return true;//якщо я знайшов початок і він не передує мені
                    if (!IsEqual(engaged.ElementAt(0), (head)))
                    {
                        cycle.Add(new CycleElement(engaged.ElementAt(0).Position.X, engaged.ElementAt(0).Position.Y, cycle.Last().GetSign() * (-1)));
                        // рекурсивно до цього елементу
                        if (BuildCycle(cycle)) return true;
                    }
                }
            }


            // шукаємо елементи знизу
            engaged = _plan.FindAll(element => element.Position.X > currentElement.Position.X && element.Position.Y == currentElement.Position.Y).ToList();
            if (engaged.Count > 0)
            {
                if (!CheckForInterference(cycle, engaged))
                {
                    var elem = engaged.Find(e => e.Position.X == engaged.Max(k => k.Position.X));
                    engaged.Clear();
                    engaged.Add(elem);
                    if (CheckCycleElement(engaged.ElementAt(0), head) && !cycle.ElementAt(cycle.Count() - 2).Equals(head)) return true;//якщо я знайшов початок і він не передує мені
                    if (!IsEqual(engaged.ElementAt(0), (head)))
                    {
                        cycle.Add(new CycleElement(engaged.ElementAt(0).Position.X, engaged.ElementAt(0).Position.Y, cycle.Last().GetSign() * (-1)));
                        // рекурсивно до цього елементу
                        if (BuildCycle(cycle)) return true;
                    }
                }
            }

            // шукаємо елементи з лівого боку
            engaged = _plan.FindAll(element => element.Position.X == currentElement.Position.X && element.Position.Y < currentElement.Position.Y).ToList();
            if (engaged.Count > 0)
            {
                if (!CheckForInterference(cycle, engaged))
                {
                    var elem = engaged.Find(e => e.Position.Y == engaged.Min(k => k.Position.Y));
                    engaged.Clear();
                    engaged.Add(elem);
                    if (CheckCycleElement(engaged.ElementAt(0), head) && !cycle.ElementAt(cycle.Count() - 2).Equals(head)) return true;//якщо я знайшов початок і він не передує мені
                    if (!IsEqual(engaged.ElementAt(0), (head)))
                    {
                        cycle.Add(new CycleElement(engaged.ElementAt(0).Position.X, engaged.ElementAt(0).Position.Y, cycle.Last().GetSign() * (-1)));
                        // рекурсивно до цього елементу
                        if (BuildCycle(cycle)) return true;
                    }

                }
            }

            // видаляємо елемент і повертаємося
            _plan.Remove(_plan.Find(element => element.Position.X == currentElement.Position.X && element.Position.Y == currentElement.Position.Y));
            throw new Exception();
        }

        private static bool CheckCycleElement(EngagedElement prediction, CycleElement head)
        {
            return prediction.Position.X == head.Position.X && prediction.Position.Y == head.Position.Y;
        }
        private static bool CheckForInterference(List<CycleElement> cycle, List<EngagedElement> engaged)
        {
            if (engaged.Count == 1 && engaged.First().Equals(cycle.First())) return false;
            foreach (CycleElement cycleElem in cycle)
            {
                foreach (EngagedElement el in engaged)
                {
                    if (CheckCycleElement(el, cycleElem))//два рази в гості не ходять) не повертаємся
                    {
                        if (cycleElem.Equals(cycle.First()))
                        {
                            if (engaged.Count > 1) return true;
                            else return false;
                        }
                        else return true;
                    }
                }
            }
            return false;
        }
        private static bool IsEqual(EngagedElement prediction, CycleElement head)
        {
            return prediction.Position.X == head.Position.X && prediction.Position.Y == head.Position.Y;
        }
    }
}
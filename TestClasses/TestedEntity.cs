using System.Diagnostics;
using System.Text;

namespace TestClasses
{
    public class TestedEntity
    {
        public string Email => "annatinskaya@mail.ru";

        public TestedEntity Instance => this;

        public List<int> MultAll(List<int> nums, int value) =>
            nums.Select(n => n * value).ToList();

        public string ListToString(List<int> nums)
        {
            StringBuilder sb = new();

            foreach (int num in nums)
            {
                sb.Append($"{num}; ");
            }

            return sb.ToString();
        }

        public int Minus(int num) => -num;

        public bool IsBelowZiro(int num) => num < 0;

        public object? GetZeroResult(int num) => num switch
        {
            < 0 => new BelowZiroResult { Value = num },
            > 0 => new AboveZeroResult { Value = num },
            _ => null
        };

        public int Devide(int num, int value)
        {
            if (value == 0)
                throw new ArithmeticException("Деление на ноль!");

            return num / value;
        }

        public class BelowZiroResult
        {
            public int Value { get; set; }
        }

        public class AboveZeroResult
        {
            public int Value { get; set; }
        }
    }
}

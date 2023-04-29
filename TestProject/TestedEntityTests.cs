using TestClasses;

namespace TestProject
{
    [TestClass]
    public class TestedEntityTests
    {
        private TestedEntity _entity = default!;

        [TestInitialize] 
        public void Initialize() 
        {
            _entity = new TestedEntity();
        }

        [TestMethod]
        public void AllTest()
        {
            var nums = new List<int>()
            {
                4, 2, 9, 82, 81, 7, 9
            };
            int mult = 2;

            var expected = _entity.MultAll(nums, mult);
            var actual = nums.Select(n => n * mult).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var nums = new List<int>()
            {
                4, 2, 9, 82, 81, 7, 9
            };

            var substring = "4; 2; 9;";
            var actual = _entity.ListToString(nums);

            StringAssert.Contains(actual, substring);
        }

        [TestMethod]
        public void DoesNotContainsTest()
        {
            var nums = new List<int>()
            {
                4, 2, 9, 82, 81, 7, 9
            };

            var substring = "4; 5; 9;";
            var actual = _entity.ListToString(nums);

            Assert.ThrowsException<AssertFailedException>(() => StringAssert.Contains(actual, substring));
        }

        [TestMethod]
        public void DoesNotMatchTest()
        {
            var nums = new List<int>()
            {
                4, 2, 9, 82, 81, 7, 9
            };
            //простое регулярное выражение на проверку email
            var regex = new System.Text.RegularExpressions.Regex(
                "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");

            var actual = _entity.ListToString(nums);

            StringAssert.DoesNotMatch(actual,regex );
        }

        [TestMethod]
        public void MathcesTest()
        {
            var regex = new System.Text.RegularExpressions.Regex(
                "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");

            var email = _entity.Email;

            StringAssert.Matches(email, regex);
        }

        [TestMethod]
        public void NotEqualTest()
        {
            var num = 69;

            var actual = _entity.Minus(num);
            var expected = -num;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualTest()
        {
            var num = 69;

            var actual = _entity.Minus(num);
            var expected = num;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TrueTest()
        {
            var num = -69;

            var actual = _entity.IsBelowZiro(num);
            
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void FalseTest()
        {
            var num = 69;

            var actual = _entity.IsBelowZiro(num);
            
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            var num = 69;

            var actual = _entity.GetZeroResult(num);

            Assert.IsInstanceOfType(actual, typeof(TestedEntity.AboveZeroResult));
        }

        [TestMethod]
        public void IsNotInstanceOfTypeTest()
        {
            var num = 69;

            var actual = _entity.GetZeroResult(num);

            Assert.IsNotInstanceOfType(actual, typeof(TestedEntity.BelowZiroResult));
        }

        [TestMethod]
        public void IsNullTest()
        {
            var num = 0;

            var actual = _entity.GetZeroResult(num);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void IsNotNullTest()
        {
            var num = 69;

            var actual = _entity.GetZeroResult(num);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void SameTest()
        {
            var expected = _entity;
            var actual = _entity.Instance;

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void NotSameTest()
        {
            var entity = new TestedEntity();

            var expected = _entity;
            var actual = entity.Instance;

            Assert.AreNotSame(expected, actual);
        }

        [TestMethod]
        public void ThrowsExceptionTest()
        {
            var num = 13;

            Assert.ThrowsException<ArithmeticException>(() => _entity.Devide(num, 0));
        }
    }
}
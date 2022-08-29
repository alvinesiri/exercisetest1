using retailstore.service.Models;
using retailstore.service.Services;

namespace retailstore.test
{
    public class Exercise1Test
    {
        readonly List<Employee>? testemployees = new()
        {
            new Employee()
            {
                PhoneNumber = "07030000000"
            }
        };
        readonly List<Affiliate>? testaffiliates = new ()
        {
            new Affiliate()
            {
                PhoneNumber = "07040000000"
            }
        };
        readonly List<Customer>? testcustomers = new()
        {
            new Customer()
            {
                PhoneNumber = "07050000000",
                DateJoined = DateTime.Now.AddYears(-3),
            }
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNetPayableAmount()
        {
            Bill bill = new()
            {
                Amount = 990M,
                IsGroceries = false,
                PhoneNumber = "07050000000"
            };
            decimal ExpectedPayableAmount = 945M;

            PaymentService paymentService = new(testaffiliates, testcustomers, testemployees);
            decimal payableAmount = paymentService.GetNetPayableAmount(bill);
            Assert.AreEqual(payableAmount, ExpectedPayableAmount);
        }
    }
}
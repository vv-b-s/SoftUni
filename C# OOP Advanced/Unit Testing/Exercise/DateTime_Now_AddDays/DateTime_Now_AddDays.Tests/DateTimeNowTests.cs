using Moq;
using NUnit.Framework;
using System;

namespace DateTime_Now_AddDays.Tests
{
    [TestFixture]
    public class DateTimeNowTests
    {
        private DateTime date;

        [SetUp]
        public void Init()
        {
            this.date = DateTime.Now;
        }

        [Test]
        public void DateTimeNowAddDaysInMiddleOfMonthIncrementsProperly()
        {
            MakeDayTo(15);

            var expectedDate = new FakeDateTime(this.date);
            expectedDate.Day++;

            Assert.That(expectedDate.CompareTo(this.date.AddDays(1)), Is.EqualTo(0), "The DateTime does not increment days correctly!");
        }

        [Test]
        public void DateTimeNowAddDaysChangesMonthWhenAddingDayAtTheEnd()
        {
            MoveToEndOfMonth();

            var expectedDate = new FakeDateTime(this.date) { Day = 1 };
            expectedDate.Month = expectedDate.Month == 12 ? 1 : expectedDate.Month + 1;
            expectedDate.Year = expectedDate.Month == 1 ? expectedDate.Year + 1 : expectedDate.Year;

            Assert.That(expectedDate.CompareTo(this.date.AddDays(1)), Is.EqualTo(0), "DateTime.Now does not increment correctly at the end of the month");
        }

        [Test]
        public void DateTimeNowAddDaysNegativeWorks()
        {
            MakeDayTo(16);

            var expectedDateTime = new FakeDateTime(this.date);
            expectedDateTime.Day -= 1;

            Assert.That(expectedDateTime.CompareTo(this.date.AddDays(-1)), Is.EqualTo(0), "Dates cannot be reverted.");
        }

        [Test]
        public void DateTimeNowAddDaysNegativeWorksBetweenTwoMonths()
        {
            MoveToEndOfMonth();
            var expectedDay = new FakeDateTime(this.date);

            this.date = this.date.AddDays(1);
            this.date = this.date.AddDays(-1);

            Assert.That(expectedDay.CompareTo(this.date), Is.EqualTo(0), "Date does not decrement properly on end of month!");
        }

        [Test]
        public void DateTimeNowAddsDaysToLeapYear()
        {
            var expectedDay = 29;

            MoveToLeapYear();

            //Move to febuary as it is probably going to be at January
            this.date = this.date.AddMonths(1);

            //Move to 29-th of febuary
            MoveToEndOfMonth(this.date);

            Assert.That(expectedDay, Is.EqualTo(this.date.Day), "DateTime does not increment correctly on leap year!");
        }

        [Test]
        public void DateTimeNowAddsDaysToNonLeapYear()
        {
            MoveToLeapYear();

            //Move to a non-leap year which is surely the year before;
            this.date = this.date.AddYears(-1);

            //Move to febuary
            this.date = this.date.AddMonths(1);

            MoveToEndOfMonth(this.date);

            var expectedDate = 28;

            Assert.That(expectedDate, Is.EqualTo(this.date.Day), "DateTime does not increment correctly on non-leap year");
        }

        [Test]
        public void DateTimeAddRemoveDayToMaxMinValueResultsInException()
        {
            MaxOutDate();

            Assert.That(() => this.date.AddDays(1), Throws.Exception,
                "DateTime.Now.AddDays does not throw exception when overflown");

            this.date = DateTime.Now;

            MinOutDate();

            Assert.That(() => this.date.AddDays(-1), Throws.Exception,
            "DateTime.Now.AddDays does not throw exception when underflown");
        }

        private void MakeDayTo(int day)
        {
            while (this.date.Day != day)
                this.date = this.date.AddDays(1);
        }

        private void MoveToEndOfMonth() => MoveToEndOfMonth(DateTime.Now);

        private void MoveToEndOfMonth(DateTime startDate)
        {
            var tempDate = startDate;

            for (int i = tempDate.Month; i < this.date.Month + 1; tempDate = tempDate.AddDays(1), i = tempDate.Month)
                this.date = tempDate;
        }

        private void MoveToLeapYear()
        {
            var tempDate = DateTime.Now;
            for (int i = this.date.Year; !DateTime.IsLeapYear(i); tempDate = tempDate.AddMonths(1), i = tempDate.Year) ;

            this.date = tempDate;
        }

        private void MaxOutDate()
        {
            var maxDate = DateTime.MaxValue;

            //Max out years
            for (int i = this.date.Year; i < maxDate.Year; this.date = this.date.AddYears(1), i = this.date.Year) ;

            //Max out months
            for (int i = this.date.Month; i < maxDate.Month; this.date = this.date.AddMonths(1), i = this.date.Month) ;

            //Max out days
            for (int i = this.date.Day; i < maxDate.Day; this.date = this.date.AddDays(1), i = this.date.Day) ;
        }

        private void MinOutDate()
        {
            var minDate = DateTime.MinValue;

            //Min out years
            for (int i = this.date.Year; i > minDate.Year; this.date = this.date.AddYears(-1), i = this.date.Year) ;

            //Min out months
            for (int i = this.date.Month; i > minDate.Month; this.date = this.date.AddMonths(-1), i = this.date.Month) ;

            //Min out days
            for (int i = this.date.Day; i > minDate.Day; this.date = this.date.AddDays(-1), i = this.date.Day) ;
        }
    }
}

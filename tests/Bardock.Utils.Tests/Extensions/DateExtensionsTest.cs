﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bardock.Utils.Extensions;
using System.Globalization;

namespace Bardock.Utils.Tests.Extensions
{
    public class DateExtensionsTest
    {
        private static DateTime DATE1 = new DateTime(2013, 1, 5, 12, 45, 6, 123);

        [Fact]
        public void NormalizedFormat()
        {
            var r = DATE1.NormalizedFormat();
            Assert.Equal("2013-01-05 12:45:06", r);
        }

        [Fact]
        public void NormalizedDateFormat()
        {
            var r = DATE1.NormalizedDateFormat();
            Assert.Equal("2013-01-05", r);
        }

        [Fact]
        public void CompactFormat()
        {
            var r = DATE1.CompactFormat();
            Assert.Equal("20130105124506", r);
        }

        [Fact]
        public void CompactDateFormat()
        {
            var r = DATE1.CompactDateFormat();
            Assert.Equal("20130105", r);
        }

        [Fact]
        public void ToIsoFormat_Unespecified()
        {
            var r = DATE1.Clone(kind: DateTimeKind.Unspecified).ToIsoFormat();
            Assert.Equal("2013-01-05T12:45:06.1230000", r);
        }

        [Fact]
        public void ToIsoFormat_Utc()
        {
            var r = DATE1.Clone(kind: DateTimeKind.Utc).ToIsoFormat();
            Assert.Equal("2013-01-05T12:45:06.1230000Z", r);
        }

        [Fact]
        public void ToIsoFormat_Local()
        {
            var date = DATE1.Clone(kind: DateTimeKind.Local);
            var r = date.ToIsoFormat();

            var offset = TimeZoneInfo.Local.GetUtcOffset(date);
            Assert.Equal(string.Format("2013-01-05T12:45:06.1230000{0:+00;-00}:{1:00}", offset.Hours, offset.Minutes), r);
        }

        [Fact]
        public void ToDayStart()
        {
            var r = DATE1.ToDayStart();
            Assert.Equal(new DateTime(2013, 01, 05), r);
        }

        [Fact]
        public void ToDayEnd()
        {
            var r = DATE1.ToDayEnd();
            Assert.Equal(new DateTime(2013, 01, 05, 23, 59, 59, 999), r);
        }

        [Fact]
        public void ToMonthStart()
        {
            var r = DATE1.ToMonthStart();
            Assert.Equal(new DateTime(2013, 01, 01), r);
        }

        [Fact]
        public void ToMonthEnd()
        {
            var r = DATE1.ToMonthEnd();
            Assert.Equal(new DateTime(2013, 01, 31, 23, 59, 59, 999), r);
        }

        [Fact]
        public void ToMonthYearString_ValidDate_NameOfMothAnYear()
        {
            // Setup
            var expected = DATE1.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern);

            // Exercise
            var actual = DATE1.ToMonthYearString();

            // Verify
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToMonthString_ValidDate_NameOfMonth()
        {
            // Setup
            var expected = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DATE1.Month);

            // Exercise
            var actual = DATE1.ToMonthString();

            // Verify
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToShortMonthString_ValidDate_ShortNameOfMonth()
        {
            // Setup
            var expected = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DATE1.Month);
            
            // Exercise
            var actual = DATE1.ToShortMonthString();

            // Verify
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToDayMonthString_ValidDate_NumberDayNameOfMonth()
        {
            // Setup
            var expected = DATE1.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthDayPattern);

            // Exercise 
            var actual = DATE1.ToDayMonthString();

            // Verify
            Assert.Equal(expected, actual);
        }
        
    }
}

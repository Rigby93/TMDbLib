using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMDbLib.Objects.General;

namespace TMDbLibTests
{
    [TestClass]
    public class TMDbDateTest
    {
        [TestMethod]
        public void TMDbDateSimple()
        {
            TMDbDate tmp = new TMDbDate("1990");

            Assert.AreEqual(1990, tmp.AsDateTime.Year);
            Assert.AreEqual(1, tmp.AsDateTime.Month);
            Assert.AreEqual(1, tmp.AsDateTime.Day);
            Assert.IsTrue(tmp.IsOnlyYear);

            tmp = new TMDbDate("1990-02-02");

            Assert.AreEqual(1990, tmp.AsDateTime.Year);
            Assert.AreEqual(2, tmp.AsDateTime.Month);
            Assert.AreEqual(2, tmp.AsDateTime.Day);
            Assert.IsFalse(tmp.IsOnlyYear);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TMDbDateBadFormat()
        {
            TMDbDate tmp = new TMDbDate("1990-01-01 10:00:00");

            Assert.Fail();
        }

        [TestMethod]
        public void TMDbDateNullComparisons()
        {
            TMDbDate nullTmdb = null;
            TMDbDate dateTmdb = new TMDbDate("1990");
            DateTime tmpDate = new DateTime(1990, 1, 1);

            Assert.IsFalse(dateTmdb.Equals(nullTmdb));

            Assert.IsFalse(nullTmdb < dateTmdb);
            Assert.IsFalse(dateTmdb < nullTmdb);
            Assert.IsFalse(nullTmdb < tmpDate);
            Assert.IsFalse(tmpDate < nullTmdb);

            Assert.IsFalse(nullTmdb > dateTmdb);
            Assert.IsFalse(dateTmdb < nullTmdb);
            Assert.IsFalse(nullTmdb > tmpDate);
            Assert.IsFalse(tmpDate > nullTmdb);

            Assert.IsFalse(nullTmdb == dateTmdb);
            Assert.IsFalse(dateTmdb == nullTmdb);
            Assert.IsFalse(nullTmdb == tmpDate);
            Assert.IsFalse(tmpDate == nullTmdb);

            Assert.IsTrue(nullTmdb != dateTmdb);
            Assert.IsTrue(dateTmdb != nullTmdb);
            Assert.IsTrue(nullTmdb != tmpDate);
            Assert.IsTrue(tmpDate != nullTmdb);

            Assert.IsFalse(nullTmdb >= dateTmdb);
            Assert.IsFalse(dateTmdb >= nullTmdb);
            Assert.IsFalse(nullTmdb >= tmpDate);
            Assert.IsFalse(tmpDate >= nullTmdb);

            Assert.IsFalse(nullTmdb <= dateTmdb);
            Assert.IsFalse(dateTmdb <= nullTmdb);
            Assert.IsFalse(nullTmdb <= tmpDate);
            Assert.IsFalse(tmpDate <= nullTmdb);
        }

        [TestMethod]
        public void TMDbDateComparisons()
        {
            Assert.IsTrue(new TMDbDate("1990").Equals(new TMDbDate("1990-02-02")));
            Assert.IsTrue(new TMDbDate("1990-02-02").Equals(new TMDbDate("1990-02-02")));
            Assert.IsFalse(new TMDbDate("1990-02-03").Equals(new TMDbDate("1990-02-02")));
            Assert.IsFalse(new TMDbDate("1991").Equals(new TMDbDate("1990-02-02")));

            Assert.IsTrue(new TMDbDate("1991") < new TMDbDate("1992"));
            Assert.IsFalse(new TMDbDate("1991") < new TMDbDate("1991-01-01"));
            Assert.IsFalse(new TMDbDate("1991") < new TMDbDate("1990"));
            Assert.IsTrue(new TMDbDate("1991-02-05") < new TMDbDate("1991-02-06"));
            Assert.IsFalse(new TMDbDate("1991-02-05") < new TMDbDate("1991-02-05"));

            Assert.IsTrue(new TMDbDate("1992") > new TMDbDate("1991"));
            Assert.IsFalse(new TMDbDate("1991-01-01") > new TMDbDate("1991"));
            Assert.IsTrue(new TMDbDate("1991") > new TMDbDate("1990"));
            Assert.IsTrue(new TMDbDate("1991-02-06") > new TMDbDate("1991-02-05"));
            Assert.IsFalse(new TMDbDate("1991-02-05") > new TMDbDate("1991-02-05"));

            Assert.IsTrue(new TMDbDate("1991") <= new TMDbDate("1992"));
            Assert.IsTrue(new TMDbDate("1991") <= new TMDbDate("1991-01-01"));
            Assert.IsFalse(new TMDbDate("1991") <= new TMDbDate("1990"));
            Assert.IsTrue(new TMDbDate("1991-02-05") <= new TMDbDate("1991-02-06"));
            Assert.IsTrue(new TMDbDate("1991-02-05") <= new TMDbDate("1991-02-05"));

            Assert.IsTrue(new TMDbDate("1992") >= new TMDbDate("1991"));
            Assert.IsTrue(new TMDbDate("1991-01-01") >= new TMDbDate("1991"));
            Assert.IsTrue(new TMDbDate("1991") >= new TMDbDate("1990"));
            Assert.IsTrue(new TMDbDate("1991-02-06") >= new TMDbDate("1991-02-05"));
            Assert.IsFalse(new TMDbDate("1991-02-04") >= new TMDbDate("1991-02-05"));

            Assert.IsTrue(new TMDbDate("1992") == new TMDbDate("1992-05-05"));
            Assert.IsTrue(new TMDbDate("1993") == new TMDbDate("1993"));
            Assert.IsFalse(new TMDbDate("1993") == new TMDbDate("1992"));
            Assert.IsTrue(new TMDbDate("1993-05-04") == new TMDbDate("1993-05-04"));
            Assert.IsFalse(new TMDbDate("1993-05-04") == new TMDbDate("1993-05-05"));

            Assert.IsFalse(new TMDbDate("1992") != new TMDbDate("1992-05-05"));
            Assert.IsFalse(new TMDbDate("1993") != new TMDbDate("1993"));
            Assert.IsTrue(new TMDbDate("1993") != new TMDbDate("1992"));
            Assert.IsFalse(new TMDbDate("1993-05-04") != new TMDbDate("1993-05-04"));
            Assert.IsTrue(new TMDbDate("1993-05-04") != new TMDbDate("1993-05-05"));
        }

        [TestMethod]
        public void TMDbDateDateTimeComparisons()
        {
            Assert.IsTrue(new TMDbDate("1990").Equals(new DateTime(1990, 1, 1)));
            Assert.IsTrue(new TMDbDate("1990").Equals(new DateTime(1990, 10, 10)));

            Assert.IsTrue(new TMDbDate("1990").Equals(new DateTime(1990, 2, 2)));
            Assert.IsTrue(new TMDbDate("1990-02-02").Equals(new DateTime(1990, 2, 2)));
            Assert.IsFalse(new TMDbDate("1990-02-03").Equals(new DateTime(1990, 2, 2)));
            Assert.IsFalse(new TMDbDate("1991").Equals(new DateTime(1990, 2, 2)));

            Assert.IsTrue(new TMDbDate("1991") < new DateTime(1992, 2, 2));
            Assert.IsFalse(new TMDbDate("1991") < new DateTime(1991, 1, 1));
            Assert.IsFalse(new TMDbDate("1991") < new DateTime(1990, 2, 2));
            Assert.IsTrue(new TMDbDate("1991-02-05") < new DateTime(1991, 2, 6));
            Assert.IsFalse(new TMDbDate("1991-02-05") < new DateTime(1990, 2, 5));

            Assert.IsTrue(new TMDbDate("1992") > new DateTime(1991, 2, 2));
            Assert.IsFalse(new TMDbDate("1991-01-01") > new DateTime(1991, 2, 2));
            Assert.IsTrue(new TMDbDate("1991") > new DateTime(1990, 2, 2));
            Assert.IsTrue(new TMDbDate("1991-02-06") > new DateTime(1991, 2, 5));
            Assert.IsFalse(new TMDbDate("1991-02-05") > new DateTime(1991, 2, 5));

            Assert.IsTrue(new TMDbDate("1991") <= new DateTime(1992, 2, 2));
            Assert.IsTrue(new TMDbDate("1991") <= new DateTime(1991, 1, 1));
            Assert.IsFalse(new TMDbDate("1991") <= new DateTime(1990, 2, 2));
            Assert.IsTrue(new TMDbDate("1991-02-05") <= new DateTime(1991, 2, 6));
            Assert.IsTrue(new TMDbDate("1991-02-05") <= new DateTime(1991, 2, 5));

            Assert.IsTrue(new TMDbDate("1992") >= new DateTime(1991, 2, 2));
            Assert.IsTrue(new TMDbDate("1991-02-02") >= new DateTime(1991, 2, 2));
            Assert.IsTrue(new TMDbDate("1991") >= new DateTime(1990, 2, 2));
            Assert.IsTrue(new TMDbDate("1991-02-06") >= new DateTime(1991, 2, 5));
            Assert.IsFalse(new TMDbDate("1991-02-04") >= new DateTime(1991, 2, 5));

            Assert.IsTrue(new TMDbDate("1992") == new DateTime(1992, 5, 5));
            Assert.IsTrue(new TMDbDate("1993") == new DateTime(1993, 2, 2));
            Assert.IsFalse(new TMDbDate("1993") == new DateTime(1992, 2, 2));
            Assert.IsTrue(new TMDbDate("1993-05-04") == new DateTime(1993, 5, 4));
            Assert.IsFalse(new TMDbDate("1993-05-04") == new DateTime(1993, 5, 5));

            Assert.IsFalse(new TMDbDate("1992") != new DateTime(1992, 5, 5));
            Assert.IsFalse(new TMDbDate("1993") != new DateTime(1993, 2, 2));
            Assert.IsTrue(new TMDbDate("1993") != new DateTime(1992, 2, 2));
            Assert.IsFalse(new TMDbDate("1993-05-04") != new DateTime(1993, 5, 4));
            Assert.IsTrue(new TMDbDate("1993-05-04") != new DateTime(1993, 5, 5));
        }

        [TestMethod]
        public void TMDbDateDateTimeComparisons2()
        {
            Assert.IsTrue(new DateTime(1992, 2, 2) > new TMDbDate("1991"));
            Assert.IsFalse(new DateTime(1991, 1, 1) > new TMDbDate("1991"));
            Assert.IsFalse(new DateTime(1990, 2, 2) > new TMDbDate("1991"));
            Assert.IsTrue(new DateTime(1991, 2, 6) > new TMDbDate("1991-02-05"));
            Assert.IsFalse(new DateTime(1990, 2, 5) > new TMDbDate("1991-02-05"));

            Assert.IsTrue(new DateTime(1991, 2, 2) < new TMDbDate("1992"));
            Assert.IsFalse(new DateTime(1991, 2, 2) < new TMDbDate("1991-01-01"));
            Assert.IsTrue(new DateTime(1990, 2, 2) < new TMDbDate("1991"));
            Assert.IsTrue(new DateTime(1991, 2, 5) < new TMDbDate("1991-02-06"));
            Assert.IsFalse(new DateTime(1991, 2, 5) < new TMDbDate("1991-02-05"));

            Assert.IsTrue(new DateTime(1992, 2, 2) >= new TMDbDate("1991"));
            Assert.IsTrue(new DateTime(1991, 1, 1) >= new TMDbDate("1991"));
            Assert.IsFalse(new DateTime(1990, 2, 2) >= new TMDbDate("1991"));
            Assert.IsTrue(new DateTime(1991, 2, 6) >= new TMDbDate("1991-02-05"));
            Assert.IsTrue(new DateTime(1991, 2, 5) >= new TMDbDate("1991-02-05"));

            Assert.IsTrue(new DateTime(1991, 2, 2) <= new TMDbDate("1992"));
            Assert.IsTrue(new DateTime(1991, 2, 2) <= new TMDbDate("1991-02-02"));
            Assert.IsTrue(new DateTime(1990, 2, 2) <= new TMDbDate("1991"));
            Assert.IsTrue(new DateTime(1991, 2, 5) <= new TMDbDate("1991-02-06"));
            Assert.IsFalse(new DateTime(1991, 2, 5) <= new TMDbDate("1991-02-04"));

            Assert.IsTrue(new DateTime(1992, 5, 5) == new TMDbDate("1992"));
            Assert.IsTrue(new DateTime(1993, 2, 2) == new TMDbDate("1993"));
            Assert.IsFalse(new DateTime(1992, 2, 2) == new TMDbDate("1993"));
            Assert.IsTrue(new DateTime(1993, 5, 4) == new TMDbDate("1993-05-04"));
            Assert.IsFalse(new DateTime(1993, 5, 5) == new TMDbDate("1993-05-04"));

            Assert.IsFalse(new DateTime(1992, 5, 5) != new TMDbDate("1992"));
            Assert.IsFalse(new DateTime(1993, 2, 2) != new TMDbDate("1993"));
            Assert.IsTrue(new DateTime(1992, 2, 2) != new TMDbDate("1993"));
            Assert.IsFalse(new DateTime(1993, 5, 4) != new TMDbDate("1993-05-04"));
            Assert.IsTrue(new DateTime(1993, 5, 5) != new TMDbDate("1993-05-04"));
        }

        [TestMethod]
        public void TMDbDateGetHashCode()
        {
            TMDbDate dateTmdb1 = new TMDbDate("1990");
            TMDbDate dateTmdb2 = new TMDbDate("1991");

            Assert.AreEqual(dateTmdb1.GetHashCode(), dateTmdb1.GetHashCode());
            Assert.AreNotEqual(dateTmdb1.GetHashCode(), dateTmdb2.GetHashCode());
        }

        [TestMethod]
        public void TMDbDateToString()
        {
            TMDbDate dateTmdb1 = new TMDbDate("1990");
            TMDbDate dateTmdb2 = new TMDbDate("1991-05-05");

            Assert.AreEqual("1990", dateTmdb1.ToString());
            Assert.AreEqual("1991-05-05", dateTmdb2.ToString());
        }

        [TestMethod]
        public void TMDbDateIComparable()
        {
            TMDbDate dateTmdb1 = new TMDbDate("1990");
            TMDbDate dateTmdb2 = new TMDbDate("1991-05-05");

            DateTime date1 = new DateTime(1990, 1, 1);
            DateTime date2 = new DateTime(1991, 5, 5);

            Assert.AreEqual(0, ((IComparable<TMDbDate>)dateTmdb1).CompareTo(dateTmdb1));
            Assert.AreEqual(-1, ((IComparable<TMDbDate>)dateTmdb1).CompareTo(dateTmdb2));

            Assert.AreEqual(0, ((IComparable<DateTime>)dateTmdb1).CompareTo(date1));
            Assert.AreEqual(-1, ((IComparable<DateTime>)dateTmdb1).CompareTo(date2));
        }

        [TestMethod]
        public void TMDbDateEquals()
        {
            TMDbDate dateTmdb1 = new TMDbDate("1990");
            TMDbDate dateTmdb2 = new TMDbDate("1991-05-05");

            DateTime date1 = new DateTime(1990, 1, 1);
            DateTime date2 = new DateTime(1991, 5, 5);

            Assert.IsTrue(((IEquatable<TMDbDate>)dateTmdb1).Equals(dateTmdb1));
            Assert.IsFalse(((IEquatable<TMDbDate>)dateTmdb1).Equals(dateTmdb2));

            Assert.IsTrue(((IEquatable<DateTime>)dateTmdb1).Equals(date1));
            Assert.IsFalse(((IEquatable<DateTime>)dateTmdb1).Equals(date2));

            Assert.IsTrue(dateTmdb1.Equals((object)dateTmdb1));
            Assert.IsFalse(dateTmdb1.Equals((object)dateTmdb2));
            Assert.IsTrue(dateTmdb1.Equals((object)date1));
            Assert.IsFalse(dateTmdb1.Equals((object)date2));
        }
    }
}
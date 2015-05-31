using System;
using System.Globalization;

namespace TMDbLib.Objects.General
{
    public class TMDbDate : IComparable<TMDbDate>, IEquatable<TMDbDate>, IComparable<DateTime>, IEquatable<DateTime>
    {
        public bool IsOnlyYear { get; private set; }

        public DateTime AsDateTime { get; private set; }

        public TMDbDate(string date)
        {
            DateTime tmp;
            if (DateTime.TryParseExact(date, "yyyy", null, DateTimeStyles.AssumeUniversal, out tmp))
            {
                AsDateTime = tmp;
                IsOnlyYear = true;
            }
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.AssumeUniversal, out tmp))
            {
                AsDateTime = tmp;
            }
            else
                throw new ArgumentException("Date was an incorrect format: " + date);
        }

        public int CompareTo(TMDbDate other)
        {
            if (IsOnlyYear)
                return AsDateTime.Year.CompareTo(other.AsDateTime.Year);

            return -other.CompareTo(AsDateTime.Date);
        }

        public int CompareTo(DateTime other)
        {
            if (IsOnlyYear)
                return AsDateTime.Year.CompareTo(other.Year);

            return AsDateTime.Date.CompareTo(other.Date);
        }

        public bool Equals(TMDbDate other)
        {
            if (other == null)
                return false;

            if (IsOnlyYear || other.IsOnlyYear)
                return AsDateTime.Year == other.AsDateTime.Year;

            return AsDateTime.Date.Equals(other.AsDateTime.Date);
        }

        public bool Equals(DateTime other)
        {
            if (IsOnlyYear)
                return AsDateTime.Year == other.Year;

            return AsDateTime.Date.Equals(other.Date);
        }

        public static bool operator <(TMDbDate date1, TMDbDate date2)
        {
            return !ReferenceEquals(date1, null) && !ReferenceEquals(date2, null) && date1.CompareTo(date2) < 0;
        }

        public static bool operator >(TMDbDate date1, TMDbDate date2)
        {
            return !ReferenceEquals(date1, null) && !ReferenceEquals(date2, null) && date1.CompareTo(date2) > 0;
        }

        public static bool operator <=(TMDbDate date1, TMDbDate date2)
        {
            return !ReferenceEquals(date1, null) && !ReferenceEquals(date2, null) && date1.CompareTo(date2) <= 0;
        }

        public static bool operator >=(TMDbDate date1, TMDbDate date2)
        {
            return !ReferenceEquals(date1, null) && !ReferenceEquals(date2, null) && date1.CompareTo(date2) >= 0;
        }

        public static bool operator ==(TMDbDate date1, TMDbDate date2)
        {
            if (ReferenceEquals(date1, null) && ReferenceEquals(date2, null))
                return true;

            return !ReferenceEquals(date1, null) && !ReferenceEquals(date2, null) && date1.CompareTo(date2) == 0;
        }

        public static bool operator !=(TMDbDate date1, TMDbDate date2)
        {
            return ReferenceEquals(date1, null) || ReferenceEquals(date2, null) || date1.CompareTo(date2) != 0;
        }

        public static bool operator <(TMDbDate date1, DateTime date2)
        {
            return !ReferenceEquals(date1, null) && date1.CompareTo(date2.Date) < 0;
        }

        public static bool operator >(TMDbDate date1, DateTime date2)
        {
            return !ReferenceEquals(date1, null) && date1.CompareTo(date2.Date) > 0;
        }

        public static bool operator <=(TMDbDate date1, DateTime date2)
        {
            return !ReferenceEquals(date1, null) && date1.CompareTo(date2.Date) <= 0;
        }

        public static bool operator >=(TMDbDate date1, DateTime date2)
        {
            return !ReferenceEquals(date1, null) && date1.CompareTo(date2.Date) >= 0;
        }

        public static bool operator ==(TMDbDate date1, DateTime date2)
        {
            return !ReferenceEquals(date1, null) && date1.CompareTo(date2.Date) == 0;
        }

        public static bool operator !=(TMDbDate date1, DateTime date2)
        {
            return ReferenceEquals(date1, null) || date1.CompareTo(date2.Date) != 0;
        }

        public static bool operator <(DateTime date1, TMDbDate date2)
        {
            return !ReferenceEquals(date2, null) && date2.CompareTo(date1.Date) > 0;
        }

        public static bool operator >(DateTime date1, TMDbDate date2)
        {
            return !ReferenceEquals(date2, null) && date2.CompareTo(date1.Date) < 0;
        }

        public static bool operator <=(DateTime date1, TMDbDate date2)
        {
            return !ReferenceEquals(date2, null) && date2.CompareTo(date1.Date) >= 0;
        }

        public static bool operator >=(DateTime date1, TMDbDate date2)
        {
            return !ReferenceEquals(date2, null) && date2.CompareTo(date1.Date) <= 0;
        }

        public static bool operator ==(DateTime date1, TMDbDate date2)
        {
            return !ReferenceEquals(date2, null) && date2.CompareTo(date1.Date) == 0;
        }

        public static bool operator !=(DateTime date1, TMDbDate date2)
        {
            return ReferenceEquals(date2, null) || date2.CompareTo(date1.Date) != 0;
        }

        public override int GetHashCode()
        {
            return AsDateTime.GetHashCode() ^ IsOnlyYear.GetHashCode();
        }

        public override string ToString()
        {
            if (IsOnlyYear)
                return AsDateTime.Year.ToString();

            return AsDateTime.ToString("yyyy-MM-dd");
        }

        int IComparable<TMDbDate>.CompareTo(TMDbDate other)
        {
            return CompareTo(other);
        }

        int IComparable<DateTime>.CompareTo(DateTime other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TMDbDate>.Equals(TMDbDate other)
        {
            return Equals(other);
        }

        bool IEquatable<DateTime>.Equals(DateTime other)
        {
            return Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is DateTime)
                return Equals((DateTime)obj);

            return Equals(obj as TMDbDate);
        }
    }
}

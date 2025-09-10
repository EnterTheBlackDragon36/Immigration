using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace Immigration
{
    class Program
    {
        static string EnterpriseConnection = ConfigurationManager.ConnectionStrings["EnterpriseSqlProvider"].ConnectionString;
        static string PeopleConnection = ConfigurationManager.ConnectionStrings["PeopleSqlProvider"].ConnectionString;
        //static string DebugConnection = ConfigurationManager.ConnectionStrings["DebugSqlProvider"].ConnectionString;
        //static string EonSoftConnection = ConfigurationManager.ConnectionStrings["EonSoftSqlProvider"].ConnectionString;
        //static string AefnbConnection = ConfigurationManager.ConnectionStrings["AefnbSqlProvider"].ConnectionString;

        ILogger _log;

        static SqlConnection conn = new SqlConnection(EnterpriseConnection);
        DataTable primaryDataTable = new DataTable();
        private static readonly HttpClient client = new HttpClient();
        private static double avgPay = 0.00;
        const int Hours = 160;
        static string generation = string.Empty;
        static string ssnNumber = string.Empty;
        static string ssnIssueState = string.Empty;
        static string url = "https://www.britannica.com/topic/list-of-cities-and-towns-in-the-United-States-2023068";
        static List<string> states = new List<string>();
        static List<string> cities = new List<string>();


        static void Main(string[] args)
        {
            //getgenerationSilentGeneration();
        }


        

        public static List<string> getOccupation()
        {
            List<string> occupations = new List<string>();
            DataTable dt = new DataTable();
            string query = "SELECT occupation FROM [EnterpriseManager].[dbo].[Occupations]";
            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }

            foreach (DataRow row in dt.Rows)
            {
                occupations.Add(row.ItemArray[0].ToString());
            }

            return occupations;
        }

        public static void processImmigrationToVessel()
        {
            //var immigrants = getgenerationSilentGeneration();
            //var vessels = getVessels();
            var occupations = getOccupation();
        }

        #region Global Locations
        public static DataTable getGlobalCountries()
        {
            DataTable dt = new DataTable();
            dt.TableName = "GlobalCountries";
            string query = String.Format("SELECT Id, CountryCode, Country FROM GlobalCountryList");

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }
            return dt;
        }

        public static DataTable getGlobalCities()
        {
            DataTable dt = new DataTable();
            dt.TableName = "GlobalCities";
            string query = String.Format("SELECT Id, CountryCode, CityAbbrCode, City FROM GlobalCitiesList");

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }
            return dt;
        }

        public static DataTable getGlobalCitiesByCountryCode(string countryCode)
        {
            DataTable dt = new DataTable();
            dt.TableName = "CitiesByCountryCode";
            string query = String.Format("SELECT Id, CountryCode, CityAbbrCode, City FROM GlobalCitiesList WHERE CountryCode = '{0}'", countryCode);

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region PersonImmigrationAssignment
        public static void insertPersonImmigrationInformation(int personKey, int occupationKey, int vesselKey, int originCountryKey, int originCityKey, int settlementStateKey, int settlementCityKey)
        {
            string query = String.Format("INSERT INTO Immigration VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6} )", personKey, occupationKey, vesselKey, originCountryKey, originCityKey, settlementStateKey, settlementCityKey);

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void insertPersonMedicalInformation(int personId, double height, string eyeColor, string hairColor, double weight)
        {
            string query = String.Format("INSERT INTO PersonMedical VALUES ({0}, '{1}', '{2}', '{3}', '{4}' )", personId, height, eyeColor, hairColor, weight);

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void insertprocessPeopleToAssignOriginCountry()
        {
            //string query = String.Format("INSERT INTO PersonImmigration VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}', {8}, '{9}' )", personId, townOfBirth, countryOfBirth, lastResidence, departure.ToString("MM/dd/yyyy"), arrival.ToString("MM/dd/yyyy"), profession, vesselName, amountOfMoney, namesOfRelatives.ToList());
            string query = string.Empty;
            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static void insertprocessPeopleImmigrationInformation()
        {
            //string query = String.Format("INSERT INTO PersonImmigration VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}', {8}, '{9}' )", personId, townOfBirth, countryOfBirth, lastResidence, departure.ToString("MM/dd/yyyy"), arrival.ToString("MM/dd/yyyy"), profession, vesselName, amountOfMoney, namesOfRelatives.ToList());
            string query = string.Empty;
            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        #endregion

        #region Randomized Generation Assignments
        public static DateTime assignDateOfBirth()
        {
            Thread.Sleep(60000); // 1 minutes
            DateTime dob = new DateTime();

            Random rdm = new Random();
            int[] generationType = new int[5] { 1, 2, 3, 4, 5 };
            int randomIndex = rdm.Next(0, 5);
            int randomNumber = generationType[randomIndex];

            switch (randomNumber)
            {
                case 1:
                    dob = assignSilentGeneration();
                    generation = "Silent Generation";
                    break;

                case 2:
                    dob = assignGenerationBabyBoomers();
                    generation = "Baby Boomers";
                    break;

                case 3:
                    dob = assignGenerationX();
                    generation = "Generation X";
                    break;

                case 4:
                    dob = assignGenerationY();
                    generation = "Generation Y";
                    break;

                case 5:
                    dob = assignGenerationZ();
                    generation = "Generation Z";
                    break;

                default:
                    break;
            }

            return dob;
        }
        public static DateTime assignSilentGeneration()
        {
            //Traditionalists or Silent Generation Before 1945
            var silentGenStartDate = Convert.ToDateTime("01/01/1933 00:00:00.000");
            var silentGenEndDate = Convert.ToDateTime("12/31/1945 23:59:59.000");
            var dob = Date(silentGenStartDate, silentGenEndDate);

            return dob;
        }
        public static DateTime assignGenerationBabyBoomers()
        {
            //Baby Boomers 1946-1964
            var babyBoomersStartDate = Convert.ToDateTime("01/01/1946 00:00:00.000");
            var babyBoomersEndDate = Convert.ToDateTime("12/31/1964 23:59:59.000");
            var dob = Date(babyBoomersStartDate, babyBoomersEndDate);

            return dob;
        }
        public static DateTime assignGenerationX()
        {
            //Generation X 1965-1976
            var GenXStartDate = Convert.ToDateTime("01/01/1965 00:00:00.000");
            var GenXEndDate = Convert.ToDateTime("12/31/1976 23:59:59.000");
            var dob = Date(GenXStartDate, GenXEndDate);

            return dob;
        }
        public static DateTime assignGenerationY()
        {
            //Millennials or Gen Y 1977-1995
            var GenYStartDate = Convert.ToDateTime("01/01/1977 00:00:00.000");
            var GenYEndDate = Convert.ToDateTime("12/31/1995 23:59:59.000");
            var dob = Date(GenYStartDate, GenYEndDate);

            return dob;
        }
        public static DateTime assignGenerationZ()
        {
            //Generation Z iGen or Centennials 1996 - Present
            var GenZStartDate = Convert.ToDateTime("01/01/1996 00:00:00.000");
            var GenZEndDate = Convert.ToDateTime("01/01/2021 23:59:59.000");
            var dob = Date(GenZStartDate, GenZEndDate);

            return dob;
        }
        public static DateTime Date(DateTime? start = null, DateTime? end = null)
        {
            Random random = new Random();

            if (start.HasValue && end.HasValue && start.Value >= end.Value)
                throw new Exception("start date must be less than end date!");

            DateTime min = start ?? DateTime.MinValue;
            DateTime max = end ?? DateTime.MaxValue;

            // for timespan approach see: http://stackoverflow.com/q/1483670/1698987
            TimeSpan timeSpan = max - min;

            // for random long see: http://stackoverflow.com/a/677384/1698987
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);

            long int64 = Math.Abs(BitConverter.ToInt64(bytes, 0)) % timeSpan.Ticks;

            TimeSpan newSpan = new TimeSpan(int64);
            //Console.WriteLine(min + newSpan);
            return min + newSpan;
        }
        #endregion

        private static bool IsServerConnected()
        {
            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection Successful");
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("There was a problem connecting to your SQL Server Database");
                    return false;
                    throw;
                }
            }
        }

        public static void randomNumberFromArray()
        {
            Random random = new Random();
            var arr1 = new[] { 1, 2, 3, 4, 5, 6 };
            var rndMember = arr1[random.Next(arr1.Length)];

            Console.WriteLine("Your Random Number is {0} ", rndMember);
        }

        public static DataTable getNonAvailableAddress()
        {
            DataTable nonAvailableAddress = new DataTable();
            nonAvailableAddress.Rows.AsQueryable();

            Random random = new Random();



            return nonAvailableAddress;
        }

        public static IEnumerable<string> getPeopleLastNames()
        {
            DataTable dt = new DataTable();
            List<string> lastnames = new List<string>();
            string query = "SELECT LastName, COUNT([LastName]) AS Count FROM People1 GROUP BY LastName HAVING COUNT([LastName]) > 1 ORDER BY COUNT([LastName]) DESC";
            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }

            foreach (DataRow row in dt.Rows)
            {
                lastnames.Add(row.ItemArray[0].ToString());
            }

            return lastnames;
        }

        #region Asian Immigrants
        //public static IEnumerable<GlobalCities> getChineseCities()
        //{
        //    DataTable dt = new DataTable();
        //    List<GlobalCities> globalCities = new List<GlobalCities>();
        //    string query = "SELECT Id, CountryCode, CityAbbrCode, City, LongLatCode FROM [EnterpriseManager].[dbo].[GlobalCitiesList] WHERE CountryCode = 'CN'";
        //    using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            // Obtain a data reader via ExecuteReader().
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                dt.Load(dr);
        //                dr.Close();
        //            }
        //        }
        //        conn.Close();
        //    }

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        GlobalCities cities = new GlobalCities();
        //        cities.Id = Convert.ToInt32(row.ItemArray[0].ToString());
        //        cities.countryCode = row.ItemArray[1].ToString();
        //        cities.cityAbbrCode = row.ItemArray[2].ToString();
        //        cities.city = row.ItemArray[3].ToString();
        //        cities.LongLatCode = row.ItemArray[4].ToString();
        //        globalCities.Add(cities);
        //    }

        //    return globalCities;
        //}
        #endregion

        #region European Immigrants
        //public static IEnumerable<GlobalCities> getIrishCities()
        //{
        //    DataTable dt = new DataTable();
        //    List<GlobalCities> globalCities = new List<GlobalCities>();
        //    string query = "SELECT Id, CountryCode, CityAbbrCode, City, LongLatCode FROM [EnterpriseManager].[dbo].[GlobalCitiesList] WHERE CountryCode = 'IE'";
        //    using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            // Obtain a data reader via ExecuteReader().
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                dt.Load(dr);
        //                dr.Close();
        //            }
        //        }
        //        conn.Close();
        //    }

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        GlobalCities cities = new GlobalCities();
        //        cities.Id = Convert.ToInt32(row.ItemArray[0].ToString());
        //        cities.countryCode = row.ItemArray[1].ToString();
        //        cities.cityAbbrCode = row.ItemArray[2].ToString();
        //        cities.city = row.ItemArray[3].ToString();
        //        cities.LongLatCode = row.ItemArray[4].ToString();
        //        globalCities.Add(cities);
        //    }

        //    return globalCities;
        //}

        //public static IEnumerable<GlobalCities> getEnglishCities()
        //{
        //    DataTable dt = new DataTable();
        //    List<GlobalCities> globalCities = new List<GlobalCities>();
        //    string query = "SELECT Id, CountryCode, CityAbbrCode, City, LongLatCode FROM [EnterpriseManager].[dbo].[GlobalCitiesList] WHERE CountryCode = 'GB'";
        //    using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            // Obtain a data reader via ExecuteReader().
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                dt.Load(dr);
        //                dr.Close();
        //            }
        //        }
        //        conn.Close();
        //    }

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        GlobalCities cities = new GlobalCities();
        //        cities.Id = Convert.ToInt32(row.ItemArray[0].ToString());
        //        cities.countryCode = row.ItemArray[1].ToString();
        //        cities.cityAbbrCode = row.ItemArray[2].ToString();
        //        cities.city = row.ItemArray[3].ToString();
        //        cities.LongLatCode = row.ItemArray[4].ToString();
        //        globalCities.Add(cities);
        //    }

        //    return globalCities;
        //}
        #endregion

        #region African Immigrants

        #endregion

        #region Indian Immigrants

        #endregion

        #region Latin Immigrants

        #endregion

        public static DataTable getOccupations()
        {
            DataTable occupations = new DataTable();
            var query = "SELECT * FROM [EnterpriseManager].[dbo].[Occupations]";

            using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Obtain a data reader via ExecuteReader().
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        occupations.Load(dr);
                        dr.Close();
                    }
                }
                conn.Close();
            }

            return occupations;
        }

        //public static GlobalCountry getCountryByCountryCode(string countryCode)
        //{
        //    GlobalCountry country = new GlobalCountry();
        //    string query = string.Format("SELECT Id, CountryCode, Country FROM [EnterpriseManager].[dbo].[GlobalCountryList] WHERE CountryCode = '{0}'", countryCode);
        //    using (SqlConnection conn = new SqlConnection(EnterpriseConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    country.Id = Convert.ToInt32(dr[0].ToString());
        //                    country.countryCode = dr[1].ToString();
        //                    country.country = dr[2].ToString();
        //                }
        //            }
        //        }
        //        conn.Close();
        //    }

        //    return country;
        //}
    }
}

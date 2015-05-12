using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PurityBridge.Live.Utilities
{
    public class NewsletterUtility
    {
        private Dictionary<string, NewsletterModel> _newsLetterDic = new Dictionary<string, NewsletterModel>();

        private NewsletterUtility()
        {

        }

        private static NewsletterUtility _newsletterUtility;

        public static NewsletterUtility GetNewsletterUtility(string logsPath)
        {
            if (_newsletterUtility == null)
            {
                _newsletterUtility = new NewsletterUtility();
                if (!Directory.Exists(logsPath))
                {
                    Directory.CreateDirectory(logsPath);
                }
                var newsletterLogFile = Path.Combine(logsPath, "NewsLetter.txt");
                if (!File.Exists(newsletterLogFile))
                {
                    File.Create(newsletterLogFile);
                }
                try
                {
                    StreamWriter stream = new StreamWriter(newsletterLogFile, true);
                    stream.WriteLine("NewsLetter Utility Ctor Called : " + DateTime.Now.ToString());
                    stream.Flush();
                    stream.Close();
                }
                catch
                {

                }
            }
            return _newsletterUtility;
        }

        public List<NewsletterModel> GetNewsLetters(string rootPath, int year = 0)
        {
            List<NewsletterModel> list = new List<NewsletterModel>();
            if (Directory.Exists(rootPath))
            {
                var path = rootPath;
                if (year > 0)
                {
                    path = Path.Combine(path, year.ToString());
                    //if (month != Month.ALL)
                    //{
                    //    path = Path.Combine(path, month.ToString());
                    //}
                }
                LoadAllNewsLetters(path, out list);
            }
            return list;
        }

        private void LoadAllNewsLetters(string path, out List<NewsletterModel> list)
        {
            list = new List<NewsletterModel>();
            if (Directory.Exists(path))
            {
                List<string> finalPaths = new List<string>();
                var allDirectories = Directory.GetDirectories(path);

                allDirectories.ToList().ForEach(d =>
                {
                    var cd = Directory.GetDirectories(d);
                    if (cd.Any())
                    {
                        cd.Where(c => File.Exists(Path.Combine(d, c, "Newsletter.txt"))).ToList().ForEach(c => finalPaths.Add(Path.Combine(d, c)));
                    }
                    else
                    {
                        if (File.Exists(Path.Combine(d, "Newsletter.txt")))
                        {
                            finalPaths.Add(Path.Combine(d));
                        }
                    }
                });

                var allNewsLetters = finalPaths.ConvertAll<NewsletterModel>(p => GetNewsLetterModel(p));
                list.AddRange(allNewsLetters);
            }
        }

        public NewsletterModel GetNewsLetterModel(string rootPath, int month, int year)
        {
            return GetNewsLetterModel(rootPath, GetMonth(month), year);
        }

        public NewsletterModel GetNewsLetterModel(string rootPath, Month month = Month.ALL, int year = 0)
        {
            NewsletterModel model = null;
            NewsletterModel dicModel;
            var path = GetNewsLetterPath(rootPath, year, month);
            if (_newsLetterDic.TryGetValue(path, out dicModel))
            {
                if (DateTime.Compare(File.GetLastWriteTime(path), dicModel.CreationDate) > 0)
                {
                    LoadNewContent(path, dicModel);
                }
                model = new NewsletterModel(dicModel);
            }
            else
            {
                model = CreateNewsLetterModel(rootPath, month, year);
            }
            if (year > 0)
            {
                model.IsArchived = DateTime.Now.Year > year + 2;
            }
            return model;
        }

        private void LoadNewContent(string path, NewsletterModel newsLetterModel)
        {
            if (newsLetterModel != null)
            {
                var newContent = GetContent(path);
                if (!string.IsNullOrEmpty(newContent))
                {
                    newsLetterModel.Content = newContent;
                }
            }
        }

        private string GetContent(string path)
        {
            var content = string.Empty;
            if (File.Exists(path))
            {
                try
                {
                    var reader = new StreamReader(path);
                    content = reader.ReadToEnd();
                }
                catch
                {
                }
            }
            return content;
        }

        public NewsletterModel CreateNewsLetterModel(string rootPath, Month month, int year)
        {
            NewsletterModel model = null;
            var path = GetNewsLetterPath(rootPath, year, month);

            var type = typeof(Month);
            var meminfo = type.GetMember(month.ToString());
            var monthAttrs = meminfo[0].GetCustomAttributes(typeof(MonthAttribute), false);

            if (File.Exists(path))
            {
                try
                {
                    var reader = new StreamReader(path);
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(content))
                    {
                        model = new NewsletterModel()
                        {
                            Content = content,
                            CreationDate = DateTime.Now,
                            Year = year,
                            MonthDisplayName = ((MonthAttribute)monthAttrs[0]).GetShortName(),
                            MonthIndex = ((MonthAttribute)monthAttrs[0]).GetIndex(),
                            MonthName = ((MonthAttribute)monthAttrs[0]).GetName()
                        };
                        if (!_newsLetterDic.ContainsKey(path))
                        {
                            _newsLetterDic.Add(path, model);
                        }
                        model = new NewsletterModel(model);
                    }
                }
                catch
                {

                }
            }
            return model;
        }

        private string GetNewsLetterPath(string rootPath, int year, Month month)
        {
            int monthIndex = GetMonthIndex(month);
            return Path.Combine(rootPath, year == 0 ? "" : year.ToString(), month == Month.ALL ? "" : Convert.ToInt32(month).ToString(), "Newsletter.txt");
        }

        private int GetMonthIndex(Month month)
        {
            return Convert.ToInt32(month);
        }
        private Month GetMonth(int index)
        {
            switch (index)
            {
                case 1:
                    return Month.JANUARY;
                case 2:
                    return Month.FEBRUARY;
                case 3:
                    return Month.MARCH;
                case 4:
                    return Month.APRIL;
                case 5:
                    return Month.MAY;
                case 6:
                    return Month.JUNE;
                case 7:
                    return Month.JULY;
                case 8:
                    return Month.AUGUST;
                case 9:
                    return Month.SEPTEMBER;
                case 10:
                    return Month.OCTOBER;
                case 11:
                    return Month.NOVEMBER;
                case 12:
                    return Month.DECEMBER;
                case 0:
                case -1:
                default:
                    return Month.ALL;
            }
        }
    }
}
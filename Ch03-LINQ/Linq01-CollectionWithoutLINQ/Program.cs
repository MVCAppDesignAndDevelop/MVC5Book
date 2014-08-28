using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq01_CollectionWithoutLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = GetStudents();
            List<StudentScore> csScores = GetCSScores();
            List<StudentScore> dbScores = GetDBScores();

            // 彙總成績
            //double csScoresSum = 0.0;
            //double dbScoresSum = 0.0;
            //double csScoresAvg = 0.0;
            //double dbScoresAvg = 0.0;

            //foreach (StudentScore csScore in csScores)
            //{
            //    csScoresSum += csScore.Score;
            //}

            //foreach (StudentScore dbScore in dbScores)
            //{
            //    dbScoresSum += dbScore.Score;
            //}

            //csScoresAvg = csScoresSum / students.Count;
            //dbScoresAvg = dbScoresSum / students.Count;

            //Console.WriteLine("C#課程分數加總：{0}, 平均：{1}", csScoresSum, csScoresAvg.ToString("0.00"));
            //Console.WriteLine("DB課程分數加總：{0}, 平均：{1}", dbScoresSum, dbScoresAvg.ToString("0.00"));

            // 依學生彙總

            List<StudentScoreReport> Reports = new List<StudentScoreReport>();

            foreach (Student student in students)
            {
                int scoreCount = 0;
                StudentScoreReport report = new StudentScoreReport();
                report.Id = student.Id;
                report.Name = student.Name;

                foreach (StudentScore csScore in csScores)
                {
                    if (csScore.Id == student.Id)
                    {
                        report.ScoreSum += csScore.Score;
                        scoreCount++;
                        break;
                    }
                }

                foreach (StudentScore dbScore in dbScores)
                {
                    if (dbScore.Id == student.Id)
                    {
                        report.ScoreSum += dbScore.Score;
                        scoreCount++;
                        break;
                    }
                }

                report.ScoreAvg = report.ScoreSum / scoreCount;
                Reports.Add(report);
            }

            //foreach (StudentScoreReport report in Reports)
            //{
            //    Console.WriteLine("學生 {0} 分數加總：{1}, 平均：{2}", 
            //        report.Name, report.ScoreSum, report.ScoreAvg.ToString("0.00"));
            //}

            IEnumerator<StudentScoreReport> reports = Reports.GetEnumerator();

            while (reports.MoveNext())
            {
                Console.WriteLine("學生 {0} 分數加總：{1}, 平均：{2}",
                    reports.Current.Name,
                    reports.Current.ScoreSum,
                    reports.Current.ScoreAvg.ToString("0.00"));
            }
            
            Console.ReadLine();
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>(new[] 
            {
                new Student() {
                  Id = "001", Name = "張三"
                },
                new Student() {
                  Id = "002", Name = "李四"
                },
                new Student() {
                  Id = "003", Name = "王五"
                },
                new Student() {
                  Id = "004", Name = "陳六"
                },
                new Student() {
                  Id = "005", Name = "飛七"
                }
            });
        }

        private static List<StudentScore> GetCSScores()
        {
            return new List<StudentScore>(new[] 
            {
                new StudentScore() {
                  Id = "001", Score = 82
                },
                new StudentScore() {
                  Id = "002", Score = 65
                },
                new StudentScore() {
                  Id = "003", Score = 43
                },
                new StudentScore() {
                  Id = "004", Score = 78
                },
                new StudentScore() {
                  Id = "005", Score = 90
                }
            });
        }

        private static List<StudentScore> GetDBScores()
        {
            return new List<StudentScore>(new[] 
            {
                new StudentScore() {
                  Id = "001", Score = 55
                },
                new StudentScore() {
                  Id = "002", Score = 61
                },
                new StudentScore() {
                  Id = "003", Score = 72
                },
                new StudentScore() {
                  Id = "004", Score = 90
                },
                new StudentScore() {
                  Id = "005", Score = 82
                }
            });
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class StudentScore
    {
        public string Id { get; set; }
        public int Score { get; set; }
    }

    public class StudentScoreReport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double ScoreSum { get; set; }
        public double ScoreAvg { get; set; }
    }
}

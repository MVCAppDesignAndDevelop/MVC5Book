using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq02_CollectionWithLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = GetStudents();
            List<StudentScore> csScores = GetCSScores();
            List<StudentScore> dbScores = GetDBScores();

            // 彙總成績
            //Console.WriteLine("C#課程分數加總：{0}, 平均：{1}",
            //    csScores.Sum(c => c.Score), 
            //    csScores.Average(c => c.Score).ToString("0.00"));
            //Console.WriteLine("DB課程分數加總：{0}, 平均：{1}",
            //    dbScores.Sum(c => c.Score), 
            //    dbScores.Average(c => c.Score).ToString("0.00"));

            // 依學生彙總
            var studentScoreQuery =
                from student in students
                join csScore in csScores on student.Id equals csScore.Id
                join dbScore in dbScores on student.Id equals dbScore.Id
                select new
                {
                    Id = student.Id,
                    Name = student.Name,
                    ScoreSum = csScore.Score + dbScore.Score,
                    ScoreAvg = (csScore.Score + dbScore.Score) / 2
                };


            foreach (var studentScore in studentScoreQuery)
            {
                Console.WriteLine("學生 {0} 分數加總：{1}, 平均：{2}",
                    studentScore.Name, 
                    studentScore.ScoreSum, 
                    studentScore.ScoreAvg.ToString("0.00"));
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
}

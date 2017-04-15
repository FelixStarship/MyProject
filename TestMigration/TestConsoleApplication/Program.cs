using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //1.单个from子句
            string[] values = { "LINQ学习", "LINQ基本语句", "from子句", "单个from子句" };
            var value = from v in values
                        where v.IndexOf("LINQ") > -1
                        select new { v, v.Length };

            foreach (var item in value)
            {
                Console.WriteLine("{0},{1}", item.v, item.Length);
            }
            Console.ReadKey();

            //使用linq查询ArrayList
            List<GustInfo> gList = new List<GustInfo>
            {
                new GustInfo {Name="DebugLZQ",Age=26,Tel=1555555555},
                new GustInfo {Name="博客园",Age=6,Tel=2666666666},
                new GustInfo {Name="车影",Age=8,Tel=599999999999},
            };

            List<GustInfo> gListentities = new List<GustInfo>
            {
                new GustInfo {Name="DebugLZQ",Age=26,TelTable=new List<string>{ "11111","22222"} },
                new GustInfo {Name="博客园",Age=6,Tel=2666666666,TelTable=new List<string> { "33333","444444"} },
                new GustInfo {Name="车影",Age=8,Tel=599999999999,TelTable=new List<string> { "555555","6666666"} },
            };

            List<cheying> gListentity = new List<cheying>
            {
              new cheying { Module="测试1"},
              new cheying { Module="测试2"}
            };


            var query = from g in gList
                        where g.Age > 6
                        select g;
            foreach (var item in query)
            {
                Console.WriteLine("年龄:{0} 电话:{1}", item.Age, item.Tel);
            }
            Console.ReadKey();

            //复合from子句
            var queryentities = from gu in gListentities
                                from tel in gu.TelTable
                                where tel.IndexOf("2222") > -1
                                select gu;
            foreach (var item in queryentities)
            {
                Console.WriteLine("年龄:{0}",item.Age);
                foreach (var tel in item.TelTable)
                {
                    Console.WriteLine("电话:{0},",tel);
                }
            }
            Console.ReadKey();

            //多个from子句
            var querylist = from gl in gList
                            where gl.Age > 6
                            from entity in gListentity
                            select new { gl, entity };

            foreach (var entity in querylist)
            {
                Console.WriteLine("{0}  {1}",entity.entity.Module,entity.gl.Name);
            }

            Console.ReadKey();

            //where子句
            var queryable = from g in gListentities
                            where g.Age > 6 && Checked(g.Name)
                            select g;

            foreach (var entity in queryable)
            {
                Console.WriteLine("{0}",entity.Name);
            }

            Console.ReadKey();
            var queryinto = from g in gListentities
                             select g.Age into intos select intos;


            foreach (var into in queryinto)
            {
                Console.WriteLine("{0}",into);
            }

            //let 用于存储查询表达式的结果    通过let构建范围变量 var 并通过let构建查询表达式
            var querylet = from lets in gList
                           let var = lets.Name.Substring(0, 1).ToString()
                           where var == "D" || var == "博"
                           select lets;
            foreach (var let in querylet)
            {
                Console.WriteLine("{0}",let.Name);
            }
        }

        public static bool Checked(string name)
        {
            if (name.Substring(0, 1) == "D")
                return false;
            else
                return true;
        }
    }

    public class GustInfo
    {   
        public string Name { get; set; }
        public int Age { get; set; }

        public long Tel { get; set; }

        public List<string> TelTable { get; set; }
    }

    public class cheying
    {
        public string Module { get; set; }
    }
}

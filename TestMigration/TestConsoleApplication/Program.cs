using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{

    public delegate bool Predicate<in T>(T obj);
    public class Program
    {    
        
        //http://www.cnblogs.com/DebugLZQ/archive/2012/11/07/2756997.html
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
                new GustInfo {Name="DebugLZQ",Age=26,Tel="1555555555"},
                new GustInfo {Name="博客园",Age=6,Tel="2666666666"},
                new GustInfo {Name="车影",Age=8,Tel="599999999999"},
            };

            List<GustInfo> gListentities = new List<GustInfo>
            {
                new GustInfo {Name="DebugLZQ",Age=26,TelTable=new List<string>{ "11111","22222"} },
                new GustInfo {Name="博客园",Age=6,Tel="2666666666",TelTable=new List<string> { "33333","444444"} },
                new GustInfo {Name="车影",Age=8,Tel="599999999999",TelTable=new List<string> { "555555","6666666"} },
            };


            List<cheying> gListentity = new List<cheying>
            {
              new cheying { Module="测试1"},
              new cheying { Module="测试2"}
            };

            List<GustInfo> group = new List<GustInfo>()
            {
                new GustInfo(){ Name="DebugLZQ",Age=26,Tel="187********"},
                new GustInfo(){ Name="Sarah",Age=25,Tel="159********"},
                new GustInfo(){ Name="Jerry",Age=35,Tel="135********"},
                new GustInfo(){ Name="M&M",Age=16,Tel="136********"},
                new GustInfo(){ Name="DebugMan",Age=26,Tel="136********"},
                new GustInfo(){ Name="Jerry&Tom",Age=19,Tel="136********"}
                
            };
            List<GuestTitle> titleList = new List<GuestTitle>()
            {
                new GuestTitle(){Name="DebugLZQ",Title="Soft Engineer"},
                new GuestTitle(){Name="DebugLZQ",Title="Team Leader"},
                new GuestTitle(){Name="Sarah",Title="Test Engineer"},
                new GuestTitle(){Name="Jerry",Title="Head Master"}
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


            //group 子句
            var querygroup = from guest in gList
                             group guest by guest.Age;
            foreach (IGrouping<int,GustInfo> Groupitem in querygroup)
            {
                Console.WriteLine("分组键：{0}", Groupitem.Key);
                foreach (var item in Groupitem)
                {
                    Console.WriteLine("年龄：{0},电话：{1}",item.Age,item.Tel);
                }
            }
            Console.ReadKey();

            var groupentity = from guest in @group
                              group guest by guest.Name.Substring(0, 1);
            foreach (IGrouping<string,GustInfo> guest in groupentity)
            {
                Console.WriteLine("分组键：{0}",guest.Key);
                foreach (var item in guest)
                {
                    Console.WriteLine("年龄：{0}  姓名：{1}",item.Age,item.Name);
                }
            }
            Console.ReadKey();

            //into子句
            var intoquery = from guest in @group
                            group guest by guest.Name.Substring(0, 1) into grguest
                            orderby grguest.Key descending
                            select grguest;
            var intoquery2 = from guest in @group
                             group guest by guest.Name.Substring(0, 1) into grguest
                             orderby grguest.Key ascending
                             select grguest;

            var intoquery3 = from guest in @group
                             select new { NewName = guest.Name, NewAge = guest.Age } into newguest
                             orderby newguest.NewAge descending
                             select newguest;
            foreach (var item in intoquery3)
            {
                Console.WriteLine("姓名：{0}  年龄：{1}",item.NewName,item.NewAge);
            }
            Console.ReadKey();

            //join子句
            var joinquery = from guest in @group
                            join title in titleList
                            on guest.Name equals title.Name
                            select new { Name = guest.Name, Title = title.Title, Age = guest.Age };

            var join = from guest in @group
                       from title in titleList
                       where guest.Name == title.Name
                       select new { Name = guest.Name, Title = title.Title, Age = guest.Age };

            //根据姓名进行分组连接
            var joininto = from guest in @group
                           join title in titleList
                           on guest.Name equals title.Name
                           into tgroup
                           select new {Name=guest.Name,title= tgroup };

            var groupjoin=group.GroupJoin(titleList, guest => guest.Name, title => title.Name, (guest, title) => new { Name = guest.Name, title = title.DefaultIfEmpty() });
            //根据姓名进行左连接
            var leftjoin = from guest in @group
                           join title in titleList on guest.Name equals title.Name into tgroup
                           from subTitle in tgroup.DefaultIfEmpty(new GuestTitle{Title="空缺" })
                           select new {Name=guest.Name,Title= subTitle.Title};
            
            foreach (var into in joininto)
            {
                Console.WriteLine(into.Name);
                foreach (var item in into.title)
                {
                    Console.WriteLine(item.Title);
                }
            }
            Console.ReadKey();
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

        public string Tel { get; set; }

        public List<string> TelTable { get; set; }
    }

    public class GuestTitle
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }


    public class cheying
    {
        public string Module { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMigration.Domain.Interface;
using TestMigration.Domain.core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace TestMigration.Areas.Member.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IDbContext _dbContext;
        public OrderController(IUserRepository userRepository,
            IDbContext dbContext)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
        }
        // GET: Member/Order
        public ActionResult Index()
        {

            //var order = new Order
            // {
            //     OrderTitle = "五一狂欢节",
            //     Customer = "张远",
            //     TransactionDate = DateTime.Now
            // };
            // var employee1 = new Employee { EmployeeName="温泉开发人员-方俊盛",Order=new List<Order>()};
            // var employee2 = new Employee { EmployeeName = "温泉开发人员-潘俊",Order=new List<Order>()};
            // order.Employee.Add(employee2);
            // this._dbContext.Entry<Order>(order).State=EntityState.Added;
            // this._dbContext.Set<Order>().Add(order);
            // this._dbContext.SaveChanges();


            //var employeeToUpdate = this._dbContext.Set<Employee>().Include(x => x.Order).FirstOrDefault(x => x.Id == 3);
            //employeeToUpdate.Order = new List<Order>();
            //this._dbContext.SaveChanges();

            //var employeeToAdd = this._dbContext.Set<Employee>().Include(t => t.Order).FirstOrDefault(x => x.Id == 4);
            //int[] orderIdList = { 4, 5, 6, 7, 8, 9 };
            //if (employeeToAdd != null)
            //{
            //    var employeeOrder = new HashSet<int>(employeeToAdd.Order.Select(t => t.Id));
            //    foreach (var order in this._dbContext.Set<Order>())
            //    {
            //        if (orderIdList.Contains(order.Id))
            //        {
            //            if (employeeOrder.Contains(order.Id))
            //            {

            //            }
            //            else
            //            {
            //                employeeToAdd.Order.Add(order);
            //            }
            //        }
            //    }
            //}
            //this._dbContext.SaveChanges();





            var arr = new string[] { };
            var backstr = string.Empty;
            string postUrl = "http://pv.sohu.com/cityjson";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(postUrl);
                req.Method = "POST";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (Stream responseStream = res.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("gb2312")))
                    {
                        //如果 var backstr = {"cip": "183.39.52.39", "cid": "440300", "cname": "广东省深圳市"};这样就可以

                        backstr = myStreamReader.ReadToEnd().Split('=')[1].Replace(" ","").Replace(";","");

                    }
                }
                
              var str=ParseFormJson<Class1>(backstr);

            }
            catch (Exception ex)
            {
                
            }
             



            return View();
        }

        public static T ParseFormJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
                return (T)dcj.ReadObject(ms);
            }
        }


    
        
        


    }
    public class Class1
    {
        public string cip { get; set; }
        public string cid { get; set; }

        public string cname { get; set; }
    }
}
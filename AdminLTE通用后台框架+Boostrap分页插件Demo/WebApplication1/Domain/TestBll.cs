using Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TestBll
    {
        public  List<Student> StuList { get; set; }
        public TestBll()
        {
            if (StuList==null)
            {
                StuList = new List<Student>();
              
                for (int i = 1; i < 100; i++)
                {
                    Student item = new Student() { ID = i, Name = "学员" + i, SchoolNum = i.ToString().PadLeft(6, '0'), Sex = (i % 2) == 0 ? 0 : 1 };
                    StuList.Add(item);
                }
            }
           
        }
    }
}

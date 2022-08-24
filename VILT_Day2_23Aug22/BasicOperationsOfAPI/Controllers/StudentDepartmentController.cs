﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicOperationsOfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDepartmentController : ControllerBase
    {
        public static List<Student> stud = new List<Student>();
        public static List<Department> dept = new List<Department>();


        [HttpGet]
        [Route("StudentsList")]
        public IEnumerable<Student> GetStudent()
        {
            return stud;
        }

        [HttpGet]
        [Route("DepartmentList")]
        public IEnumerable<Department> GetDepartment()
        {
            return dept;
        }


        [HttpPost]
        [Route("InsertDepartment")]
        public IActionResult InsertDepartment(int id, string Dname)
        {
            var isExists = dept.Contains(dept.Find(d => d.DepartmentId == id));
            if (isExists)
            {
                return BadRequest("Department already present");
            }
            try
            {
                dept.Add(new Department
                {
                    DepartmentId = id,
                    DepartmentName = Dname
                });

                return Ok("Department Added Successfully");
            }
            catch (Exception e)
            {
                //return BadRequest("Can't able to add Department");
                throw e;
            }
        }

        [HttpPost]
        [Route("InsertStudent")]
        public IActionResult InsertStudent(int id, string Sname, int deptid)
        {
            var isExists = stud.Contains(stud.Find(s => s.StudentId == id));
            if (isExists)
            {
                return BadRequest("Student already present");
            }
            try
            {
                    stud.Add(new Student
                    {
                        StudentId = id,
                        StudentName = Sname,
                        StudentDepartmentId = deptid
                    });

                    return Ok("Student Added Successfully");
            }
            catch (Exception e)
            {
                //return BadRequest("Can't able to add Student");
                throw e;
            }
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public IActionResult UpdateDepartment(int deptId, string deptName, int studId)
        {
            var isExists = stud.Contains(stud.Find(stud => stud.StudentDepartmentId == deptId && stud.StudentId == studId));
            var department= dept.Find(d => d.DepartmentId == deptId);
            var student = stud.Find(s => s.StudentId == studId);
            
            if (!isExists)
            {
                if (student == null)
                    return BadRequest("Student having id " + studId + " not found");
                else if (department == null)
                    return BadRequest("Department having id " + deptId + " not found");
                else
                    return BadRequest("Student " + student.StudentName + " is not belongs to Department " + department.DepartmentName);
            }
            
            try
            {
                    if (dept.Contains(department))
                    {
                        department.DepartmentName = deptName;
                    }
                    return Ok("Updated department successfully");
            }
            catch (Exception e)
            {
                //return BadRequest("Can't able to update Department");
                throw e;
            }
        }

    }
}

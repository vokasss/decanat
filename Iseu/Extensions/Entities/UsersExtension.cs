using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iseu.Models;
using Newtonsoft.Json;

namespace Iseu.Models
{
    public static class UsersExtension
    {
        public static User New(RegisterModel model)
        {
            User ret = new User();
            ret.FirstName = model.FirstName;
            ret.LastName = model.LastName;
            ret.LoginName = model.LoginName;
            ret.BirthDate = model.BirthDate;
            ret.DateLastVisited = ret.DateRegistered = DateTime.Now;
            Password pass = Password.Create(model.Password);
            ret.Password = pass.Hash;
            ret.Salt = pass.Salt;
            ret.Email = model.Email;
            ret.Role = (int)AccountRole.User;
            ret.Status = (int)AccountStatus.Normal;
            return ret;
        }

        public static User Fictive
        {
            get { return new User() { Id = 0 }; }
        }


        public static List<SelectListItem> GetGenders()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)Gender.Male).ToString(),
                Text = "М"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)Gender.Female).ToString(),
                Text = "Ж"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetPayments()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)PaymentStatus.Free).ToString(),
                Text = "Бесплатно"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)PaymentStatus.Paid).ToString(),
                Text = "Платно"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetStudyStatus()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)StudyStatus.Active).ToString(),
                Text = "Учится"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)StudyStatus.Expelled).ToString(),
                Text = "Отчислен"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)StudyStatus.Graduated).ToString(),
                Text = "Окончил"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetAccountStatus()
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)AccountStatus.Normal).ToString(),
                Text = "Разбанен"
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)AccountStatus.Banned).ToString(),
                Text = "Забанен"
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetRoles(int role)
        {
            var items = new List<SelectListItem>();
            var listItem = new SelectListItem
            {
                Value = ((int)AccountRole.User).ToString(),
                Text = "Посетитель",
                Selected = role == (int)AccountRole.User
            };
            listItem = new SelectListItem
            {
                Value = ((int)AccountRole.Decanat).ToString(),
                Text = "Деканат",
                Selected = role == (int)AccountRole.Decanat
            };
            items.Add(listItem);
            listItem = new SelectListItem
            {
                Value = ((int)AccountRole.Admin).ToString(),
                Text = "Админ",
                Selected = role == (int)AccountRole.Admin
            };
            items.Add(listItem);
            return items;
        }

        public static List<SelectListItem> GetAcademicTitles()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.ATitles)
            {
                items.Add(new SelectListItem
            {
                Value = (item.Id).ToString(),
                Text = item.Title
            });
            }
            return items;
        }

        public static List<SelectListItem> GetProfessors()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in Core.DBcontext.Professors)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.User.FullName
                });
            }
            return items;
        }

        public static List<SelectListItem> GetAcademicDegrees()
        {
            var items = new List<SelectListItem>();
            foreach (var item in Core.DBcontext.ADegrees)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetChairs()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.Chairs)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetFaculties()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.Faculties)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetGroups()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.Groups)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetSpecialities()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            foreach (var item in DBcontext.Specialities)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Id).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetSubjects()
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            var subjects = new List<Subject>();

            DBcontext.Subjects.ToList().ForEach(s => {
                if (!subjects.Any(sub => sub.Title == s.Title))
                    subjects.Add(s);
            
            });



            foreach (var item in subjects)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Title).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<SelectListItem> GetSubjects(List<Subject> except)
        {
            var items = new List<SelectListItem>();
            var DBcontext = new Entities();
            var subjects = new List<Subject>();

            DBcontext.Subjects.ToList().ForEach(s =>
            {
                if (!subjects.Any(sub => sub.Title == s.Title) && !except.Any(sub=>sub.Id == s.Id))
                    subjects.Add(s);
            });

            foreach (var item in subjects)
            {
                items.Add(new SelectListItem
                {
                    Value = (item.Title).ToString(),
                    Text = item.Title
                });
            }
            return items;
        }

        public static List<Note> CreateSyllabusForStudent(int studentId, Group group)
        {
            var syllabus = group.Speciality.Syllabus;
            var sylla = JsonConvert.DeserializeObject<SyllabusViewModel>(syllabus.Syllabus1);
            List<Note> list = new List<Note>();
            foreach (var sem in sylla.Syllabus1)
            {
                foreach (var disc in sem)
                {
                    list.Add(new Note()
                    {
                        StudentId = studentId,
                        Note1 = null,
                        SubjectId = disc
                    });
                }
            }
            return list;
        }


    }
}
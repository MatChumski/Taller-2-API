using Microsoft.AspNetCore.Mvc;

namespace Taller_2___API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Taller2Controller : Controller
    {
        public static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 0,
                Name = "admin",
                Email = "admin@admin.com",
                Password = "admin123"
            },
            new User()
            {
                Id = 1,
                Name = "prueba",
                Email = "prueba@prueba.com",
                Password = "123"
            }
        };

        public static List<Question> questions = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Content = "¿Quién fue el primer presidente de los Estados Unidos?",
                Answers = new List<string>()
                {
                    "George Washignton",
                    "Abraham Lincoln",
                    "Barack Obama",
                    "Walter White"
                },
                RightAnswer = 2
            },
            new Question()
            {
                Id = 2,
                Content = "¿Qué país fue el principal causante de la segunda guerra mundial?",
                Answers = new List<string>()
                {
                    "Rusia",
                    "Albuquerque",
                    "Alemania",
                    "Estados Unidos"
                },
                RightAnswer = 3
            },
            new Question()
            {
                Id = 3,
                Content = "¿Qué empresa de comida es famosa por su color rojo y amarillo?",
                Answers = new List<string>()
                {
                    "Los Pollos Hermanos",
                    "Burger King",
                    "Subway",
                    "McDonald's"
                },
                RightAnswer = 4
            },
            new Question()
            {
                Id = 4,
                Content = "¿Qué ecuación describe la energía de un cuerpo?",
                Answers = new List<string>()
                {
                    "E = mc2",
                    "E = d/t",
                    "E = ma",
                    "E = (Vf - Vi) / t"
                },
                RightAnswer = 1
            },
            new Question()
            {
                Id = 5,
                Content = "El único mamífero que pone huevos",
                Answers = new List<string>()
                {
                    "Pato",
                    "Canguro",
                    "Ornitorrinco",
                    "Capibara"
                },
                RightAnswer = 3
            }
        };

        /*
         * GET Try to login with User ID (Username or Email) and Password
         */
        [HttpGet("Login")]
        public dynamic Get_Login(string userId, string pwd)
        {
            var user =
                (from u in users
                where (u.Name == userId || u.Email == userId) && u.Password == pwd
                select u).ToList();

            if (user.Count > 0)
            {
                return user;
            } else
            {
                return new
                {
                    code = "API001",
                    message = "WRONG LOGIN INFO"
                };
            }
        }

        /*
         * GET Full List of Questions
         */
        [HttpGet("Questions")]
        public List<Question> Consultar()
        {
            return questions;
        }

        /*
         * GET User by ID
         */
        [HttpGet("User")]
        public dynamic Get_User(int id)
        {
            var user = users.Where(x => x.Id == id).ToList();

            if (user.Count > 0)
            {
                return user;
            }
            else
            {
                return new
                {
                    code = "API002",
                    message = "USER " + id.ToString() + " NOT FOUND"
                };
            }
        }

        /*
         * GET Question by ID
         */
        [HttpGet("QuestionDet")]
        public dynamic Get_QuestionDet(int id)
        {
            var question = questions.Where(x => x.Id == id).ToList();

            if (question.Count > 0)
            {
                return question;
            }
            else
            {
                return new
                {
                    code = "API002",
                    message = "QUESTION " + id.ToString() + " NOT FOUND"
                };
            }
        }
    }
}

using Lab11_2_StackOvr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_2_StackOvr.Controllers
{
    public class UserControls : Controller
    {


        public IActionResult UserPage(int UID)
        {

            return View(DAL.getUsr(UID));

        }

        public IActionResult AnswersDetail(int QUID)
        {
            QAns QA_pair = new QAns();

            QA_pair.Q = DAL.GetQuestion(QUID);
            QA_pair.Answers = DAL.GetAllAnswers(QUID);

          
            return View(QA_pair);
        }

        public IActionResult QuestionDetail(int QUID)
        {
            QAns QA_pair = new QAns();

            QA_pair.Q = DAL.GetQuestion(QUID);
            QA_pair.Answers = DAL.GetAllAnswers(QUID);

            return View(QA_pair);
        }


        public IActionResult QuestionIndex()
        {
            return View(DAL.GetAllQs());
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            DAL.sessionUser = null;

            return Redirect("QuestionIndex");
        }

        public IActionResult uLogin (string Username)
        {
            DAL.sessionUser = DAL.getUsr(Username);
            return Redirect("QuestionIndex");
        }

        public IActionResult AskAQ()
        {
            if (DAL.sessionUser == null) return View("Login");
            return View(DAL.sessionUser);
        }

        public IActionResult PostQ(Question newQ)
        {
            DAL.PostQ(newQ);

            return Redirect("QuestionIndex");

        }


    }
}

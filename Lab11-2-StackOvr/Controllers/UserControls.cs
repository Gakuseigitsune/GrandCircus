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



        public IActionResult Upvote(int AID, int QID)
        {
            Answer a = DAL.GetAnswer(AID);

            a.Upvotes++;

            DAL.EditA(a);

            return Redirect($"/UserControls/AnswersDetail?QID={QID}");
        }

        public IActionResult Downvote(int AID, int QID)
        {

            Answer a = DAL.GetAnswer(AID);

            a.Upvotes--;

            DAL.EditA(a);

            return Redirect($"/UserControls/AnswersDetail?QID={QID}");
        }

        public IActionResult CloseQ(int QID)
        {
            Question q = DAL.GetQuestion(QID);

            q.Status = 1;

            DAL.EditQ(q);

            return Redirect($"/UserControls/QuestionDetail?QID={QID}");
        }

        public IActionResult Index() => View();  // mainly for tests

        public IActionResult Answer(int AID) => View(DAL.GetAnswer(AID));


        public IActionResult AnswerAQ(int QID)
        {
            if (DAL.sessionUser == null) return Redirect("Login");
            return View(DAL.GetQuestion(QID));
        }

        public IActionResult PostAns(Answer newA)
        {
            DAL.PostA(newA);

            return Redirect("QuestionIndex");

        }


        public IActionResult UserPage(string UID) => View(DAL.GetAllByUser(UID));


        public IActionResult AnswersDetail(int QID)
        {

            QAns QA_pair = new QAns();

            QA_pair.Q = DAL.GetQuestion(QID);
            QA_pair.Answers = DAL.GetAllAnswers(QID);

          
            return View(QA_pair);
        }

        public IActionResult QuestionDetail(int QID)
        {
            QAns QA_pair = new QAns();

            QA_pair.Q = DAL.GetQuestion(QID);
            QA_pair.Answers = DAL.GetAllAnswers(QID);

            return View(QA_pair);
        }


        public IActionResult QuestionIndex() => View(DAL.GetAllQs());

        public IActionResult Login() => View();


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

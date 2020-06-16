using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIOUI.Site.Data;
using DevIOUI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIOUI.Site.Controllers
{
    public class TesteCrudController : Controller
    {

        private readonly MeuDbContext _context;

        public TesteCrudController(MeuDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Leonardo",
                DataNascimento = DateTime.Now,
                Email = "leonardo@teste.com"
            };

            _context.Add(aluno);
            _context.SaveChanges();

            var aluno2 = _context.Alunos.Find(aluno.Id);

            var aluno3 = _context.Alunos.FirstOrDefault(a => a.Email == "leonardo@teste.com");

            var aluno4 = _context.Alunos.Where(a => a.Email == "leonardo");

            aluno.Nome = "João";

            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();


            return View();
        }
    }
}
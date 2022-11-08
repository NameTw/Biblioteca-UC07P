using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            @ViewBag.Pag = "Crie sua conta!";
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            UsuarioService us = new UsuarioService();
            us.Inserir(user);
            @ViewBag.Pag = "Cadastro efetuado com sucesso";
            return View();
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario user = us.DetalhesExcluir(id);
            @ViewBag.Pag = "Edição de contas!";
            return View(user);
        }

        [HttpPost]
        public IActionResult Edicao(Usuario user)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            us.Atualizar(user);
            @ViewBag.Pag = "Edição do usuário realizada com sucesso!";
            return View();
        }

        public IActionResult Excluir(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            us.Deletar(id);
            @ViewBag.Pag = "Conta excluida com sucesso!";
            return View();
        }

        public IActionResult Listagem()
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            return View(us.Listar());
        }
    }
}